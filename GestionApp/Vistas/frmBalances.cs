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
                                _balanceService.ExportarCSV(sfd.FileName, datosActualesGrilla);
                                break;
                            case ".txt":
                                _balanceService.ExportarTXT(sfd.FileName, dtpDesde.Value, dtpHasta.Value, datosActualesGrilla);
                                break;
                            case ".pdf":
                                _balanceService.ExportarPDF(sfd.FileName, dtpDesde.Value, dtpHasta.Value, datosActualesGrilla,resumenActual,rdbProductos,rdbTendencia);
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
            // Volver a setear los valores y límites correctos por defecto
            DateTime hoy = DateTime.Now;
            DateTime haceSeisMeses = hoy.AddMonths(-6);

            dtpDesde.MaxDate = hoy;
            dtpDesde.MinDate = haceSeisMeses;
            dtpDesde.Value = haceSeisMeses;

            dtpHasta.MaxDate = hoy;
            dtpHasta.MinDate = haceSeisMeses;
            dtpHasta.Value = hoy;

            //Limpiar las variables de datos en memoria
            resumenActual = null;
            datosActualesGrilla = null;

            //Vaciar el DataGridView
            dgvListar.DataSource = null;

            //Desmarcar todos los RadioButtons de los gráficos
            rdbMetodos.Checked = false;
            rdbProductos.Checked = false;
            rdbTendencia.Checked = false;

            //Apagar la interacción de los RadioButtons hasta que vuelvan a filtrar
            rdbMetodos.Enabled = false;
            rdbProductos.Enabled = false;
            rdbTendencia.Enabled = false;

            //Limpiar y ocultar los controles de los gráficos de LiveCharts
            pieChartControl.Series = null;
            pieChartControl.Visible = false;

            barChartControl.Series = null;
            barChartControl.XAxes = null;
            barChartControl.Visible = false;

            //Habilitar el dtpDesde por si quedó bloqueado por la tendencia
            dtpDesde.Enabled = true;

            MessageBox.Show("Filtros y gráficos reiniciados.", "Listo para otro informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
