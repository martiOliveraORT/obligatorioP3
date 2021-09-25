using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cuponera : Mensualidad
    {
        public int PrecioUnitario { get; set; }
        public List<Actividad> Actividades { get; set; }
        public int Descuento { get; set; }

    }
}
