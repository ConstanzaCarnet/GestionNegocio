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
    public partial class frmDetalleProducto : FormBase
    {
        public frmDetalleProducto()
        {
            InitializeComponent();
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdModificar, IconosUI.Editar);
            IconosUI.AplicarIconoBoton(cmdEliminar, IconosUI.Eliminar);
            IconosUI.AplicarIconoBoton(cmdGuardar, IconosUI.Guardar);
            IconosUI.AplicarIconoBoton(cmdEmail, IconosUI.Email);
        }
    }
}
