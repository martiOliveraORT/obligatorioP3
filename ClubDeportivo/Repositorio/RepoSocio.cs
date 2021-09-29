using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Repositorio
{
    public class RepoSocio : IRepositorio<Socio>
    {
        public bool Alta(Socio obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Socio obj)
        {
            throw new NotImplementedException();
        }

        public List<Socio> TraerTodo()
        {
            throw new NotImplementedException();
        }

        public Socio BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
