namespace ClashRPG;

public partial class Form1 : Form
{
    private Login login;
    private MapManager mapaManager;
    private MusicManager musicManager;

    public Form1()
    {
        InitializeComponent();

        // Inicializar managers
        login = new Login();
        mapaManager = new MapManager(this);
        musicManager = new MusicManager();

        // Configurar eventos
        mapaManager.VolverAlLoginRequested += MostrarControlesLogin;

        // Cargar imagen de fondo
        CargarFondoLogin();

        // Centrar el panel de login
        CentrarPanelLogin();

        // Configurar pantalla completa
        ConfigurarPantallaCompleta();

        // REPRODUCIR MÚSICA AL INICIAR
        musicManager.ReproducirMusica();
    }

    private void CargarFondoLogin()
    {
        try
        {
            string rutaFondo = @"Resources\logo.png";

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

    private void ConfigurarPantallaCompleta()
    {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.ControlBox = false;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Text = "Videojuego";
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        CentrarPanelLogin();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            SalirPantallaCompleta();
            return true;
        }
        else if (keyData == Keys.M)
        {
            // Tecla M para silenciar/reactivar música
            musicManager?.ToggleMusica();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void SalirPantallaCompleta()
    {
        this.WindowState = FormWindowState.Normal;
        this.FormBorderStyle = FormBorderStyle.Sizable;
        this.ControlBox = true;
        this.MaximizeBox = true;
        this.MinimizeBox = true;
        this.Text = "Proyecto - Videojuego";
        CentrarPanelLogin();
    }

    // Detener música cuando se cierre el formulario
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        musicManager?.Dispose();
        base.OnFormClosing(e);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contraseña = txtContraseña.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
        {
            MessageBox.Show("Por favor, completa todos los campos.");
            return;
        }

        if (login.VerificarLogin(usuario, contraseña))
        {
            MessageBox.Show("¡Login exitoso!");
            MostrarMapa();
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
            MessageBox.Show("Por favor, completa todos los campos.");
            return;
        }

        if (login.RegistrarUsuario(usuario, contraseña))
        {
            MessageBox.Show("Usuario registrado!");
        }
    }

    private void MostrarMapa()
    {
        OcultarControlesLogin();

        // DETENER LA MÚSICA AL ENTRAR AL MAPA
        musicManager?.DetenerMusica();

        mapaManager.MostrarMapa();
    }

    private void OcultarControlesLogin()
    {
        panelLogin.Visible = false;
        pictureBoxFondo.Visible = false; // También ocultar el fondo
    }

    private void MostrarControlesLogin()
    {
        panelLogin.Visible = true;
        pictureBoxFondo.Visible = true; // Mostrar el fondo nuevamente

        // REANUDAR MÚSICA AL VOLVER AL LOGIN
        musicManager?.ReproducirMusica();

        CentrarPanelLogin();
    }
}