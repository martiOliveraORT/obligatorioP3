﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RepoSocio : IRepositorio<Socio>
    {
        public bool Alta(Socio obj)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            bool resultado = false;

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"INSERT INTO Socios (cedula, nombre, fechaNac, fechaIng, estado) VALUES (@ced, @nom, @fechaNac, @fechaIng, @estado)"
            };
            int estado;
            cmd.Parameters.AddWithValue("@ced", obj.Cedula);
            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@fechaNac", obj.FechaNac);
            cmd.Parameters.AddWithValue("@fechaIng", obj.FechaIngreso);
            if (obj.Estado)
            {
                estado = 0;
            }
            else
            {
                estado = 1;
            }
            cmd.Parameters.AddWithValue("@fechaIng", estado);

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
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            bool resultado = false;
            //Se busca al socio, y se le cambia el estado a false (bit 1)
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"UPDATE Socios SET estado = 1 WHERE cedula = @ced"
            };

            cmd.Parameters.AddWithValue("@ced", id);
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

        public bool Modificacion(Socio obj)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            bool resultado = false;

            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"UPDATE Socios SET nombre = @nom, fechaNac = @fechNac WHERE cedula = @ced"
            };
            cmd.Parameters.AddWithValue("@nom", obj.Nombre);
            cmd.Parameters.AddWithValue("@fechaNac", obj.FechaNac);
            cmd.Parameters.AddWithValue("@ced", obj.Cedula);
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

        public List<Socio> TraerTodo()
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            List<Socio> socios = new List<Socio>();

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM Socios ORDER BY nombre ASC, cedula DESC"
            };
            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader filas = cmd.ExecuteReader();
                bool estado = false;
                while (filas.Read())
                {
                    if ((int)filas["estado"] == 0)
                    {
                        estado = true;
                    }
                    else if ((int)filas["estado"] == 1)

                    {
                        estado = false;
                    }
                    socios.Add(new Socio
                    {
                        Cedula = (int)filas["cedula"],
                        Nombre = (string)filas["nombre"],
                        FechaNac = (DateTime)filas["fechaNac"],
                        FechaIngreso = (DateTime)filas["fechaIng"],
                        Estado = estado
                    });
                }
                return socios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return socios;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }


        }

        public Socio BuscarPorId(int id)
        {
            //Crear conexion
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.CrearConexion();

            Socio socio = null;

            //Preparar consulta
            SqlCommand cmd = new SqlCommand
            {
                CommandText = @"SELECT * FROM Socios WHERE cedula = @ced"
            };
            cmd.Parameters.AddWithValue("@ced", id);
            try
            {
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader reader = cmd.ExecuteReader();
                bool estado = false;
                if (reader.Read())
                {
                    //Pregunto si el atributo de la base de dato esta en true/false (0 / 1)

                    if((int)reader["estado"] == 0)
                    {
                        estado = true;
                    }else if((int)reader["estado"] == 1)

                    {
                        estado = false;
                    }
                    socio = new Socio
                    {
                        Cedula = (int)reader["cedula"],
                        Nombre = (string)reader["nombre"],
                        FechaNac = (DateTime)reader["fechaNac"],
                        FechaIngreso = (DateTime)reader["fechaIng"],
                        Estado = estado
                    };
                }
                return socio;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return socio;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
            }
        }
    }
}