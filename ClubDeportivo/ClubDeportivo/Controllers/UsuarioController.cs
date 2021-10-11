using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fachada;
using Dominio;

namespace ClubDeportivo.Controllers
{
    public class UsuarioController : Controller
    {
        FachadaUsuario FchUsuario = new FachadaUsuario();

        // GET: Usuario
        [HttpGet]
        public ActionResult AltaUser()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult AltaUser(Usuario user)
        {
            string msj = FchUsuario.AltaUsuario(user.Email, user.Password);

            if (msj == "")
            {
                ViewBag.mensaje = "El usuario se registro con exito";
                user = new Usuario(); //LIMPIA EL FORMULARIO DEL VIEW
            }
            else
            {
                ViewBag.mensaje = msj;
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Usuario user = FchUsuario.Login(email, password);

            if (user == null)
            {
                ViewBag.mensaje = "Error al ingresar";
            }
            else
            {
                //queda en proceso
                ViewBag.mensaje = "Exito";
            }

            return View();
        }
    }
}