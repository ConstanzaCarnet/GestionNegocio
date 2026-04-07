using GestionApp.src.Models;//importante: instalar paquete Microsoft.EntityFrameworkCore.Sqlite y Microsoft.EntityFrameworkCore.Tools desde NuGet para usar Entity Framework Core con SQLite
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Data
{
    public class AppDbContext : DbContext
    {
        //primero se llama a los modelos para crear las tablas correspondientes en la base de datos con DBSet
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<CuentaCorriente> CuentasCorrientes { get; set; }

        //configuracion de la conexion a la base de datos, en este caso se usa SQLite y se especifica la ruta del archivo de la base de datos
        //con esto evitamos tener que instanciar la conexion cada vez que queramos usar la base de datos,
        //ya que el DbContext se encarga de manejar la conexion y las operaciones con la base de datos

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={GetDbPath()}");
        }

        private string GetDbPath()
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(folder, "negocio.db");//se guarda en: bin/Debug/net8.0-windows/negocio.db
        }

        //configuracion de las relaciones entre las tablas, manejado con Entity Framework Core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //claves primarias
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Venta>().HasKey(v => v.IdVenta);
            modelBuilder.Entity<DetalleVenta>().HasKey(d => d.IdDetalle);
            modelBuilder.Entity<CuentaCorriente>().HasKey(c => c.IdMovimiento);

            //relaciones
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdVenta);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.IdProducto);

            modelBuilder.Entity<CuentaCorriente>()
                .HasOne(c => c.Cliente)
                .WithMany(cl => cl.CuentasCorrientes)
                .HasForeignKey(c => c.IdCliente);

            modelBuilder.Entity<CuentaCorriente>()
                .HasOne(c => c.Venta)
                .WithMany()
                .HasForeignKey(c => c.IdVenta)
                .IsRequired(false); //un movimiento de cuenta corriente puede no estar relacionado con una venta, por eso se marca como opcional
        }
    }
}