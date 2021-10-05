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
    public class RepoRegistroActividad : IRepositorio<RegistroActividad>
    {
        public bool Alta(RegistroActividad obj)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            bool resultado = false;

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"INSERT INTO RegistrosActividad (socio, actividad, fecha) VALUES (@ced, @nomAct, @fecha)"
            };
            cmd.Parameters.AddWithValue("@ced", obj.Socio);
            cmd.Parameters.AddWithValue("@nomAct", obj.Nombre);
            cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
  
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
            catch (Exception ex)
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

        public bool Modificacion(RegistroActividad obj)
        {
            throw new NotImplementedException();
        }

        public List<RegistroActividad> TraerTodo()
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            List<RegistroActividad> ingresos = new List<RegistroActividad>();

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                //LOS TRAIGOS DE MANERA DESC PARA QUE LA ULTIMA FECHA VENGA PRIMERA
                CommandText = @"SELECT * FROM RegistrosActividad ORDER BY fecha DESC"
            };
            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader filas = cmd.ExecuteReader();
                while (filas.Read())
                {
                    //GUARDO LA INFORMACION DE LA TABLA 
                    ingresos.Add(new RegistroActividad
                    {
                        Socio = (int)filas["socio"],
                        Nombre = (string)filas["Actividad"],
                        Fecha = (DateTime)filas["fecha"],
   
                    });
                }
                return ingresos;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ingresos;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }

        public RegistroActividad BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        //  FUNCIONALIDAD QUE SUSPLANTARIA EL BUSCAR POR ID, PRECISAMOS LA COMBINACION
        public RegistroActividad BusquedaEspecifica(int socio, String act, DateTime fecha)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();
            RegistroActividad registro = null;

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM RegistroActividad WHERE socio = @socio AND actividad = @act AND fecha = @fecha"
            };
            cmd.Parameters.AddWithValue("@socio", socio);
            cmd.Parameters.AddWithValue("@act", act);
            cmd.Parameters.AddWithValue("@fecha", fecha);


            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    registro = new RegistroActividad
                    {
                        Socio = (int)reader["socio"],
                        Nombre = (string)reader["actividad"],
                        Fecha = (DateTime)reader["fecha"]
                    };
                }
                return registro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return registro;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }
    }
}
