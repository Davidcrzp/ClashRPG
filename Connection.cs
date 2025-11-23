using Npgsql;
using System;
using System.Windows.Forms;

namespace ClashRPG
{
    public class Conexion
    {
        private string connectionString;

        public Conexion()
        {
            // Cadena de conexión de Supabase (ajústala con tus datos reales)
            this.connectionString = @"Host=TU-HOST.supabase.co;
                                      Port=5432;
                                      Database=postgres;
                                      Username=TU-USUARIO;
                                      Password=TU-PASSWORD;
                                      SslMode=Require";
        }

        public bool ProbarConexion()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("¡Conexión exitosa a Supabase/Postgres!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
                return false;
            }
        }

        public NpgsqlConnection ObtenerConexion()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
