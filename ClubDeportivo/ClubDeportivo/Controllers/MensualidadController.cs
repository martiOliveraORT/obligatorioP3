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
        // GET: Mensualidad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AltaPaseLibre()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AltaPaseLibre(int ci)
        {
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
            return View();
        }
        [HttpPost]
        public ActionResult AltaCuponera(int ci, int ingDisp)
        {
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