using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    //usamos un enum para definir los métodos de pago disponibles, esto nos permite tener un conjunto de valores predefinidos
    //y evitar errores al ingresar el método de pago, además de facilitar la validación y el manejo de los datos relacionados con el método de pago en la aplicación.
    public enum MetodoPago
    {
        Efectivo,
        TarjetaCredito,
        TarjetaDebito,
        Transferencia,
        MercadoPago
    }
}
