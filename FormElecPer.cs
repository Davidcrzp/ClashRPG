using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormElecPer : Form
{
    public FormElecPer()
    {
        InitializeComponent();
    }

    private void btnMago_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Has seleccionado al MAGO.");
    }

    private void btnGuerrero_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Has seleccionado al GUERRERO.");
    }

    private void btnMiniPekka_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Has seleccionado al MINI P.E.K.K.A.");
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Abrir configuración...");
    }
}