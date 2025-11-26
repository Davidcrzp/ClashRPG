namespace ClashRPG;

public partial class FormLogin : Form
{
    private Login login;
    private MapManager mapManager;
    private MapBuilder mapBuilder;
    private MusicManager musicManager;
    private double Volume = 1;

    public FormLogin()
    {
        InitializeComponent();
        FormOptions form = new FormOptions();
        form.Show();

        // Inicializar managers
        login = new Login();
        mapManager = new MapManager(this);
        mapBuilder = new MapBuilder();
        musicManager = new MusicManager();

        // Cargar imagen de fondo
        CargarFondoLogin();

        // Centrar el panel de login
        CentrarPanelLogin();

        // Configurar pantalla completa
        Fullscreen();

        // REPRODUCIR MÚSICA AL INICIAR
        musicManager.ReproducirMusica();
        musicManager.Volume(Volume);
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

    private void Fullscreen()
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
            ExitFullscreen();
            return true;
        }
        else if (keyData == Keys.F11)
        {
            Fullscreen();
            return true;
        }
        else if (keyData == Keys.A)
        {
            if (Volume >= 1) return true;
            Volume += 0.1f;
            musicManager?.Volume(Volume);
            Console.WriteLine(Volume);
        }
        else if (keyData == Keys.B)
        {
            if (Volume <= 0) return true;
            Volume -= 0.1;
            musicManager?.Volume(Volume);
            Console.WriteLine(Volume);
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ExitFullscreen()
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

        mapManager.MostrarMapa();
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