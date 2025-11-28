using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormSelectCharacter : Form
{
    public FormSelectCharacter()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.None;
    }

    private void btnMago_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Has seleccionado al MAGO.");
        FormCombat.character = "MAGO";
        this.Hide();
        FormLogin.spells.Show();
    }

    private void btnGuerrero_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Has seleccionado al GUERRERO.");
        FormCombat.character = "GUERRERO";
        this.Hide();
        FormLogin.spells.Show();
    }

    private void btnMiniPekka_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Has seleccionado al MINI P.E.K.K.A.");
        FormCombat.character = "MINI P.E.K.K.A.";
        this.Hide();
        FormLogin.spells.Show();
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Abrir configuración...");
    }
}