namespace ClashRPG;

public partial class FormSettings : Form
{
    private bool exit = false;
    public FormSettings()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        FormLogin.musicManager.Volume((float)trackBarVolumenMusica.Value / 100);
        FormLogin.effectsManager.Volume((float)trackBarVolumenEfectos.Value / 100);
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        exit = true;
        Application.Exit();
    }

    private void trackBarVolumenEfectos_Scroll(object sender, EventArgs e)
    {
        lblVolumenEfectos.Text = $"Volumen efectos: {trackBarVolumenEfectos.Value}%";
    }

    private void trackBarVolumenMusica_Scroll(object sender, EventArgs e)
    {
        lblVolumenMusica.Text = $"Volumen música: {trackBarVolumenMusica.Value}%";
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (!exit)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}