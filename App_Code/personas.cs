using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class personas : Ipersonas
{
    String cadenaConexion = ConfigurationManager.ConnectionStrings["MyConexion"].ConnectionString;
    public int BorrarPersonas(int Iid)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("_CRUD_Persona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion","D");
            cmd.Parameters.AddWithValue("@Iid", Iid);

            res = cmd.ExecuteNonQuery();

            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Error en eliminar", e);
        }

        return res;
    }

    public Personas BuscarPersona(int id)
    {
        Personas person = new Personas();

        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("_CRUD_Persona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "B");
            cmd.Parameters.AddWithValue("@Iid", id);

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                if (rd.Read())
                {

                    person.Id = rd.GetInt32(0);
                    person.Nombre = rd.GetString(1);
                    person.Apellido = rd.GetString(2);
                    person.Rut = rd.GetString(3);
                    person.Correo = rd.GetString(4);
                }
            }
            else {
                throw new Exception("No existe registro");
            }
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Error en Buscar", e);
        }
        return person;
    }
    public List<Personas> mostrarPersonas()
    {
        List<Personas> persona = new List<Personas>();
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("_CRUD_persona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "L");


            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read()) 
                {
                    persona.Add(new Personas 
                    {
                        Id = rd.GetInt32(0),
                        Nombre = rd.GetString(1),
                        Apellido = rd.GetString(2),
                        Rut = rd.GetString(3),
                        Correo = rd.GetString(4)
                });
                }
            }
            else
            {
                throw new Exception("No tiene registro");  
            }
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Error en mostrar todo",e);
        }

        return persona;
    }

    public int NuevaPersona(Personas person)
    {
        int res = 0;

        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("_CRUD_persona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "C");
            cmd.Parameters.AddWithValue("@id", person.Id);
            cmd.Parameters.AddWithValue("@Nombre", person.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", person.Apellido);
            cmd.Parameters.AddWithValue("@Rut", person.Rut);
            cmd.Parameters.AddWithValue("@Correo", person.Correo);

            res = cmd.ExecuteNonQuery();

            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Error en la lectura",e);
        }
        return res;
    }

    public int UpdatePersona(Personas person)
    {
        int res = 0;

        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("_CRUD_persona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "U");
            cmd.Parameters.AddWithValue("@id", person.Id);
            cmd.Parameters.AddWithValue("@Nombre", person.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", person.Apellido);
            cmd.Parameters.AddWithValue("@Rut", person.Rut);
            cmd.Parameters.AddWithValue("@Correo", person.Correo);

            res = cmd.ExecuteNonQuery();

            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Error en la lectura", e);
        }
        return res;
    }
}
