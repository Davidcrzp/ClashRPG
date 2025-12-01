using System.Data;
using MySql.Data.MySqlClient;

namespace ClashRPG;

public partial class FormLogin : Form
{
    private Global global = new Global();
    private Login login = new Login();

    public FormLogin()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Centrar el panel de login
        CenterLogin();

        // REPRODUCIR MÚSICA AL INICIAR
        LoadMusic();
    }

    private void LoadMusic()
    {
        Global.musicManager.PlayMusic();
    }

    private void CenterLogin()
    {
        if (panelLogin != null)
        {
            // BAJAR el panel significativamente
            panelLogin.Location = new Point(
                (this.ClientSize.Width - panelLogin.Width) / 2,
                this.ClientSize.Height - panelLogin.Height - 100  // ← 100px desde abajo
            );
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        CenterLogin();
    }

    // Detener música cuando se cierre el formulario
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Global.musicManager.Dispose();
        Global.effectsManager.Dispose();
        base.OnFormClosing(e);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contraseña = txtContraseña.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
        {
            MessageBox.Show("Datos incompletos\nPor favor, completa todos los campos.");
            return;
        }

        if (login.VerificarLogin(usuario, contraseña))
        {
            MessageBox.Show("¡Login exitoso!");
            StartGame();
        }
        else
        {
            MessageBox.Show("Usuario o contraseña incorrectos.");
        }
    }

    private void btnRegistrar_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contraseña = txtContraseña.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
        {
            MessageBox.Show("Datos incompletos\nPor favor, completa todos los campos.");
            return;
        }

        if (login.RegistrarUsuario(usuario, contraseña))
        {
            MessageBox.Show("Usuario registrado!");
            StartGame();
        }
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        Global.settings.Show();
    }

    public static void Volume(float vol)
    {
        Global.musicManager.Volume(vol);
    }

    private void StartGame()
    {
        try
        {
            using (MySqlConnection connection = Global.conexion.ObtenerConexion())
            {
                using (MySqlCommand command = new MySqlCommand("sp_iniciarPartida", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_nombreUsuario", txtUsuario.Text);

                    command.ExecuteScalar();
                }
            }
        }
        catch (System.Exception e)
        {
            MessageBox.Show($"Error conectando a la base de datos: {e.Message}");
            throw e;
        }
        this.Hide();
        Global.startMenu.Show();
    }

    public static void NextLvl(FormCombat form)
    {
        form = new FormCombat();
        form.Show();
    }
}