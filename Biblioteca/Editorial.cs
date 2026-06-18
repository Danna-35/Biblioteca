using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class Editorial
    {
        public int IdEditorial { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        private Conexión cn = new Conexión();

        public bool Guardar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "INSERT INTO Editoriales (Nombre, Pais) VALUES (@Nombre, @Pais)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Pais", this.Pais);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable Consultar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "SELECT IdEditorial, Nombre, Pais FROM Editoriales";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // (Luego le sumamos Editar y Eliminar de la misma forma que Autores)
    }
}
