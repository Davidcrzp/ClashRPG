using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClashRPG
{
    public partial class FormSelectCharacter : Form
    {
        public FormSelectCharacter()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnMago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has seleccionado al MAGO.");
            FormCombat.SetCharacter("MAGO");   // asigna nombre + idPersonajeActual = 3
            EjecutarSPIniciarPartida(FormCombat.idPersonajeActual);
            this.Hide();
            FormLogin.spells.Show();
        }

        private void btnGuerrero_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has seleccionado al GUERRERO.");
            FormCombat.SetCharacter("GUERRERO"); // asigna nombre + idPersonajeActual = 1
            EjecutarSPIniciarPartida(FormCombat.idPersonajeActual);
            this.Hide();
            FormLogin.spells.Show();
        }

        private void btnMiniPekka_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has seleccionado al MINI P.E.K.K.A.");
            FormCombat.SetCharacter("MINI P.E.K.K.A."); // asigna nombre + idPersonajeActual = 2
            EjecutarSPIniciarPartida(FormCombat.idPersonajeActual);
            this.Hide();
            FormLogin.spells.Show();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir configuración...");
        }

        /// <summary>
        /// Ejecuta el Stored Procedure sp_IniciarPartida para iniciar partida
        /// </summary>
      private void EjecutarSPIniciarPartida(int idPersonaje)
{
    try
    {
        string connectionString = @"Server=localhost;Database=base de datos;Uid=root;Pwd=;";

        using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_IniciarPartida", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_id_personaje", idPersonaje);

            conn.Open();
            var result = cmd.ExecuteScalar(); // devuelve id_partida
            Console.WriteLine($"Partida iniciada con ID: {result}");

            // Guardar el id_partida en una variable global si lo necesitas
            
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al iniciar partida: " + ex.Message);
    }
}

    }
}

