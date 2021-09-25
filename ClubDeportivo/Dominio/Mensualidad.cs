using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Mensualidad
    {
        public int Costo { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

    }
}
