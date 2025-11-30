namespace ClashRPG;

public partial class FormStartMenu : Form
{
    private bool exit = false;

    public FormStartMenu()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
    }

    private void btnNuevaPartida_Click(object sender, EventArgs e)
    {
        // Aquí va la lógica para nueva partida
        MessageBox.Show("Nueva partida iniciada...");
        FormLogin.character.Show();
        this.Close();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        exit = true;
        Application.Exit();
    }
    private void btnConfig_Click(object sender, EventArgs e)
    {
        FormLogin.settings.Show();
    }

}
