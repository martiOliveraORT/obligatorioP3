using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio;

namespace WcfRegActividad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceRegAct" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceRegAct
    {
        [OperationContract]
        IEnumerable<DtoHorario> GetTodosLosHorarios();
        [OperationContract]
        bool AltaRegistro(DtoRegistro nvoRegistro);


    }

    public class DtoRegistro
    {
        [DataMember]
        public int Socio { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string Data
        {
            get
            {
                return string.Format(
                    "Socio: {0} Actividad: {1} Fecha: {2}", Socio, Nombre, Fecha);
            }
            set { } //QUEDA VACIO PARA QUE FUNCIONE EL SERVICIO
        }

        // CONVIERTE A UN OBJETO EN REGISTRO
        internal RegistroActividad ConvertirARegistro()
        {
            return new RegistroActividad()
            {
                Socio = this.Socio,
                Nombre = this.Nombre,
                Fecha = this.Fecha,
            };
        }

        // CONVIERTE A UN REGISTRO EN OBJETO PARA ESTA FUNCION

        internal void ConvertirDesdeRegistro (RegistroActividad reg)
        {
            Socio = reg.Socio;
            Nombre = reg.Nombre;
            Fecha = reg.Fecha;
        }
    };


    public class DtoHorario
    {
        [DataMember]
        public string Actividad { get; set;}
        [DataMember]
        public string Dia { get; set; }
        [DataMember]
        public int Hora{ get; set; }
        [DataMember]
        public string Data
        {
            get
            {
                return string.Format(
                    "Actividad: {0} Dia: {1} Hora: {2}", Actividad, Dia, Hora);
            }
            set { } //QUEDA VACIO PARA QUE FUNCIONE EL SERVICIO
        }

        // CONVIERTE A UN OBJETO EN REGISTRO
        internal Horario ConvertirAHorario()
        {
            return new Horario()
            {
                Actividad = this.Actividad,
                Dia = this.Dia,
                Hora = this.Hora,
            };
        }

        // CONVIERTE A UN REGISTRO EN OBJETO PARA ESTA FUNCION

        internal void ConvertirDesdeHorario(Horario reg)
        {
            Actividad = reg.Actividad;
            Dia = reg.Dia;
            Hora = reg.Hora;
        }
    };
}
