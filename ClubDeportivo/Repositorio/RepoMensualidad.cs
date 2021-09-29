using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RepoMensualidad : IRepositorio<Mensualidad>
    {
        public bool Alta(Mensualidad obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Mensualidad obj)
        {
            throw new NotImplementedException();
        }

        public List<Mensualidad> TraerTodo()
        {
            throw new NotImplementedException();
        }

        public Mensualidad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
