namespace ClashRPG;

public partial class FormLogin : Form
{
    private Login login = new Login();
    private FormStartMenu startMenu = new FormStartMenu();
    public static FormSettings settings = new FormSettings();
    public static MusicManager musicManager = new MusicManager();
    public static MusicManager effectsManager = new MusicManager();
    public static FormMap map = new FormMap();
    public static string setResolution = "";

    public FormLogin()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        setResolution = settings.getResolution();
        settings.Show();

        map = new FormMap();
        map.LoadMap(setResolution);
        map.Show();

        var combat = new FormCombat();
        combat.Show();

        // Cargar imagen de fondo
        LoadBackgroundImg();

        // Centrar el panel de login
        CenterLogin();

        // REPRODUCIR MÚSICA AL INICIAR
        musicManager.PlayMusic();
    }

    private void LoadBackgroundImg()
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
            StartGame();
        }
    }

    private void StartGame()
    {
        musicManager?.StopMusic();
        this.Hide();
        startMenu.Show();
    }

    public static void ReloadMap()
    {
        map.Dispose();
        map = new FormMap();
        setResolution = settings.getResolution();
        map.LoadMap(setResolution);
        map.Show();
    }
}