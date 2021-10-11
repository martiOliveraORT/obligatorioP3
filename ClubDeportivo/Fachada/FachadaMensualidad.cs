using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Fachada
{
    public class FachadaMensualidad
    {
        public (bool, string) AltaMensualidadPL(int ci)
        {
            bool ok = false;
            string msj;
            RepoMensualidad repoMensualidad = new RepoMensualidad();
            FachadaSocio fachadaSocio = new FachadaSocio();
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaVencimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
            Socio socio = fachadaSocio.ValidarSocio(ci);            
            decimal costo;
            Mensualidad mens = repoMensualidad.BuscarPorId(ci);
            if (mens != null)
            {
                if (mens.Vencimiento < fechaHoy)
                {
                    if (socio != null)
                    {
                        var (valorCuota, porcDescuento, antig) = repoMensualidad.TraerValoresPaseLibre();
                        costo = CalcularCostoPL(porcDescuento, valorCuota, antig, socio.FechaIngreso);
                        PaseLibre ps = new PaseLibre()
                        { 
                             Costo = costo,
                             Fecha = fechaHoy,
                             Socio = socio,
                             Vencimiento = fechaVencimiento,
                             Descuento = porcDescuento
                        };
                        ok = repoMensualidad.AltaPaseLibre(ps); 
                    }

                    if (ok)
                    {
                        msj = "Se registro el pase libre con exito";
                    }
                    else
                    {
                        msj = "No fue posible registrar el pase libre";
                    }
                }
                else
                {
                    msj = "Este usuario ya tiene una mensualidad activa";
                }
            }
            else
            {
                msj = "La cedula ingresada no existe en el registro";
            }

            return (ok, msj);
        }

        public (bool, string) AltaMensualidadCuponera(int ci, int ingresosDisp)
        {
            bool ok = false;
            string msj;
            if (ingresosDisp < 8 || ingresosDisp > 60)
            {
                msj = "La cantidad de actividades debe ser mayor a 8 y menor de 60";
            }
            else
            {
                RepoMensualidad repoMensualidad = new RepoMensualidad();
                FachadaSocio fachadaSocio = new FachadaSocio();
                DateTime fechaHoy = DateTime.Today;
                DateTime fechaVencimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                Socio socio = fachadaSocio.ValidarSocio(ci);
                decimal costo;
                Mensualidad mens = repoMensualidad.BuscarPorId(ci);

                if (mens != null)
                {
                    if (mens.Vencimiento < fechaHoy)
                    {
                        if (socio != null)
                        {
                            var (precioUnitario, porcDescuento, cantAct) = repoMensualidad.TraerValoresCuponera();
                            costo = CalcularCostoCup(porcDescuento, precioUnitario, cantAct, ingresosDisp);
                            Cuponera cup = new Cuponera()
                            {
                                 Costo = costo,
                                 Fecha = fechaHoy,
                                 Socio = socio,
                                 Vencimiento = fechaVencimiento,
                                 IngresosDisponibles = ingresosDisp,
                                 Descuento = porcDescuento
                            };
                            ok = repoMensualidad.AltaCuponera(cup);                
                        }

                        if (ok)
                        {
                            msj = "Se registro la cuponera con exito";
                        }
                        else
                        {
                            msj = "No fue posible registrar la cuponera";
                        }
                    }
                    else
                    {
                        msj = "Este usuario ya tiene una mensualidad activa";
                    }
                }
                else
                {
                    msj = "La cedula ingresada no existe en el registro";
                }
            }
            return (ok, msj);
        }

        public (Mensualidad, string) BuscarMesualidad(int cedula)
        {
            string msj;
            Mensualidad mens;

            RepoMensualidad repo = new RepoMensualidad();
            mens = repo.BuscarPorId(cedula);

            if (mens == null)
            {
                msj = "Error al buscar en BD";
            }
            else
            {
                msj = "OK";
            }
            return (mens, msj);
        }

        public bool RestarCupoCuponera(int cedula)
        {
            bool res;

            RepoMensualidad repo = new RepoMensualidad();
            res = repo.RestarCupo(cedula);

            return res;
        }

        public static decimal CalcularCostoPL(decimal porcDescuento, decimal valorCuota, int antig, DateTime fchIng)
        {
            decimal costo;         
            DateTime hoy = DateTime.Today;
            DateTime fchAntig = fchIng.AddMonths(antig);
            if (hoy > fchAntig)
            {
                decimal descuento = (porcDescuento * valorCuota) / 100;
                costo = valorCuota - descuento;
            }
            else
            {
                costo = valorCuota;
            }
            return costo;
        }

        public static decimal CalcularCostoCup(decimal porcDescuento, decimal precioUnitario, int cantAct, int ingDisp)
        {
            decimal costo;
            decimal precioTotal = precioUnitario * ingDisp;
            if (ingDisp > cantAct)
            {
                decimal descuento = (porcDescuento * precioTotal) / 100;
                costo = precioTotal - descuento;
            }
            else
            {
                costo = precioTotal;
            }
            return costo;
        }
    }
}
