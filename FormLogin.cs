namespace ClashRPG;

public partial class FormLogin : Form
{
    private Login login;
    private FormMap map;
    public static MusicManager musicManager = new MusicManager();
    public static MusicManager effectsManager = new MusicManager();

    public FormLogin()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        FormSettings form = new FormSettings();
        form.Show();

        // Inicializar managers
        login = new Login();
        map = new FormMap();
        map.Show();

        // Cargar imagen de fondo
        CargarFondoLogin();

        // Centrar el panel de login
        CentrarPanelLogin();

        // REPRODUCIR MÚSICA AL INICIAR
        musicManager.PlayMusic();
    }

    private void CargarFondoLogin()
    {
        try
        {
            string rutaFondo = @"Assets\Images\Background\Login.png";

            if (File.Exists(rutaFondo))
            {
                pictureBoxFondo.Image = Image.FromFile(rutaFondo);
            }
            else
            {
                // Si no encuentra la imagen, crear fondo de color
                pictureBoxFondo.BackColor = Color.LightGray;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error cargando fondo: {ex.Message}");
            pictureBoxFondo.BackColor = Color.LightGray;
        }
    }

    private void CentrarPanelLogin()
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
        CentrarPanelLogin();
    }

    // Detener música cuando se cierre el formulario
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to close without saving?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            e.Cancel = true;
        }
        musicManager.Dispose();
        effectsManager.Dispose();
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
        }
    }

    private void StartGame()
    {
        // DETENER LA MÚSICA AL ENTRAR AL MAPA
        musicManager?.StopMusic();
        this.Hide();

        map.Show();
    }

    private void MostrarControlesLogin()
    {
        panelLogin.Visible = true;
        pictureBoxFondo.Visible = true; // Mostrar el fondo nuevamente

        // REANUDAR MÚSICA AL VOLVER AL LOGIN
        musicManager?.PlayMusic();

        CentrarPanelLogin();
    }
}