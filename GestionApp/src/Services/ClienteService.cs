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
using System.Windows.Forms;

namespace GestionApp.src.Services
{
    public class ClienteService
    {
        //crear cliente
        public void CrearCliente(CrearClienteDto dto)
        {
            using var db = new AppDbContext();

            if (db.Clientes.Any(c => c.Email == dto.Email))
                throw new Exception("El email ya está registrado");

            if (!Cliente.TelefonoEsValido(dto.Telefono))
                throw new Exception("El teléfono no es válido. Debe contener entre 8 y 15 dígitos.");

            var cliente = new Cliente(
                dto.Nombre,
                dto.Apellido,
                dto.Email,
                dto.Telefono,
                dto.Direccion
            );

            var cuenta = new CuentaCorriente
            {
                Cliente = cliente,
                Saldo = 0
            };

            db.Clientes.Add(cliente);
            db.CuentasCorrientes.Add(cuenta);
            db.SaveChanges();
        }

        //Obtener todos
        public List<ClienteDto> ObtenerTodos()
        {
            using var db = new AppDbContext();

            return db.Clientes
               .Where(c => c.Estado == "Activo")//no mostramos clientes dados de baja (soft-delete)
               .Include(c => c.Cuenta)//con esto incluimos los datos de la cuenta(Cuenta)
               .AsNoTracking()
               .Select(c => new ClienteDto
               {
                   IdCliente = c.IdCliente,
                   Nombre = c.Nombre,
                   Email = c.Email,
                   Apellido = (c.Apellido ?? ""),
                   Telefono = c.Telefono,
                   Direccion = c.Direccion,
                   Saldo = c.Cuenta != null ? c.Cuenta.Saldo : 0
               })
               .ToList();
        }
        //obtener nombre para combobox
        public string[] ObtenerNombresSugeridos()
        {
            using var db = new AppDbContext();
            return db.Clientes
                .Where(c => c.Estado == "Activo")//solo clientes activos
                .AsNoTracking()
                .Select(c => c.Nombre + " " + (c.Apellido ?? ""))
                .ToArray();
        }
        //enn concecuencia buiscamos por nombre completo
        public ClienteDto? ObtenerPorNombreCompleto(string nombreCompleto)
        {
            using var db = new AppDbContext();
            // Buscamos el cliente cuyo nombre y apellido coincidan con el texto
            var cliente = db.Clientes
                .Include(c => c.Cuenta)
                .AsNoTracking()
                .ToList() // Traemos a memoria para comparar la concatenación fácilmente
                .FirstOrDefault(c => (c.Nombre + " " + (c.Apellido ?? "")).Trim().ToLower() == nombreCompleto.Trim().ToLower());

            if (cliente == null) return null;

            return new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email ?? "",
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Saldo = cliente.Cuenta?.Saldo ?? 0
            };
        }

        // Obtener por ID
        public ClienteDto? ObtenerPorId(int id)
        {
            using var db = new AppDbContext();
            var cliente = db.Clientes
                        .Include(c => c.Cuenta)
                        .AsNoTracking()
                        .FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
                throw new Exception("Cliente no encontrado");

            return new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Saldo = cliente.Cuenta?.Saldo ?? 0
            };
        }

        // Buscar por nombre
        public List<ClienteDto> Buscar(string texto)
        {
            using var db = new AppDbContext();
            return db.Clientes
                .Include(c => c.Cuenta)
                .Where(c => c.Estado == "Activo" && c.Nombre.Contains(texto))
                .AsNoTracking()
                .Select(c => new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Nombre = c.Nombre,
                    Email = c.Email,
                    Apellido = (c.Apellido ?? ""),
                    Telefono = c.Telefono,
                    Direccion = c.Direccion,
                    Saldo = c.Cuenta != null ? c.Cuenta.Saldo : 0
                })
                .ToList();
        }

        // Filtrar deudores
        public List<ClienteDto> ObtenerDeudores()
        {
            using var db = new AppDbContext();
            return db.Clientes
                .Include(c => c.Cuenta)
                .Where(c => c.Estado == "Activo" && c.Cuenta != null && c.Cuenta.Saldo > 0)
                .AsNoTracking()
                .Select(c => new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Nombre = c.Nombre,
                    Email = c.Email,
                    Apellido = (c.Apellido ?? ""),
                    Telefono = c.Telefono,
                    Direccion = c.Direccion,
                    Saldo = c.Cuenta != null ? c.Cuenta.Saldo : 0
                })
                .ToList();
        }
        //Devolver los movimientos(tanto compra/venta como pago del cliente)
        public List<MovimientoDto> ObtenerMoviminetos(int id)
        {
            using var db = new AppDbContext();
            //Obtenemos ventas(compras a nivel real) del cliente
            var ventas = db.Ventas
                //le digo que incluya el detalle de la venta para que me traiga el monto total
                .Include(d => d.Detalles)
                .Where(v => v.IdCliente == id)
                .Select(v => new MovimientoDto
                {
                    IdMovimiento = v.IdVenta,
                    Fecha = v.Fecha,
                    Tipo = "Venta",
                    Monto = v.MontoTotal,
                    Detalle = "n° de Venta " + v.IdVenta
                }).ToList();
            var pagos = db.Pagos
                .Where(c => c.IdCliente == id)
                .Select(p => new MovimientoDto
                {
                    IdMovimiento = p.IdPago,
                    Fecha = p.Fecha,
                    Tipo = "Pago",
                    Monto = p.Monto,
                    Detalle = "n° de Recibo " + p.IdPago
                }).ToList();
            //devolvemos movimientos
            return ventas.Concat(pagos).OrderByDescending(m => m.Fecha).ToList();

        }


        // Actualizar cliente
        public void Actualizar(ActualizarClienteDto dto)
        {
            using var db = new AppDbContext();
            var cliente = db.Clientes.FirstOrDefault(c => c.IdCliente == dto.IdCliente);

            if (cliente == null)
                throw new Exception("Cliente no encontrado");

            if (!Cliente.TelefonoEsValido(dto.Telefono))
                throw new Exception("El teléfono no es válido. Debe contener entre 8 y 15 dígitos.");

            cliente.CambiarDatos(dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, dto.Direccion);

            db.SaveChanges();
        }

        // Eliminar
        public void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var cliente = db.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null) return;

            cliente.Desactivar();//no quiero borrar del registro al cliente

            db.SaveChanges();
        }
        //verificar si ya existe email
        public bool EmailExiste(string email)
        {
            using var db = new AppDbContext();
            return db.Clientes.Any(c => c.Email == email);
        }




    }
}
