using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface Ipersonas
{

    [OperationContract]
    int NuevaPersona(Personas person);

    [OperationContract]
    int UpdatePersona(Personas person);

    [OperationContract]
    Personas BuscarPersona(int id);

    [OperationContract]
    List<Personas> mostrarPersonas();

    [OperationContract]
    int BorrarPersonas(int Iid);

}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.

[DataContract]
public class Personas 
{
    int _Id;
    string _Nombre;
    string _Apellido;
    string _Rut;
    string _Correo;

    [DataMember]
    public int Id
    {
        get
        {
            return _Id;
        }

        set
        {
            _Id = value;
        }
    }

    [DataMember]
    public string Nombre
    {
        get
        {
            return _Nombre;
        }

        set
        {
            _Nombre = value;
        }
    }

    [DataMember]
    public string Apellido
    {
        get
        {
            return _Apellido;
        }

        set
        {
            _Apellido = value;
        }
    }

    [DataMember]
    public string Rut
    {
        get
        {
            return _Rut;
        }

        set
        {
            _Rut = value;
        }
    }

    [DataMember]
    public string Correo
    {
        get
        {
            return _Correo;
        }

        set
        {
            _Correo = value;
        }
    }
}