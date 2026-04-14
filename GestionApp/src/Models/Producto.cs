using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models;
public class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public int Stock { get; set; }
    public string? Imagen { get; set; }
    //public string Estado { get; set; }
    public int IdCategoria { get; set; }
    public Categoria Categoria { get; set; }

    //usaremos un diseño de software DDD(Domain-Driven Design) para organizar el código, por lo que no tendremos una clase de repositorio, sino que el acceso a los datos se realizará a través de servicios o casos de uso específicos.
    //constructores
    public Producto()
    {
    }

    public Producto(string nombre, string? descripcion, decimal precioCompra, decimal precioVenta, int stock, string? imagen, int idCategoria)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        PrecioCompra = precioCompra;
        PrecioVenta = precioVenta;
        Stock = stock;
        Imagen = imagen;
        IdCategoria = idCategoria;
    }

    //método para descontar cantidad en stock de un producto
    public void DescontarStock(int cantidad)
    {
        if (cantidad <= 0)
            throw new Exception("Cantidad inválida");

        if (Stock < cantidad)
            throw new Exception("Stock insuficiente");

        Stock -= cantidad;
    }

    //agregar cantidad en stock de un producto
    public void AgregarStock(int cantidad)
    {
        if (cantidad <= 0)
            throw new Exception("Cantidad inválida");
        Stock += cantidad;
    }
    //modificar producto
    public void CambiarDatos(string nombre, decimal precioVenta,int stock, int idCategoría)
    {
        if (nombre == null) throw new Exception("Nombre inválido");
        if (precioVenta <= 0) throw new Exception("Precio de venta inválido");
        //la categoría la ingresaremos de un combobox, por ende no la valido
        //cambio los valores
        Nombre = nombre;
        PrecioVenta = precioVenta;
        Stock = stock;
        IdCategoria = idCategoría;
    }
}

