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
    public class RepoActividad : IRepositorio<Actividad>
    {
        public bool Alta(Actividad obj)
        {
            bool success = false;
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"INSERT INTO Actividades (nombre, edadMin, edadMax, duracion, cupos) VALUES (@nom, @eMin, @eMax, @dur, @cupos)"
            };
            //SETEAMOS LOS DATOS CON SU RESPECTIVA VARIABLE
            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@eMin", obj.EdadMin);
            cmd.Parameters.AddWithValue("@eMax", obj.EdadMax);
            cmd.Parameters.AddWithValue("@dur", obj.Duracion);
            cmd.Parameters.AddWithValue("@cupos", obj.CuposDisponibles);

            // INTENTAMOS EJECUTAR LA QUERY CORRECTAMENTE
            // SI EL RESULTADO DE LA FILA ES 1, GUARDAMOS LA VARIABLE Y RETURNAMOS TRUE
            // SI FALLA TRAEMOS Y MOSTRAMOS EL ERROR
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
            bool success = false;
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"DELETE FROM Actividades WHERE id = @id"
            };
            //SETEAMOS LOS DATOS CON SU RESPECTIVA VARIABLE
            cmd.Parameters.AddWithValue("@id", id);
             
            // INTENTAMOS EJECUTAR LA QUERY CORRECTAMENTE
            // SI EL RESULTADO DE LA FILA ES 1, GUARDAMOS LA VARIABLE Y RETURNAMOS TRUE
            // SI FALLA TRAEMOS Y MOSTRAMOS EL ERROR
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

        public bool Modificacion(Actividad obj)
        {
            bool success = false;
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"UPDATE Actividades SET nombre = @nom,edadMin = @eMin, edadMax = @eMax, duracion = @dur, cupos = @cupos WHERE id = @id"
            };
            //SETEAMOS LOS DATOS CON SU RESPECTIVA VARIABLE
            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@eMin", obj.EdadMin);
            cmd.Parameters.AddWithValue("@eMax", obj.EdadMax);
            cmd.Parameters.AddWithValue("@dur", obj.Duracion);
            cmd.Parameters.AddWithValue("@cupos", obj.CuposDisponibles);

            // INTENTAMOS EJECUTAR LA QUERY CORRECTAMENTE
            // SI EL RESULTADO DE LA FILA ES 1, GUARDAMOS LA VARIABLE Y RETURNAMOS TRUE
            // SI FALLA TRAEMOS Y MOSTRAMOS EL ERROR
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

        public List<Actividad> TraerTodo()
        {
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            List<Actividad> acts = new List<Actividad>();

            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
               
                CommandText = @"SELECT * FROM Actividades "
            };
            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader filas = cmd.ExecuteReader();
                while (filas.Read())
                {
                    //GUARDO LA INFORMACION DE LA TABLA 
                    acts.Add(new Actividad
                    {
                        Id = (int)filas["id"],
                        Nombre = (string)filas["Nombre"],
                        EdadMin = (int)filas["edadMin"],
                        EdadMax = (int)filas["edadMax"],
                        CuposDisponibles = (int)filas["cupos"],

                    });
                }
                return acts;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return acts;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }

        public Actividad BuscarPorId(int id)
        {
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();
            Actividad act = null;

            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM Actividades WHERE id = @act "
            };
            cmd.Parameters.AddWithValue("@act", id);
            


            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    act = new Actividad
                    {
                        Id = (int)reader["id"],
                        Nombre = (string)reader["Nombre"],
                        EdadMin = (int)reader["edadMin"],
                        EdadMax = (int)reader["edadMax"],
                        CuposDisponibles = (int)reader["cupos"],
                    };
                }
                return act;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return act;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }

        public Actividad BusarPorNombre(string n)
        {
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();
            // Paso el parametro a MIN para mantener el criterio de busqeda siempre en MIN
            n = n.ToLower();
            Actividad act = null;


            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM Actividades WHERE nombre = @act "
            };
            cmd.Parameters.AddWithValue("@act", n);



            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    act = new Actividad
                    {
                        Id = (int)reader["id"],
                        Nombre = (string)reader["Nombre"],
                        EdadMin = (int)reader["edadMin"],
                        EdadMax = (int)reader["edadMax"],
                        CuposDisponibles = (int)reader["cupos"],
                    };
                }
                return act;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return act;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }



        // SECCION CORRESPONDEA HORARIOS
        // Devuelve todos los horario segun el nombre de actividad
        public List<Horario> BuscarHorarios(string dia, int hora)
        {
            //INICIO LA CONEXION CON LA BD
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();
            List<Horario> horas = new List<Horario>();


            //CREAMOS LA QUERY A EJECUTAR LUEGO
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM Horarios WHERE hora = @hora AND dia = @dia "
            };

            cmd.Parameters.AddWithValue("@dia", dia);
            cmd.Parameters.AddWithValue("@hora", hora);
            // SETEAMOS EL PARAMETO CONNECTION CON EL valor del cn
            // Esto es IMPORTANTE!!!! si no, no se conecta
            cmd.Connection = cn;



            try
            {
                if (manejadorConexion.AbrirConexion(cn)){
                    SqlDataReader filas = cmd.ExecuteReader();
                    while (filas.Read())
                    {
                        // SOLO ME GUARDO DIA Y HORA
                        horas.Add(new Horario
                        {
                            Actividad = (string)filas["actividad"],
                            Dia = (string)filas["dia"],
                            Hora = (int)filas["hora"],

                        });
                    } 
                }
                return horas;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return horas;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }


       
    }
}
