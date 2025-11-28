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

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        // Oculta sin cerrar el form
        this.Hide();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "¿Seguro que deseas salir del juego?",
            "Confirmar salida",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
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
        // Evita que se destruya el formulario (cuando se presione X)
        this.Hide();
        e.Cancel = true;
    }
}
