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
    public partial class frmVentaPago : FormBase
    {
        public frmVentaPago()
        {
            InitializeComponent();
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdFinalizar, IconosUI.Aceptar);
            IconosUI.AplicarIconoBoton(cmdCancelar, IconosUI.Cancelar);
        }
    }
}
