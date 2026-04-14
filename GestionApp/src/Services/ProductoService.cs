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
                null,
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
                .AsNoTracking()
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    PrecioCompra =p.PrecioCompra,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock
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
        //buscar producto por categoría
        public List<ProductoDto> BuscarCategoria(int categoria)
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
                    Stock = p.Stock
                })
                .ToList();
        }

        //Modificar un producto
        public void Actualizar(ActualizarProductoDto dto)
        {
            using var db = new AppDbContext();
            var producto = db.Productos.FirstOrDefault(p => p.IdProducto == dto.IdProducto);

            if (producto == null) throw new Exception("Error, el producto no se encontró");
            producto.CambiarDatos(dto.Nombre, dto.PrecioVenta, dto.Stock, dto.IdCategoria);
            db.SaveChanges();
        }

    }
}
