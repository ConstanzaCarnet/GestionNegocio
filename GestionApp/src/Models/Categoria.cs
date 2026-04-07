using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models;
public class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; }
    public string? Descripcion { get; set; }
    //public string Estado { get; set; }

    public List<Producto> Productos { get; set; }
}

