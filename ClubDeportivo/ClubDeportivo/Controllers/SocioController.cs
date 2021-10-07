using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fachada;
using Dominio;

namespace ClubDeportivo.Controllers
{
    public class SocioController : Controller
    {
        FachadaSocio fSocio = new FachadaSocio();

        [HttpGet]
        public ActionResult AltaSocio()
        {
            return View(new Socio());
        }

        [HttpPost]
        public ActionResult AltaSocio(Socio socio)
        {
            socio.FechaIngreso = DateTime.Now;
            socio.Estado = true;

            string msj = fSocio.AltaSocio(socio);

            ViewBag.mensaje = msj;

            socio = new Socio(); //Limpia el formulario del view

            return View(socio);
        }

        public ActionResult BajarSocio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BajarSocio(int Cedula)
        {
            Socio socio = fSocio.EliminarSocio(Cedula);

            if(socio == null)
            {
                ViewBag.mensaje = "No se pudo eliminar el socio";
            }
            else
            {
                ViewBag.mensaje = "Se borro correctamente";
            }

            return View(socio);
        }


    }
}