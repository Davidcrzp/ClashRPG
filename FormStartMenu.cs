namespace ClashRPG;

public partial class FormStartMenu : Form
{
    public FormStartMenu()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
    }

    private void btnContinuar_Click(object sender, EventArgs e)
    {
        // Aquí va la lógica para continuar partida
        MessageBox.Show("Continuar partida...");
        FormLogin.combat.Show();
        this.Close();
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
        Application.Exit();
    }
}
