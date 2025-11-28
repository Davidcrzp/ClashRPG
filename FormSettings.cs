namespace ClashRPG;

public partial class FormSettings : Form
{
    public FormSettings()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        if (comboResolution.SelectedItem != null)
            lblResolution.Text = $"Resolución: {comboResolution.SelectedItem}";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        FormLogin.musicManager.Volume((float)trackBarVolumenMusica.Value / 100);
        FormLogin.effectsManager.Volume((float)trackBarVolumenEfectos.Value / 100);
        if (FormLogin.setResolution != comboResolution.SelectedItem.ToString())
            FormLogin.ReloadMap();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void trackBarVolumenEfectos_Scroll(object sender, EventArgs e)
    {
        lblVolumenEfectos.Text = $"Volumen efectos: {trackBarVolumenEfectos.Value}%";
    }

    private void trackBarVolumenMusica_Scroll(object sender, EventArgs e)
    {
        lblVolumenMusica.Text = $"Volumen música: {trackBarVolumenMusica.Value}%";
    }

    private void comboResolution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboResolution.SelectedItem != null)
            lblResolution.Text = $"Resolución: {comboResolution.SelectedItem}";
    }

    public string getResolution()
    {
        return comboResolution.SelectedItem.ToString();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        this.Hide();
        e.Cancel = true;
    }
}