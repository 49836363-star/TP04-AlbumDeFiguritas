namespace TP4.Models;
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

    
    public static void ConfirmarSobre(List<int> idJugadores)
    {
        List<Figuritas> coleccion = ObtenerFiguritas();

        for (int i = 0; i < idJugadores.Count; i++)
        {
            bool existe = false;
            if (coleccion.Count > 0)
            {
                int j = 0;

                do
                {
                    if (idJugadores[i] == coleccion[j].IDjugador)
                    {
                        existe = true;
                        ActualizarCantidad(idJugadores[i]);
                    }
                    else
                    {
                        j++;
                    }

                } while (!existe && j < coleccion.Count);
            }

            if (!existe)
            {
                AgregarFigurita(idJugadores[i]);
            }
        }
    }    
           
    
    public static List<Figuritas> ObtenerFiguritas()
    {
        List<Figuritas> coleccion = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Figuritas";
            coleccion = connection.Query<Figuritas>(query).ToList();
        }
        return coleccion;
    }
    public static void ActualizarCantidad(int idJugador)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"UPDATE Figuritas SET Cantidad = Cantidad + 1 WHERE IDjugador = @pIdJugador";

            connection.Execute(query, new { @pIdJugador = idJugador });
        }
    }
    public static void AgregarFigurita(int idJugador)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Figuritas (IDjugador, Cantidad) VALUES (@idJugador, 1)";

            connection.Execute(query, new { idJugador });
        }
    }

}