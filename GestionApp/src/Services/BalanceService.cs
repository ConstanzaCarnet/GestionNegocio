using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.Data;
using GestionApp.src.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace GestionApp.src.Services
{
    public class BalanceService
    {
        public ResumenBalanceDto ObtenerBalancePeriodo(DateTime desde, DateTime hasta)
        {
            using var db = new AppDbContext();

            var fechaDesde = desde.Date;
            var fechaHasta = hasta.Date.AddDays(1).AddTicks(-1);

            //Traer datos del período (agregando navegación al producto/categoría si es necesario)
            var ventas = db.Ventas
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(p => p.Categoria) // <-- AGREGÁ ESTA LÍNEA AQUÍ
                .Where(v => v.Fecha >= fechaDesde && v.Fecha <= fechaHasta)
                .AsNoTracking()
                .ToList();

            var pagos = db.Pagos
                .Where(p => p.Fecha >= fechaDesde && p.Fecha <= fechaHasta)
                .AsNoTracking()
                .ToList();

            // Grilla estándar por día
            var todasLasFechas = ventas.Select(v => v.Fecha.Date)
                .Union(pagos.Select(p => p.Fecha.Date))
                .OrderBy(f => f)
                .ToList();

            var listaGrilla = new List<MovimientoBalanceDto>();
            foreach (var fecha in todasLasFechas)
            {
                listaGrilla.Add(new MovimientoBalanceDto
                {
                    Fecha = fecha.ToString("dd/MM/yyyy"),
                    TotalVentas = ventas.Where(v => v.Fecha.Date == fecha).Sum(v => v.MontoTotal),
                    TotalPagos = pagos.Where(p => p.Fecha.Date == fecha).Sum(p => p.Monto)
                });
            }

            // 3. Agrupación por métodos de pago
            var pagosPorMetodo = pagos
                .GroupBy(p => p.MetodoPago)
                .ToDictionary(g => g.Key ?? "Otros", g => g.Sum(p => p.Monto));

            // Agrupación por Categorías de Producto
            var ventasPorCategoria = ventas.SelectMany(v => v.Detalles)
                .GroupBy(d => d.Producto?.Categoria?.Nombre ?? "Sin Categoría")
                .ToDictionary(g => g.Key, g => g.Sum(d => d.PrecioUnitario * d.Cantidad));

            //Tendencia histórica de los 6 meses anteriores (basado en 'hasta')
            // Forzar a que las fechas apunten al inicio y fin del día real
            DateTime inicioTendencia = new DateTime(
                hasta.Year,
                hasta.Month,
                1
            ).AddMonths(-5);

            DateTime fechaHastaLimite = new DateTime(
                hasta.Year,
                hasta.Month,
                DateTime.DaysInMonth(hasta.Year, hasta.Month),
                23, 59, 59
            );

            var ventasTendencia = db.Ventas
                 .Include(v => v.Detalles)
                 .AsNoTracking()
                 .Where(v =>
                     v.Fecha >= inicioTendencia &&
                     v.Fecha <= fechaHastaLimite)
                 .ToList() // <- primero traer a memoria
                 .Select(v => new
                 {
                     Fecha = v.Fecha,
                     Total = v.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario)
                 })
                 .ToList();

            var tendenciaSeisMeses = new List<KeyValuePair<string, decimal>>();

            for (int i = 5; i >= 0; i--)
            {
                DateTime mesEvaluado = hasta.AddMonths(-i);

                string nombreMes = mesEvaluado.ToString("MMMM yyyy");
                decimal totalMes = ventasTendencia
                    .Where(v =>
                        v.Fecha.Month == mesEvaluado.Month &&
                        v.Fecha.Year == mesEvaluado.Year)
                    .Sum(v => v.Total);

                tendenciaSeisMeses.Add(
                    new KeyValuePair<string, decimal>(
                        nombreMes,
                        totalMes
                    )
                );
            }
            return new ResumenBalanceDto
            {
                DetallesGrilla = listaGrilla,
                PagosPorMetodo = pagosPorMetodo,
                VentasPorCategoria = ventasPorCategoria,
                TendenciaSeisMeses = tendenciaSeisMeses
            };
        }
    }
}
