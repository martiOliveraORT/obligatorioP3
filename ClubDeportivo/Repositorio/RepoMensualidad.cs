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
    public class RepoMensualidad : IRepositorio<Mensualidad>
    {
        public bool Alta(Mensualidad obj)
        {
            bool success = false;
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @""
            };
            //SETEAMOS LOS DATOS CON SU RESPECTIVA VARIABLE
            cmd.Parameters.AddWithValue("@", obj);
            cmd.Connection = cn;

            //INTENTAMOS EJECUTAR LA QUERY CORRECTAMENTE
            //SI EL RESULTADO DE LA FILA ES 1, GUARDAMOS LA VARIABLE Y RETORNAMOS TRUE
            //SI FALLA TRAEMOS Y MSOTRAMOS EL ERROR
            try
            {
                manejadorConexion.AbrirConexion(cn);
                int rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    success = true;
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                // CERRAMOS LA CONEXION
                manejadorConexion.CerrarConexion(cn);
            }
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Mensualidad obj)
        {
            throw new NotImplementedException();
        }

        public List<Mensualidad> TraerTodo()
        {
            throw new NotImplementedException();
        }

        public Mensualidad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
