using System;
using System.Windows.Forms;

namespace ClashRPG
{
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
        }

        private void btnNuevaPartida_Click(object sender, EventArgs e)
        {
            // Aquí va la lógica para nueva partida
            MessageBox.Show("Nueva partida iniciada...");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
