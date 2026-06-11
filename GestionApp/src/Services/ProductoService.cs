using GestionApp.src.Data;
using GestionApp.src.DTOs.Request;
using GestionApp.src.DTOs.Response;
using GestionApp.src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Services
{
    public class ProductoService
    {
        //Crear producto
        public void CrearProducto(CrearProductoDto dto)
        {
            //agro conexion
            using var db = new AppDbContext();
            if (dto.PrecioVenta <= 0)
                throw new Exception("Precio inválido");
            //creo el objeto
            var producto = new Producto(
                dto.Nombre,
                dto.Descripcion,
                dto.PrecioCompra,
                dto.PrecioVenta,
                dto.Stock,
                null,//aun no tengo para cargar imágenes
                dto.IdCategoria
                );
            //lo guardo
            db.Productos.Add( producto );
            db.SaveChanges();
        }

        //listar productos
        public List<ProductoDto> ObtenerTodos()
        {
            using var db = new AppDbContext();
            return db.Productos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    PrecioCompra =p.PrecioCompra,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    Descripcion = p.Descripcion,
                    Categoria = p.Categoria != null ? p.Categoria.Nombre : ""
                })
                .ToList();
        }

        //buscar producto por id
        public ProductoDto? ObtenerPorId(int id)
        {
            using var db = new AppDbContext();
            return db.Productos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .Where(p => p.IdProducto == id)
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    PrecioCompra = p.PrecioCompra,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    Descripcion = p.Descripcion,
                    Categoria = p.Categoria != null ? p.Categoria.Nombre : "Sin Categoría"
                })
                .FirstOrDefault();
        }
        //Buscar por nombre
        public List<ProductoDto> BuscarProducto(string busqueda)
        {
            using var db = new AppDbContext();
            var term = busqueda.ToLower().Trim();
            return db.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Nombre.ToLower().Contains(term))
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    PrecioCompra = p.PrecioCompra,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    Categoria = p.Categoria != null ? p.Categoria.Nombre : "Sin Categoría"
                }).ToList();
        }
        //Para sugerir en busqueda por nombre
        public string[] ObtenerNombresSugeridos()
        {
            using var db = new AppDbContext();
            return db.Productos.Select(p => p.Nombre).ToArray();
        }


        //buscar producto por categoría
        public List<ProductoDto> BuscarPorCategoria(int categoria)
        {
            using var db = new AppDbContext();
            return db.Productos
                .Include(p => p.Categoria)
                .Where(p => p.IdCategoria == categoria)
                .AsNoTracking()
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    PrecioCompra = p.PrecioCompra,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    Categoria = p.Categoria.Nombre
                })
                .ToList();
        }

        //Modificar un producto
        public void Actualizar(ActualizarProductoDto dto)
        {
            using var db = new AppDbContext();
            var producto = db.Productos.FirstOrDefault(p => p.IdProducto == dto.IdProducto);

            if (producto == null)
                throw new Exception("El producto no se encontró");

            producto.CambiarDatos(dto.Nombre, dto.PrecioVenta, dto.Stock, dto.IdCategoria, dto.PrecioCompra, dto.Descripcion);
            db.SaveChanges();
        }

        //Eliminar producto
        public void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var producto = db.Productos.FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
                throw new Exception("El producto no se encontró");

            //No permitimos borrar un producto que ya forma parte de ventas:
            //rompería el historial (FK) y los balances. Avisamos al usuario.
            bool tieneVentas = db.DetallesVenta.Any(d => d.IdProducto == id);
            if (tieneVentas)
                throw new Exception("No se puede eliminar el producto porque tiene ventas asociadas.");

            db.Remove(producto);
            db.SaveChanges();
        }

        //metodo para revisar si el producto ya existe, para evitar duplicados
        public bool ExisteProducto(string nombre)
        {
            using var db = new AppDbContext();
            return db.Productos.Any(p => p.Nombre.ToLower() == nombre.ToLower());
        }

    }
}
