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
                    Categoria =p.Categoria != null ? p.Categoria.Nombre : ""
                })
                .ToList();
        }

        //buscar producto por Id
        public ProductoDto BuscarPorId(int id)
        {
            using var db = new AppDbContext();
            var producto =  db.Productos
                            .AsNoTracking()
                            .FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
                throw new Exception("No se encontró el producto");

            return new ProductoDto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock
            };
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
            {
                MessageBox.Show("Error, el producto no se encontró", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            producto.CambiarDatos(dto.Nombre, dto.PrecioVenta, dto.Stock, dto.IdCategoria);
            db.SaveChanges();
        }

        //Eliminar producto
        public void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var producto = db.Productos.FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
            {
                MessageBox.Show("Error, el producto no se encontró", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.Remove(producto);
            db.SaveChanges();
        }

    }
}
