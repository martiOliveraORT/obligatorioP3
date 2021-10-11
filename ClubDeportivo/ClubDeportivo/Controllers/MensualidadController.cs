using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fachada;
using Dominio;

namespace ClubDeportivo.Controllers
{
    public class MensualidadController : Controller
    {
        FachadaMensualidad FchMensualidad = new FachadaMensualidad();   
        public ActionResult AltaPaseLibre()
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/usuario/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AltaPaseLibre(int ci)
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/usuario/Login");
            }
            var (ok, msj) = FchMensualidad.AltaMensualidadPL(ci);

            if (ok)
            {
                ViewBag.msj = msj;         
            }
            else
            {
                ViewBag.msj = msj;
            }

            return View();
        }

        public ActionResult AltaCuponera()
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/usuario/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AltaCuponera(int ci, int ingDisp)
        {
            if (Session["Logueado"] == null)
            {
                return Redirect("/usuario/Login");
            }
            var (ok, msj) = FchMensualidad.AltaMensualidadCuponera(ci, ingDisp);

            if (ok)
            {
                ViewBag.msj = msj;
            }
            else
            {
                ViewBag.msj = msj;
            }

            return View();
        }
    }
}