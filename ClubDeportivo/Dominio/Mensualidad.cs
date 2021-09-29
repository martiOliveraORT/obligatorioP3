using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Mensualidad
    {
        public int Costo { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
