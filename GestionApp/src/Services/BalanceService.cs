using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.Data;
using GestionApp.src.DTOs.Response;
using Microsoft.EntityFrameworkCore;
//para pdf
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Windows.Forms;

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
        //Documentos
        public void ExportarCSV(string rutaArchivo, List<MovimientoBalanceDto> datosActualesGrilla)
        {
            using (var sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                // Escribimos la cabecera
                sw.WriteLine("Fecha;Total Ventas;Total Pagos");

                // Escribimos los datos de la lista
                foreach (var item in datosActualesGrilla)
                {
                    string fila = $"{item.Fecha};{item.TotalVentas:F2};{item.TotalPagos:F2}";
                    sw.WriteLine(fila);
                }
            }
        }

        public void ExportarPDF(string rutaArchivo,DateTime desde, DateTime hasta, List<MovimientoBalanceDto> datosActualesGrilla, ResumenBalanceDto resumenActual, RadioButton rdbProductos, RadioButton rdbTendencia)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            try
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                        // --- ENCABEZADO ---
                        page.Header().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("GestionApp").SemiBold().FontSize(18).FontColor(Colors.Blue.Darken3);
                                col.Item().Text("Reporte Avanzado de Balances e Insights").FontSize(12).FontColor(Colors.Grey.Darken2);
                            });

                            row.ConstantItem(150).Column(col =>
                            {
                                col.Item().Text($"Desde: {desde:dd/MM/yyyy}").AlignRight();
                                col.Item().Text($"Hasta: {hasta:dd/MM/yyyy}").AlignRight();
                            });
                        });

                        // --- CONTENIDO PRINCIPAL ---
                        page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
                        {
                            // 1. Grilla principal de movimientos diarios
                            column.Item().Text("Movimientos del Período").Bold().FontSize(14).Underline();
                            column.Item().PaddingBottom(10);

                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(3);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(6).Text("Fecha").Bold().FontColor(Colors.White);
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(6).Text("Total Ventas").Bold().FontColor(Colors.White).AlignRight();
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(6).Text("Total Pagos").Bold().FontColor(Colors.White).AlignRight();
                                });

                                decimal acumuladorVentas = 0;
                                decimal acumuladorPagos = 0;

                                foreach (var item in datosActualesGrilla)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.Fecha);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.TotalVentas.ToString("'$' #,##0.00")).AlignRight();
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.TotalPagos.ToString("'$' #,##0.00")).AlignRight();

                                    acumuladorVentas += item.TotalVentas;
                                    acumuladorPagos += item.TotalPagos;
                                }

                                table.Cell().Background(Colors.Grey.Lighten4).Padding(6).Text("TOTALES").Bold();
                                table.Cell().Background(Colors.Grey.Lighten4).Padding(6).Text(acumuladorVentas.ToString("'$' #,##0.00")).Bold().AlignRight();
                                table.Cell().Background(Colors.Grey.Lighten4).Padding(6).Text(acumuladorPagos.ToString("'$' #,##0.00")).Bold().AlignRight();
                            });

                            // APARTADO CONDICIONAL: MIX DE PRODUCTOS (%)
                            if (rdbProductos.Checked && resumenActual?.VentasPorCategoria.Count > 0)
                            {
                                column.Item().PaddingTop(20);
                                column.Item().Text("Proporción de Ventas por Categoría").Bold().FontSize(14).Underline();
                                column.Item().PaddingBottom(5);

                                column.Item().Table(tableProd =>
                                {
                                    tableProd.ColumnsDefinition(cols =>
                                    {
                                        cols.RelativeColumn(4);
                                        cols.RelativeColumn(2);
                                        cols.RelativeColumn(2);
                                    });

                                    tableProd.Header(h =>
                                    {
                                        h.Cell().Background(Colors.Grey.Darken2).Padding(5).Text("Categoría").Bold().FontColor(Colors.White);
                                        h.Cell().Background(Colors.Grey.Darken2).Padding(5).Text("Monto Total").Bold().FontColor(Colors.White).AlignRight();
                                        h.Cell().Background(Colors.Grey.Darken2).Padding(5).Text("Participación").Bold().FontColor(Colors.White).AlignRight();
                                    });

                                    decimal totalVentasCat = resumenActual.VentasPorCategoria.Sum(x => x.Value);

                                    foreach (var cat in resumenActual.VentasPorCategoria)
                                    {
                                        decimal porcentaje = totalVentasCat > 0 ? (cat.Value / totalVentasCat) * 100 : 0;

                                        tableProd.Cell().BorderBottom(1).Padding(4).Text(cat.Key);
                                        tableProd.Cell().BorderBottom(1).Padding(4).Text(cat.Value.ToString("'$' #,##0.00")).AlignRight();
                                        tableProd.Cell().BorderBottom(1).Padding(4).Text($"{porcentaje:F1}%").AlignRight();
                                    }
                                });
                            }

                            // APARTADO CONDICIONAL: INSIGHTS DE TENDENCIA (ÚLTIMOS 6 MESES)
                            if (rdbTendencia.Checked && resumenActual?.TendenciaSeisMeses.Count > 0)
                            {
                                column.Item().PaddingTop(20);
                                column.Item().Text("Análisis Histórico de Tendencia (Últimos 6 Meses)").Bold().FontSize(14).Underline();
                                column.Item().PaddingBottom(5);

                                column.Item().Table(tableTend =>
                                {
                                    tableTend.ColumnsDefinition(cols =>
                                    {
                                        cols.RelativeColumn(4);
                                        cols.RelativeColumn(4);
                                    });

                                    tableTend.Header(h =>
                                    {
                                        h.Cell().Background(Colors.Grey.Darken2).Padding(5).Text("Mes").Bold().FontColor(Colors.White);
                                        h.Cell().Background(Colors.Grey.Darken2).Padding(5).Text("Total Facturado").Bold().FontColor(Colors.White).AlignRight();
                                    });

                                    foreach (var mes in resumenActual.TendenciaSeisMeses)
                                    {
                                        tableTend.Cell().BorderBottom(1).Padding(4).Text(mes.Key);
                                        tableTend.Cell().BorderBottom(1).Padding(4).Text(mes.Value.ToString("'$' #,##0.00")).AlignRight();
                                    }
                                });
                            }
                        });

                        // --- PIE DE PÁGINA ---
                        page.Footer().Row(row =>
                        {
                            row.RelativeItem().Text($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}").FontColor(Colors.Grey.Darken1).FontSize(9);
                            row.RelativeItem().AlignRight().Text(x =>
                            {
                                x.Span("Página ");
                                x.CurrentPageNumber();
                            });
                        });
                    });
                }).GeneratePdf(rutaArchivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al compilar el PDF analítico: {ex.Message}");
            }
        }

        public void ExportarTXT(string rutaArchivo, DateTime desde, DateTime hasta, List<MovimientoBalanceDto> datosActualesGrilla)
        {
            using (var sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                sw.WriteLine("==================================================");
                sw.WriteLine("               REPORTE DE BALANCES                ");
                sw.WriteLine("==================================================");
                sw.WriteLine($"Período: {desde:dd/MM/yyyy} hasta {hasta:dd/MM/yyyy}");
                sw.WriteLine("--------------------------------------------------");
                // Alineación de columnas usando formato de strings (estructura de tabla fija)
                sw.WriteLine("{0,-15} {1,15} {2,15}", "Fecha", "Total Ventas", "Total Pagos");
                sw.WriteLine("--------------------------------------------------");

                decimal totalPeriodoVentas = 0;
                decimal totalPeriodoPagos = 0;

                foreach (var item in datosActualesGrilla)
                {
                    sw.WriteLine("{0,-15} {1,15:'$' #,##0.00} {2,15:'$' #,##0.00}", item.Fecha, item.TotalVentas, item.TotalPagos);
                    totalPeriodoVentas += item.TotalVentas;
                    totalPeriodoPagos += item.TotalPagos;
                }

                sw.WriteLine("--------------------------------------------------");
                sw.WriteLine("{0,-15} {1,15:'$' #,##0.00} {2,15:'$' #,##0.00}", "TOTALES:", totalPeriodoVentas, totalPeriodoPagos);
                sw.WriteLine("==================================================");
            }
        }
    }
}
