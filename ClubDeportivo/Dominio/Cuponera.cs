using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuponera : Mensualidad
    {
        public int PrecioUnitario { get; set; }
        public List<Actividad> Actividades { get; set; }
        public int Descuento { get; set; }
    }
}
