using MySql.Data.MySqlClient;

namespace ClashRPG;

public class Connection
{
    private string connectionString;

    public Connection()
    {
        this.connectionString = @"Server=localhost;Database=base de datos;Uid=root;Pwd=;";
    }

    public bool TestConnection()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MessageBox.Show("¡Conexión exitosa a 'base de datos'!");
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error de conexión: {ex.Message}");
            return false;
        }
    }

    public MySqlConnection ObtenerConexion()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}