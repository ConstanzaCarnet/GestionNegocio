using GestionApp.src.Data;
using GestionApp.src.DTOs.Request;
using GestionApp.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Services;

public class  VentaService
{
    //Aqui inyectamos el contexto de la base de datos para poder acceder a las tablas y realizar operaciones CRUD, en este caso, para crear una nueva venta.
    //es como decirle a la clase VentaService que necesita una instancia de AppDbContext para funcionar, y el framework se encargará de proporcionarla cuando se cree una instancia de VentaService
    //esto es parte del patrón de diseño conocido como Inyección de Dependencias, que ayuda a mantener el código más limpio, modular y fácil de probar.
    private readonly AppDbContext db;
    public VentaService(AppDbContext context)
    {
        db = context;
    }

    //los metodos que tendremos en service tendran la logica de negocio, es decir, las reglas y procesos que se deben seguir para realizar una venta, como validar los datos, calcular el monto total, etc.
    //En este caso, el método CrearVenta se encargará de agregar una nueva venta a la base de datos utilizando el contexto inyectado.
    public void CrearVenta(CrearVentaDto dto)
    {
        // Validación básica
        if (dto.Items == null || !dto.Items.Any())
            throw new Exception("La venta debe tener al menos un producto");

        var cliente = db.Clientes
            .FirstOrDefault(c => c.IdCliente == dto.IdCliente);

        if (cliente == null)
            throw new Exception("Cliente no encontrado");

        var venta = new Venta(dto.IdCliente);

        // Cargar productos en lote (mejor performance)
        var productosIds = dto.Items.Select(i => i.ProductoId).ToList();

        var productos = db.Productos
            .Where(p => productosIds.Contains(p.IdProducto))
            .ToList();

        foreach (var item in dto.Items)
        {
            var producto = productos
                .FirstOrDefault(p => p.IdProducto == item.ProductoId);

            if (producto == null)
                throw new Exception($"Producto {item.ProductoId} no encontrado");

            venta.AgregarProducto(producto, item.Cantidad);
        }

        db.Ventas.Add(venta);

        // Cuenta corriente        
        var cuenta = db.CuentasCorrientes
            .First(c => c.IdCliente == dto.IdCliente);
        //sumo el cargo
        cuenta.AplicarCargo(venta.MontoTotal);
        //guardo los cambios en base de datos
        db.SaveChanges();
    }
}