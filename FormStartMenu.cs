using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormStartMenu : Form
{
    public FormStartMenu()
    {
        InitializeComponent();
    }

<<<<<<< HEAD
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Continuar partida...");
        }

        private void btnNuevaPartida_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nueva partida iniciada...");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menú de configuración (próximamente...)");
        }
=======
    private void btnContinuar_Click(object sender, EventArgs e)
    {
        // Aquí va la lógica para continuar partida
        MessageBox.Show("Continuar partida...");
    }

    private void btnNuevaPartida_Click(object sender, EventArgs e)
    {
        // Aquí va la lógica para nueva partida
        MessageBox.Show("Nueva partida iniciada...");
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Application.Exit();
>>>>>>> 92f868ed4a2ea774b1d2f4f57b4be12d8d30a18b
    }
}
