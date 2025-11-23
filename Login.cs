using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ClashRPG;

public class Login
{
    private Conexion conexion;

    public Login()
    {
        conexion = new Conexion();
    }

    // Registrar nuevo usuario usando SP
    public bool RegistrarUsuario(string usuario, string contraseña)
    {
        try
        {
            using (MySqlConnection connection = conexion.ObtenerConexion())
            {
                using (MySqlCommand command = new MySqlCommand("sp_RegistrarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_usuario", usuario);
                    command.Parameters.AddWithValue("@p_contraseña", contraseña);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            MessageBox.Show("Este usuario ya existe. Elige otro nombre.");
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error registrando usuario: {ex.Message}");
            return false;
        }
    }

    // Verificar login usando SP
    public bool VerificarLogin(string usuario, string contraseña)
    {
        try
        {
            using (MySqlConnection connection = conexion.ObtenerConexion())
            {
                using (MySqlCommand command = new MySqlCommand("sp_VerificarLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_usuario", usuario);
                    command.Parameters.AddWithValue("@p_contraseña", contraseña);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error verificando login: {ex.Message}");
            return false;
        }
    }

    // Verificar si usuario existe usando SP
    public bool UsuarioExiste(string usuario)
    {
        try
        {
            using (MySqlConnection connection = conexion.ObtenerConexion())
            {
                using (MySqlCommand command = new MySqlCommand("sp_UsuarioExiste", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_usuario", usuario);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error verificando usuario: {ex.Message}");
            return false;
        }
    }

    // Obtener ID del usuario usando SP
    public int ObtenerIdUsuario(string usuario)
    {
        try
        {
            using (MySqlConnection connection = conexion.ObtenerConexion())
            {
                using (MySqlCommand command = new MySqlCommand("sp_ObtenerIdUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // ← CORREGIDO
                    command.Parameters.AddWithValue("@p_usuario", usuario);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error obteniendo ID: {ex.Message}");
            return -1;
        }
    }
}