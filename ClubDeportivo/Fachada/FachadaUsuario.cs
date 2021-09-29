using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Fachada
{
    public class FachadaUsuario
    {
        public static string AltaUsuario(string email, string password)
        {
            string msj = ValidarCamposAltaUsuario(email, password);
            
            if (msj == "")
            {
                Usuario user = new Usuario()
                {
                    Email = email,
                    Password = password
                };
                RepoUsuario repoUser = new RepoUsuario();
                
                if (!repoUser.Alta(user))
                {
                    msj = "Error al cargar usuario";
                }
            }

            return msj;
        }

        public static string ValidarCamposAltaUsuario(string email, string password)
        {
            string msj = "";

            if (email == "" || password == "")
            {
                msj = "Deben completarse los campos";
            }
            else if (!ValidarEmail(email))
            {
                msj = "Formato de e-mail invalido";
            }
            else if (!ValidarPassword(password))
            {
                msj = "La contraseña no cumple con los requisitos de seguridad";
            }

            return msj;
        }

        //formato email: un @ y punto luego del mismo
        public static bool ValidarEmail(string email)
        {
            bool ok = false;         
            int cantArroba = 0;
            bool punto = false;

            for (int i = 0; i < email.Length; i++)
            {
               
                if (email[i].ToString() == "@")
                {
                    cantArroba++;
                    for (int j = i+1; j < email.Length; j++)
                    {
                        if (email[j].ToString() == ".")
                        {
                            punto = true;
                        }
                    }
                }
            }
            if (cantArroba == 1 && punto)
            {
                ok = true;
            }

            return ok;
        }

        //contraseña con al menos 6 caracteres que incluyan letras mayúsculas y minúsculas(al menos una de cada una) y dígitos(0 al 9)
        public static bool ValidarPassword(string password)
        {
            bool ok = false;
            bool mayus = false;
            bool minus = false;
            bool num = false;

            string letrasMayus = "ABCDEFGHIJKLMNÑOPKRSTUVWXYZ";
            string letrasMin = letrasMayus.ToLower();
            string numeros = "0123456789";

            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < letrasMayus.Length; j++)
                {
                    if (letrasMayus[j] == password[i])
                    {
                        mayus = true;
                    }
                }
            }

            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < letrasMin.Length; j++)
                {
                    if (letrasMin[j] == password[i])
                    {
                        minus = true;
                    }
                }
            }

            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < numeros.Length; j++)
                {
                    if (numeros[j] == password[i])
                    {
                        num = true;
                    }
                }
            }

            if (password.Length >= 6 && mayus && minus && num)
            {
                ok = true;
            }

            return ok;
        }
    }
}
