using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClashRPG
{
    public class Conexion
    {
        private string connectionString;

        public Conexion()
        {
            this.connectionString = @"Server=localhost;Database=base de datos;Uid=root;Pwd=;";
        }

        public bool ProbarConexion()
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
}