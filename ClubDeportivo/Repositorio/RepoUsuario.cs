using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RepoUsuario : IRepositorio<Usuario>
    {
        public bool Alta(Usuario obj)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            bool resultado = false;

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"INSERT INTO Usuarios (email, password) VALUES (@email, @pass)"
            };

            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@pass", obj.Password);

            try
            {
                manejadorConexion.AbrirConexion(cn);
                int afectadas = cmd.ExecuteNonQuery();

                if (afectadas == 1)
                {
                resultado = true;
                }
                else
                {
                resultado = false;
                }
                return resultado;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }

        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> TraerTodo()
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            Usuario user = null;

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM Usuarios WHERE email = @email"
            };

            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new Usuario
                    {
                        Email = (string)reader["email"],
                        Password = (string)reader["password"]
                    };
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return user;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }
    }
}
