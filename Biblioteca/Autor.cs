using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class Autor
    {
        // Propiedades de la clase
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        private Conexión cn = new Conexión();

        // 1. METODO GUARDAR
        public bool Guardar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarAutor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Nacionalidad", this.Nacionalidad);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 2. METODO CONSULTAR
        public DataTable Consultar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "SELECT IdAutor, Nombre, Nacionalidad FROM Autores";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. METODO ACTUALIZAR
        public bool Actualizar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarAutor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAutor", this.IdAutor);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Nacionalidad", this.Nacionalidad);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. METODO ELIMINAR
        public bool Eliminar(int id)
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "DELETE FROM Autores WHERE IdAutor = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    } // <- Esta llave cierra la clase Autor
} // <- Esta llave cierra el namespace Biblioteca