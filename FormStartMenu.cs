namespace ClashRPG;

public partial class FormStartMenu : Form
{
    public FormStartMenu()
    {
        InitializeComponent();
    }

    private void btnContinuar_Click(object sender, EventArgs e)
    {
        // Aquí va la lógica para continuar partida
        MessageBox.Show("Continuar partida...");
        FormLogin.map = new FormMap();
        FormLogin.map.LoadMap(FormLogin.setResolution);
        FormLogin.map.Show();
        this.Close();
    }

    private void btnNuevaPartida_Click(object sender, EventArgs e)
    {
        // Aquí va la lógica para nueva partida
        MessageBox.Show("Nueva partida iniciada...");
        FormLogin.map = new FormMap();
        FormLogin.map.LoadMap(FormLogin.setResolution);
        FormLogin.map.Show();
        this.Close();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
