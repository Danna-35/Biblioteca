using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        private Conexión cn = new Conexión();

        public bool Guardar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreCategoria", this.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarCategoria", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", this.IdCategoria);
                cmd.Parameters.AddWithValue("@NombreCategoria", this.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "DELETE FROM Categorias WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable Consultar()
        {
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "SELECT IdCategoria, NombreCategoria, Descripcion FROM Categorias";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}