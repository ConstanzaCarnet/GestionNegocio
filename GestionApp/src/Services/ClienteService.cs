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
                .Where(c => c.Nombre.Contains(texto))
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
                .Where(c => c.Cuenta != null && c.Cuenta.Saldo > 0)
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

        // Actualizar cliente
        public void Actualizar(ActualizarClienteDto dto)
        {
            using var db = new AppDbContext();
            var cliente = db.Clientes.FirstOrDefault(c => c.IdCliente == dto.IdCliente);

            if (cliente == null)
                throw new Exception("Cliente no encontrado");

            cliente.CambiarDatos(dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, dto.Direccion);

            db.SaveChanges();
        }

        // Eliminar
        public void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var cliente = db.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null) return;

            cliente.Desactivar();

            db.SaveChanges();
        }
    }
}
