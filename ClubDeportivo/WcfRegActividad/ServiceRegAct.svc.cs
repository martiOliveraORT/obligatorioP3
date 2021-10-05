using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio;
using Repositorio;

namespace WcfRegActividad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRegAct" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRegAct.svc o ServiceRegAct.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRegAct : IServiceRegAct
    {
        RepoRegistroActividad RepoReg = new RepoRegistroActividad();
        RepoActividad RegHoras = new RepoActividad();

        public bool AltaRegistro(DtoRegistro nvoRegistro)
        {
            if (nvoRegistro == null)
            {
                return false;
            }
            else
            {
                RegistroActividad reg = nvoRegistro.ConvertirARegistro();
                return RepoReg.Alta(reg);
            }

        }



        public IEnumerable<DtoHorario> GetTodosLosHorarios()
        {
            IEnumerable<Horario> Horas = RegHoras.BuscarHorarios("Lunes", 10);
            if (Horas == null)
            {
                return null;
            }
            else
            {
                IEnumerable<DtoHorario> list = ConvertirListaHorario(Horas);
                return list;
           
            }

        }

        private IEnumerable<DtoHorario> ConvertirListaHorario(IEnumerable<Horario> lasHrs)
        {
            List<DtoHorario> lista = new List<DtoHorario>();
            foreach (Horario hrs in lasHrs)
            {
                DtoHorario unDtoHora = new DtoHorario();
                unDtoHora.ConvertirDesdeHorario(hrs);
                lista.Add(unDtoHora);
            }
            return lista;
        }
    }


}


