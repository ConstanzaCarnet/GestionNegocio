using GestionApp.src.Data;
using GestionApp.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Services;

public class  VentaService
{
    public void CrearVenta(int clienteId, List<(int productoId, int cantidad)> items, string metodoPago)
    {
        using var db = new AppDbContext();

        var venta = new Venta(clienteId, metodoPago);

        foreach (var item in items)
        {
            var producto = db.Productos.First(p => p.IdProducto == item.productoId);

            venta.AgregarProducto(producto, item.cantidad);
        }

        db.Ventas.Add(venta);

        // Si es deuda → generar movimiento
        if (metodoPago == "Deuda")
        {
            db.CuentasCorrientes.Add(new CuentaCorriente
            {
                IdCliente = clienteId,
                Tipo = "CARGO",
                Monto = venta.MontoTotal,
                IdVenta = venta.IdVenta
            });
        }

        db.SaveChanges();
    }

}