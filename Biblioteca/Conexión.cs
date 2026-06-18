using System;
using System.Data.SqlClient;

public class Conexión
{
    // Revisa que el Data Source coincida con tu servidor local de SQL (en tu captura anterior era localhost\SQL2025)
    private string cadena = "Data Source=localhost\\SQL2025;Initial Catalog=BibliotecaDB;Integrated Security=True";

    public SqlConnection LeerConexion()
    {
        return new SqlConnection(cadena);
    }
}