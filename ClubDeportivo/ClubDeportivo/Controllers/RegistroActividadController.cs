using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfRegActividad;

namespace ClubDeportivo.Controllers
{
    public class RegistroActividadController : Controller
    {
        // GET: RegistroActividad
        ServiceRegAct service = new ServiceRegAct();
       
        public ActionResult ListaHorariosDisponibles(int cedula)
        {
            IEnumerable<DtoHorario> horarios = service.GetHorariosDisponibles();
            ViewBag.res = horarios;
            ViewBag.socio = cedula;
            return View(cedula);
        }

        public ActionResult IngresarActividad(int? ci)
        {
            int cedula = 0;
            //if (ci != null)
            //{
            //    cedula = ci ?? default(int);
            //}

            
            DtoHorario horario = new DtoHorario
            {
                Actividad = "crossfit",
                Hora = 19,
                Id = 10,
            };
            bool respuesta = service.AltaRegistro(cedula, horario);
            ViewBag.res = respuesta;
            return Redirect("/Socio/ListarSocios");
        }
    }
}