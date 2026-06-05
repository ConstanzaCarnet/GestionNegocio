using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace GestionApp
{
    /// <summary>
    /// Formulario base del que heredan todas las ventanas de la aplicación.
    /// Se encarga de asignar el icono de la aplicación a cada ventana sin
    /// tener que repetir la línea en los 19 formularios.
    /// </summary>
    public class FormBase : Form
    {
        public FormBase()
        {
            // En tiempo de diseño no cargamos el recurso para no romper el diseñador de Visual Studio.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            try
            {
                Icon = Properties.Resources.AppIcon;
            }
            catch
            {
                // Si por algún motivo no se pudo cargar el icono, la ventana
                // simplemente usa el icono por defecto en vez de fallar.
            }
        }
    }

    /// <summary>
    /// Glifos vectoriales (fuente "Segoe MDL2 Assets", incluida en Windows 10/11)
    /// usados como iconos en las columnas-botón de las grillas. Al ser vectoriales
    /// se ven nítidos en cualquier resolución y no requieren archivos de imagen.
    /// Los códigos hexadecimales corresponden a la tabla de "Segoe MDL2 Assets".
    /// </summary>
    internal static class IconosUI
    {
        public static readonly string Editar = ((char)0xE70F).ToString();          // lápiz (Edit)
        public static readonly string Eliminar = ((char)0xE74D).ToString();        // tacho de basura (Delete)
        public static readonly string Ver = ((char)0xE890).ToString();             // ver detalle (View)
        public static readonly string Agregar = ((char)0xE710).ToString();         // signo + (Add)
        public static readonly string Quitar = ((char)0xE738).ToString();          // signo - (Remove)
        public static readonly string Cancelar = ((char)0xE711).ToString();        // cruz / cancelar (Cancel)
        // Iconos para botones de acción comunes
        public static readonly string Guardar = ((char)0xE74E).ToString();         // disquete (Save)
        public static readonly string Buscar = ((char)0xE721).ToString();          // lupa (Search)
        public static readonly string Filtrar = ((char)0xE71C).ToString();         // embudo (Filter)
        public static readonly string Descargar = ((char)0xE896).ToString();       // flecha abajo (Download)
        public static readonly string Exportar = ((char)0xEE71).ToString();        // exportar / compartir (Share)
        public static readonly string Refrescar = ((char)0xE72C).ToString();       // recargar (Refresh)
        public static readonly string Email = ((char)0xE715).ToString();           // sobre (Mail)
        public static readonly string Enviar = ((char)0xE724).ToString();          // avión de papel (Send)
        public static readonly string Probar = ((char)0xE768).ToString();          // play (Test)
        public static readonly string SeleccionarTodo = ((char)0xE8B3).ToString(); // seleccionar todo (SelectAll)
        public static readonly string Lista = ((char)0xE8FD).ToString();           // lista (List)
        public static readonly string Personas = ((char)0xE716).ToString();        // personas (Contact)
        public static readonly string Continuar = ((char)0xE72A).ToString();       // flecha adelante (Forward)
        public static readonly string Aceptar = ((char)0xE73E).ToString();         // tilde (CheckMark)
        public static readonly string Cambiar = ((char)0xE8AB).ToString();         // intercambiar (Switch)
        public static readonly string Pago = ((char)0xE825).ToString();            // banco (Bank/Payment)

        /// <summary>
        /// Convierte una columna-botón de una grilla en un botón con icono:
        /// asigna el glifo como texto y la fuente de iconos centrada.
        /// </summary>
        public static void AplicarIcono(DataGridViewButtonColumn columna, string glifo, string tooltip = null)
        {
            columna.Text = glifo;
            columna.UseColumnTextForButtonValue = true;

            if (columna.DefaultCellStyle == null)
                columna.DefaultCellStyle = new DataGridViewCellStyle();

            columna.DefaultCellStyle.Font = new Font("Segoe MDL2 Assets", 11F);
            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (tooltip != null)
                columna.ToolTipText = tooltip;
        }

        /// <summary>
        /// Agrega un icono a un botón normal (Button). Como la fuente del botón se
        /// usa para su texto, el glifo no puede ir como texto; en su lugar se dibuja
        /// en una pequeña imagen que se coloca a la izquierda de la etiqueta.
        /// </summary>
        public static void AplicarIconoBoton(Button boton, string glifo, int tamano = 16)
        {
            boton.Image = CrearImagenGlifo(glifo, tamano, boton.ForeColor);
            boton.ImageAlign = ContentAlignment.MiddleCenter;
            boton.TextAlign = ContentAlignment.MiddleCenter;
            boton.TextImageRelation = TextImageRelation.ImageBeforeText;

            // un pequeño respiro entre el icono y el borde
            if (boton.Padding.Left < 4)
                boton.Padding = new Padding(4, boton.Padding.Top, boton.Padding.Right, boton.Padding.Bottom);
        }

        /// <summary>
        /// Dibuja un glifo de "Segoe MDL2 Assets" en un mapa de bits transparente,
        /// del color indicado. Así obtenemos un icono nítido sin archivos de imagen.
        /// </summary>
        public static Bitmap CrearImagenGlifo(string glifo, int tamano, Color color)
        {
            var bmp = new Bitmap(tamano, tamano);
            bmp.SetResolution(96, 96);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.Clear(Color.Transparent);

                using (var fuente = new Font("Segoe MDL2 Assets", tamano * 0.72f, GraphicsUnit.Pixel))
                using (var pincel = new SolidBrush(color))
                {
                    var formato = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(glifo, fuente, pincel, new RectangleF(0, 0, tamano, tamano), formato);
                }
            }
            return bmp;
        }
    }
}
