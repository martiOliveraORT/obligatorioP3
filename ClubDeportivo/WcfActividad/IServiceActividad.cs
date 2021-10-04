using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfActividad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceActividad
    {
        [OperationContract]
        IEnumerable<DtoActividad> getActividadesDisponibles();

        [OperationContract] 
        bool registrarIngreso(DtoActividad nuevoIngreso);

    }



    [DataContract]
    public class DtoActividad
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int horaInicio { get; set; }
        [DataMember]
        public string nombre { get; set; }

    }
}
