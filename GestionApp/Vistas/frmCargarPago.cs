using GestionApp.src.DTOs.Request;
using GestionApp.src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionApp
{
    public partial class frmCargarPago : Form
    {
        public frmCargarPago()
        {
            InitializeComponent();
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new PagoService();
                
                var dto = new CrearPagoDto
                {
                    IdCliente = (int)cmbCliente.SelectedValue,
                    Monto = decimal.Parse(txtMonto.Text),
                    MetodoPago = cmbMetodo.Text
                };

                service.RegistrarPago(dto);

                MessageBox.Show("Pago registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
