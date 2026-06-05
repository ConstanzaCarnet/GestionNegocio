using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Response
{
    public class MovimientoBalanceDto
    {
        public string Fecha { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalPagos { get; set; }
    }
    public class ResumenBalanceDto
    {
        public List<MovimientoBalanceDto> DetallesGrilla { get; set; }
        public Dictionary<string, decimal> PagosPorMetodo { get; set; }
        public Dictionary<string, decimal> VentasPorCategoria { get; set; }
        public List<KeyValuePair<string, decimal>> TendenciaSeisMeses { get; set; }
    }
}
