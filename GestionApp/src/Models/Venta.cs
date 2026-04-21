using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionApp.src.Models
{
    public class Venta
    {
        public int IdVenta { get; private set; }
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new();
        public decimal MontoTotal => Detalles.Sum(d => d.Subtotal);
        public DateTime Fecha { get; private set; } = DateTime.Now;


        //Constructor necesario para EF(Entity Framework)
        //sin parametros, me permite crear una instancia de la clase Venta sin necesidad de pasarle argumentos, lo cual es útil para EF cuando carga los datos desde la base de datos y necesita crear objetos sin conocer los detalles de su construcción.
        public Venta() { }


        // Constructor
        public Venta(int idCliente)
        {
            IdCliente = idCliente;
        }
               
        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (producto.Stock < cantidad)
                throw new Exception("Stock insuficiente");
            //revisar si el producto ya existe
            var existente = Detalles.FirstOrDefault(d => d.IdProducto == producto.IdProducto);
            if (existente != null)
            {
                //aumento la cantidad del detalle
                existente.AumentarCantidad(cantidad);
                return;
            }
            else
            {
                //cargar nuevo detalle
                Detalles.Add(new DetalleVenta(producto.IdProducto, cantidad, producto.PrecioVenta));
            }
        }
        //quitar elemento a detalle
        public void QuitarDetalle(int idDetalle)
        {
            var detalle = Detalles.FirstOrDefault(d => d.IdDetalle == idDetalle);
            if (detalle == null)
                throw new Exception("Detalle no encontrado");
            Detalles.Remove(detalle);
        }

        //limpiar todos los elementos del detalle de venta
        public void LimpiarDetalles()
        {
            Detalles.Clear();
        }


    }
}