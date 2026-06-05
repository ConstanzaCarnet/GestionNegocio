using GestionApp.src.DTOs.Response;
using GestionApp.src.Services;
//instalamos paquete LiveChartsCore.SkiaSharpView.WinForms para los gráficos
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
//para pdf
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;
using System;
//para descargar archivos
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;


namespace GestionApp.Vistas
{
    public partial class frmBalances : FormBase
    {
        //instancio servicios y dependencias(paquedes)
        private PieChart pieChartControl;
        BalanceService _balanceService = new BalanceService();
        private CartesianChart barChartControl;

        //lista para los datos
        private List<MovimientoBalanceDto> datosActualesGrilla;
        private ResumenBalanceDto resumenActual;
        //fecha de hoy
        DateTime fechaMaxima = DateTime.Now;
        DateTime fechaMinima = DateTime.Now.AddMonths(-1);
        public frmBalances()
        {
            InitializeComponent();
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdFiltrar, IconosUI.Filtrar);
            IconosUI.AplicarIconoBoton(cmdDescargar, IconosUI.Descargar);
            IconosUI.AplicarIconoBoton(cmdExcel, IconosUI.Exportar);
            IconosUI.AplicarIconoBoton(cmdReiniciar, IconosUI.Refrescar);
            InicializarGraficos();
            VincularEventosRadioButtons();

            // 1. Primero calculamos las fechas de referencia
            DateTime hoy = DateTime.Now;
            DateTime haceSeisMeses = hoy.AddMonths(-6);

            // 2. Seteamos los valores iniciales (DEBEN estar dentro del rango por defecto antes de cambiar límites)
            dtpDesde.Value = haceSeisMeses;
            dtpHasta.Value = hoy;

            // 3. Ahora sí, restringimos los límites mínimos y máximos de los controles
            dtpDesde.MinDate = haceSeisMeses;
            dtpDesde.MaxDate = hoy;

            dtpHasta.MinDate = haceSeisMeses;
            dtpHasta.MaxDate = hoy;
        }
        public void InicializarGraficos()
        {
            pieChartControl = new PieChart { Dock = DockStyle.Fill };
            barChartControl = new CartesianChart { Dock = DockStyle.Fill, Visible = false };

            panelGrafico.Controls.Add(pieChartControl);
            panelGrafico.Controls.Add(barChartControl);
        }

        private void VincularEventosRadioButtons()
        {
            rdbMetodos.CheckedChanged += (s, e) => { if (rdbMetodos.Checked) RenderizarGraficoSegunSeleccion(); };
            rdbProductos.CheckedChanged += (s, e) => { if (rdbProductos.Checked) RenderizarGraficoSegunSeleccion(); };

            rdbTendencia.CheckedChanged += (s, e) =>
            {
                if (rdbTendencia.Checked)
                {
                    dtpDesde.Enabled = false; // Deshabilitamos 'Desde' visualmente para guiar al usuario
                    RenderizarGraficoSegunSeleccion();
                }
                else
                {
                    dtpDesde.Enabled = true;
                }
            };
        }
        private void RenderizarGraficoSegunSeleccion()
        {
            if (resumenActual == null) return;

            // CASO 1: MÉTODOS DE PAGO (Circular)
            if (rdbMetodos.Checked)
            {
                barChartControl.Visible = false;
                pieChartControl.Visible = true;

                var series = new List<ISeries>();
                foreach (var item in resumenActual.PagosPorMetodo)
                {
                    series.Add(new PieSeries<decimal> { Values = new decimal[] { item.Value }, Name = item.Key });
                }
                pieChartControl.Series = series;
            }
            // CASO 2: MIX DE PRODUCTOS POR CATEGORÍA (Circular)
            else if (rdbProductos.Checked)
            {
                barChartControl.Visible = false;
                pieChartControl.Visible = true;

                var series = new List<ISeries>();
                foreach (var item in resumenActual.VentasPorCategoria)
                {
                    series.Add(new PieSeries<decimal> { Values = new decimal[] { item.Value }, Name = item.Key });
                }
                pieChartControl.Series = series;
            }
            // CASO 3: TENDENCIA DE 6 MESES (Barras)
            else if (rdbTendencia.Checked)
            {
                pieChartControl.Visible = false;
                barChartControl.Visible = true;

                var labels = resumenActual.TendenciaSeisMeses
                    .Select(x => x.Key)
                    .ToArray();

                var values = resumenActual.TendenciaSeisMeses
                    .Select(x => (double)x.Value)
                    .ToArray();

                barChartControl.Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = values,
                        Name = "Ventas Mensuales",
                        GeometrySize = 12,
                        Fill = new SolidColorPaint(new SKColor(30, 144, 255, 50)),
                        LineSmoothness = 0
                    }
                };

                barChartControl.XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = labels,
                        LabelsRotation = 15
                    }
                };

                barChartControl.YAxes = new Axis[]
                {
                    new Axis
                    {
                        Labeler = value => $"$ {value:N0}"
                    }
                };

                barChartControl.Update();
            }
        }

        private void cmdFiltrar_Click(object sender, EventArgs e)
        {
            resumenActual = _balanceService.ObtenerBalancePeriodo(dtpDesde.Value, dtpHasta.Value);

            datosActualesGrilla = resumenActual.DetallesGrilla;
            dgvListar.DataSource = null;
            dgvListar.DataSource = datosActualesGrilla;

            if (dgvListar.Columns["TotalVentas"] != null) dgvListar.Columns["TotalVentas"].DefaultCellStyle.Format = "'$' #,##0.00";
            if (dgvListar.Columns["TotalPagos"] != null) dgvListar.Columns["TotalPagos"].DefaultCellStyle.Format = "'$' #,##0.00";
            if (resumenActual != null || datosActualesGrilla.Count != 0) ActivarRdb();
            RenderizarGraficoSegunSeleccion();
        }
        private void ActivarRdb()
        {
            rdbMetodos.Enabled = true;
            rdbProductos.Enabled = true;
            rdbTendencia.Enabled = true;
        }
        private void cmdExcel_Click(object sender, EventArgs e)
        {
            if (datosActualesGrilla == null || datosActualesGrilla.Count == 0)
            {
                MessageBox.Show("No se ha generado ningún reporte que pueda exportar", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            using (var sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = "Balance.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Balance");

                            // Cabeceras
                            worksheet.Cell(1, 1).Value = "Fecha";
                            worksheet.Cell(1, 2).Value = "Total Ventas";
                            worksheet.Cell(1, 3).Value = "Total Pagos";

                            // Datos
                            int fila = 2;
                            foreach (var item in datosActualesGrilla)
                            {
                                worksheet.Cell(fila, 1).Value = item.Fecha;
                                worksheet.Cell(fila, 2).Value = item.TotalVentas;
                                worksheet.Cell(fila, 3).Value = item.TotalPagos;
                                fila++;
                            }

                            // Darle un formato lindo rápido
                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("¡Archivo Excel generado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
        }

        private void cmdDescargar_Click(object sender, EventArgs e)
        {
            if (datosActualesGrilla == null || datosActualesGrilla.Count == 0)
            {
                MessageBox.Show("No hay datos cargados para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                // Configuramos el filtro para que el usuario elija el tipo de archivo
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf|Archivo CSV (*.csv)|*.csv|Archivo de Texto (*.txt)|*.txt";
                sfd.Title = "Exportar Balance";
                sfd.FileName = $"Balance_{dtpDesde.Value:yyyyMMdd}_a_{dtpHasta.Value:yyyyMMdd}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(sfd.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".csv":
                                ExportarCSV(sfd.FileName);
                                break;
                            case ".txt":
                                ExportarTXT(sfd.FileName);
                                break;
                            case ".pdf":
                                ExportarPDF(sfd.FileName);
                                break;
                        }
                        MessageBox.Show("¡Archivo exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportarCSV(string rutaArchivo)
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
        private void ExportarTXT(string rutaArchivo)
        {
            using (var sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                sw.WriteLine("==================================================");
                sw.WriteLine("               REPORTE DE BALANCES                ");
                sw.WriteLine("==================================================");
                sw.WriteLine($"Período: {dtpDesde.Value:dd/MM/yyyy} hasta {dtpHasta.Value:dd/MM/yyyy}");
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

        private void ExportarPDF(string rutaArchivo)
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
                                col.Item().Text($"Desde: {dtpDesde.Value:dd/MM/yyyy}").AlignRight();
                                col.Item().Text($"Hasta: {dtpHasta.Value:dd/MM/yyyy}").AlignRight();
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
                                table.Cell().Background(Colors.Grey.Lighten4).Padding(6).Text(acumuladorVentas.ToString("C")).Bold().AlignRight();
                                table.Cell().Background(Colors.Grey.Lighten4).Padding(6).Text(acumuladorPagos.ToString("C")).Bold().AlignRight();
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
                                        tableProd.Cell().BorderBottom(1).Padding(4).Text(cat.Value.ToString("C")).AlignRight();
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

        private void rdbProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (resumenActual == null || datosActualesGrilla.Count == 0) MessageBox.Show("Lo siento en este periodo no se encuentran datos para mostrar");
        }

        private void rdbTendencia_CheckedChanged(object sender, EventArgs e)
        {
            if (resumenActual == null || datosActualesGrilla.Count == 0) MessageBox.Show("Lo siento en este periodo no se encuentran datos para mostrar");
        }

        private void rdbMetodos_CheckedChanged(object sender, EventArgs e)
        {
            if (resumenActual == null || datosActualesGrilla.Count == 0) MessageBox.Show("Lo siento en este periodo no se encuentran datos para mostrar");
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdReiniciar_Click(object sender, EventArgs e)
        {
            // 1. Desvincular límites temporales para evitar conflictos al resetear valores
            dtpDesde.MinDate = DateTime.MinValue;
            dtpDesde.MaxDate = DateTime.MaxValue;
            dtpHasta.MinDate = DateTime.MinValue;
            dtpHasta.MaxDate = DateTime.MaxValue;

            // 2. Volver a setear los valores y límites correctos por defecto
            DateTime hoy = DateTime.Now;
            DateTime haceUnMes = hoy.AddMonths(-1);

            dtpDesde.MaxDate = hoy;
            dtpDesde.MinDate = haceUnMes;
            dtpDesde.Value = haceUnMes;

            dtpHasta.MaxDate = hoy;
            dtpHasta.MinDate = haceUnMes;
            dtpHasta.Value = hoy;

            // 3. Limpiar las variables de datos en memoria
            resumenActual = null;
            datosActualesGrilla = null;

            // 4. Vaciar el DataGridView
            dgvListar.DataSource = null;

            // 5. Desmarcar todos los RadioButtons de los gráficos
            rdbMetodos.Checked = false;
            rdbProductos.Checked = false;
            rdbTendencia.Checked = false;

            // 6. Apagar la interacción de los RadioButtons hasta que vuelvan a filtrar
            rdbMetodos.Enabled = false;
            rdbProductos.Enabled = false;
            rdbTendencia.Enabled = false;

            // 7. Limpiar y ocultar los controles de los gráficos de LiveCharts
            pieChartControl.Series = null;
            pieChartControl.Visible = false;

            barChartControl.Series = null;
            barChartControl.XAxes = null;
            barChartControl.Visible = false;

            // 8. Habilitar el dtpDesde por si quedó bloqueado por la tendencia
            dtpDesde.Enabled = true;

            MessageBox.Show("Filtros y gráficos reiniciados.", "Listo para otro informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
