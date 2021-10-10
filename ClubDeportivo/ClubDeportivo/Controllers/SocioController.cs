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
            var (socio, msj) = fSocio.EliminarSocio(Cedula);

            if(socio == null)
            {
                ViewBag.mensaje = msj;
            }
            else
            {
                ViewBag.mensaje = msj;
            }

            return View(socio);
        }

        public ActionResult BuscarSocio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Detalle(int Cedula)
        {
            var (Socio, msj) = fSocio.BuscarSocio(Cedula);
            //buscar mensualidad de socio
            //si esta paga, navega a ingresar actividades y ver todos los ingresos que realizó en una fecha dada en el mes corriente

            //si no esta paga, link al registro de pago para el socio y ver todos los ingresos que realizó en una fecha dada en el mes corriente

            ViewBag.msj = msj;
            ViewBag.mensualidad = true;
            ViewBag.ingresoAct = true;
            ViewBag.ingresosSocio = true;

            return View(Socio);
        }

        public ActionResult ListarSocios()
        {
            var (socios, msj) = fSocio.ListarSocios();
            ViewBag.msj = msj;
            ViewBag.socios = socios;
            return View();
        }

    }
}