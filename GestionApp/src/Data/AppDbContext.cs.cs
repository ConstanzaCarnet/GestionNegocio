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
        public DbSet<Pago> Pagos { get; set; }

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
            return Path.Combine(folder, "Negocio.db");//se guarda en: bin/Debug/net8.0-windows/negocio.db
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
            modelBuilder.Entity<CuentaCorriente>().HasKey(c => c.IdCuenta);
            modelBuilder.Entity<Pago>().HasKey(p=> p.IdPago);

            //relaciones
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);
            //relacion Venta -> cliente
            modelBuilder.Entity<Venta>()
                .HasOne(v=>v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.IdCliente)
                .IsRequired();
            //relacion Venta->detalles
            modelBuilder.Entity<Venta>()
                .HasMany(v => v.Detalles)
                .WithOne(d => d.Venta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venta>()
                .Navigation(v => v.Detalles)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
            //relacion DetalleVenta -> Producto
            modelBuilder.Entity<DetalleVenta>()
                .Property(d => d.PrecioUnitario)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.IdProducto);

            //cuenta, relacion cliente 1-1
            modelBuilder.Entity<CuentaCorriente>()
                .HasOne(c => c.Cliente)
                .WithOne(cl => cl.Cuenta)
                .HasForeignKey<CuentaCorriente>(c => c.IdCliente);

        }
    }
}