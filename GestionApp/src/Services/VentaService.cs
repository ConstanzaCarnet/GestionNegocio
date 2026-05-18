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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GestionApp.src.Services;

public class VentaService
{
    public void CrearVenta(CrearVentaDto dto)
    {
        using var db = new AppDbContext();
        //buscamos y validamos el cliente
        var cliente = db.Clientes.FirstOrDefault(c => c.IdCliente == dto.IdCliente);
        if (cliente == null) throw new Exception("Cliente no encontrado");

        // Validación de ítems
        if (dto.Items == null || !dto.Items.Any())
            throw new Exception("La venta debe tener al menos un producto");

        //creo la venta(vista macro del ticket de compra diriamos)
        var venta = new Venta(dto.IdCliente);

        // Busco productos(items) para crear el detalle de venta
        var productosIds = dto.Items.Select(i => i.IdProducto).ToList();

        var productos = db.Productos
            .Where(p => productosIds.Contains(p.IdProducto))
            .ToList();
        //creo cada detalle("letra chica" del ticket de compra)
        foreach (var item in dto.Items)
        {
            var producto = productos
                .FirstOrDefault(p => p.IdProducto == item.IdProducto);

            if (producto == null)
                throw new Exception($"Producto {item.IdProducto} no encontrado");
            //valido y descuento el stock <------Importante para actualizar stock!!
            producto.DescontarStock(item.Cantidad);
            //agrego
            venta.AgregarProducto(producto, item.Cantidad);
        }

        db.Ventas.Add(venta);

        // Cuenta corriente        
        var cuenta = db.CuentasCorrientes.FirstOrDefault(c => c.IdCliente == dto.IdCliente);
        if (cuenta == null) throw new Exception("El cliente no tiene una cuenta corriente asociada");
        //sumo el cargo
        cuenta.AplicarCargo(venta.MontoTotal);
        //guardo los cambios en base de datos
        db.SaveChanges();
    }

    //Mostrar ventas
    public List<VentaListDto> ObtenerVentasFiltrar()
    {
        using var db = new AppDbContext();
        var ventas = db.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Detalles)
            .ThenInclude(v => v.Producto)
            .AsQueryable();

        return ventas.Select(v => new VentaListDto
        {
            IdVenta = v.IdVenta,
            Cliente = v.Cliente.Nombre + " " + v.Cliente.Apellido,
            Email = v.Cliente.Email,
            Telefono = v.Cliente.Telefono,
            Total = v.MontoTotal,
            Fecha = v.Fecha
        }).ToList();
    }
    //obtener ventas filtradas
    public List<VentaListDto> ObtenerVentasFiltrar(string filtro, int id, int? anio = null)
    {
        using var db = new AppDbContext();
        var ventas = db.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Detalles)
            .ThenInclude(v => v.Producto)
            .AsQueryable();

        //filtro
        if (filtro == "Cliente")
            ventas = ventas.Where(v => v.IdCliente == id);
        else if (filtro == "Producto")
            ventas = ventas.Where(v => v.Detalles.Any(d => d.IdProducto == id));
        else if (filtro == "Mes" && anio.HasValue)
            ventas = ventas.Where(v => v.Fecha.Month == id && v.Fecha.Year == anio.Value);
        //devuelvo ya filtrado
        return ventas.Select(v => new VentaListDto
        {
            IdVenta = v.IdVenta,
            Cliente = v.Cliente.Nombre + " " + v.Cliente.Apellido,
            Email = v.Cliente.Email,
            Telefono = v.Cliente.Telefono,
            Total = v.MontoTotal,
            Fecha = v.Fecha
        }).ToList();
    }
    //obtener detalle de ventas
    public List<DetalleVentaDto> ObtenerDetalleDeVenta(int idVenta)
    {
        using var db = new AppDbContext();
        return db.DetallesVenta
            .Where(d => d.IdVenta == idVenta)
            .Include(d => d.Producto)
            .Select(d => new DetalleVentaDto
            {
                Producto = d.Producto.Nombre,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Cantidad * d.PrecioUnitario
            }).ToList();
    }
    //Mensaje
    public string GenerarTicketTexto(VentaListDto venta, List<DetalleVentaDto> detalleVenta)
    {
        StringBuilder sb = new StringBuilder();
        //construimos el mensaje
        sb.AppendLine("************************************");
        sb.AppendLine("         TIKET DE COMPRA            ");
        sb.AppendLine("************************************");
        sb.AppendLine($"Cliente: {venta.Cliente}");
        sb.AppendLine($"Fecha:    {venta.Fecha: dd/MM/yyyy}");
        sb.AppendLine("---------------------------------------------");
        sb.AppendLine("Cantidad         Producto            Subtotal");
        sb.AppendLine("---------------------------------------------");

        foreach (var item in detalleVenta)
        {
            //usamos interpolacion con la alineacion
            string nombreCorto = item.Producto.Length > 15 ? item.Producto.Substring(0, 15) : item.Producto;
            sb.AppendLine(string.Format("{0,-5}{1,-15}${2,8:N2}", item.Cantidad, nombreCorto, item.Subtotal));
        }
        sb.AppendLine("----------------------------------------------");
        sb.AppendLine(string.Format("{0,21} ${1,8:N2}", "TOTAL: ", venta.Total));
        sb.AppendLine("----------------------------------------------");
        sb.AppendLine("          ¡Gracias por su compra!             ");

        return sb.ToString();

    }
    //modificar venta---> en sí por el momento, la venta se crea y si no se elimina, o se agrega otra venta. Para simplificar el manejo
    //por eso el metodo modificar venta aun no se implementa en la interfaz
    public void ModificarVenta(int idVenta, CrearVentaDto dto)
    {
        using var db = new AppDbContext();
        var venta = db.Ventas
            .Include(v => v.Detalles)
            .FirstOrDefault(v => v.IdVenta == idVenta);
        if (venta == null) throw new Exception("Venta no encontrada");
        // Eliminar detalles anteriores
        db.DetallesVenta.RemoveRange(venta.Detalles);
        // Agregar nuevos detalles
        foreach (var item in dto.Items)
        {
            var detalle = new CrearDetalleDto
            {
                IdProducto = item.IdProducto,
                Cantidad = item.Cantidad
            };
            venta.AgregarProducto(db.Productos.Find(item.IdProducto), item.Cantidad);
        }
        db.SaveChanges();
    }
    //Eliminar venta
    public bool EliminarVenta(int idVenta)
    {
        //se elimina venta y detalles asociados, y se actualiza el stock de los productos
        using var db = new AppDbContext();
        var venta = db.Ventas
            .Include(v => v.Detalles)
            .FirstOrDefault(v => v.IdVenta == idVenta);
        //cuenta del cliente para actualizarla luego de eliminar la venta
        var cuenta = db.CuentasCorrientes.FirstOrDefault(c => c.IdCliente == venta.IdCliente);
        //validamos
        if(cuenta == null) throw new Exception("El cliente no tiene una cuenta corriente asociada");
        if (venta == null) return false;
        //antes de eliminar la venta, actualizamos el stock de los productos
        foreach (var detalle in venta.Detalles)
        {
            var producto = db.Productos.Find(detalle.IdProducto);
            producto.AgregarStock(detalle.Cantidad);//"devolvemos" el producto
        }
        //ademas hacemos un "pago" en la cuenta del cliente, para que la venta quede revertida tambien en la cuenta
        cuenta.AplicarPago(venta.MontoTotal);
        db.DetallesVenta.RemoveRange(venta.Detalles);
        db.Ventas.Remove(venta);
        db.SaveChanges();
        return true;
    }
}