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
        FachadaMensualidad fMensualidad = new FachadaMensualidad();

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
            var (mens, msjMens) = fMensualidad.BuscarMesualidad(Cedula);

            if (mens.Vencimiento > DateTime.Now)
            {
                //si esta paga, navega a ingresar actividades y ver todos los ingresos que realizó en una fecha dada en el mes corriente
                ViewBag.tieneMensualidad = true;

            }
            else
            {
                //si no esta paga, link al registro de pago para el socio y ver todos los ingresos que realizó en una fecha dada en el mes corriente
                ViewBag.tieneMensualidad = false;

            }

            ViewBag.msj = msj;
           

            return View(Socio);
        }

        public ActionResult ListarSocios()
        {
            var (socios, msj) = fSocio.ListarSocios();
            ViewBag.msj = msj;
            ViewBag.socios = socios;
            return View();
        }

        public ActionResult ListarActividades(int cedula, int mes)
        {
            List<RegistroActividad> lista = fSocio.BuscarActividadesPorSocio(cedula, mes);
            if(lista == null)
            {
                ViewBag.m = "Error en la BD";
            }
            else
            {
                ViewBag.res = lista;
                ViewBag.cant = lista.Count;
            }
            return View();
        }

    }
}