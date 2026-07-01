namespace TP4;
using Dapper;
using Microsoft.Data.SqlClient;
using TP4;

public class BD
{
    private static string connectionString = @"Server=localhost;Database=TP4;Integrated Security=True;TrustServerCertificate=True";

    public static List<Jugadores> AbrirSobre()
    {
        List<Jugadores> sobre = new List<Jugadores>();
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT TOP 5 * FROM Jugadores ORDER BY NEWID()";
            sobre = connection.Query<Jugadores>(query).ToList();
        }

        return sobre;
    }

    public static void ConfirmarSobre(List<Jugadores> sobre)
    {
        for(int i=0; i<sobre.Count; i++)
        {

        }       
        string query = "UPDATE Turnos SET Estado = @pNuevoEstado WHERE id=@pId";
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new{ pId = id, pNuevoEstado = nuevoEstado} );
        }
    }

}