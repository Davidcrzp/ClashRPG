using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClashRPG
{
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
            // SQL ASIGNAR PERSONAJE 1 Y GUARDAR VIDA DEL PERSONAJE
            Global.idCharacter = 1;
            Global.life = 100;

            Global.selectSpells.Show();
            this.Hide();
        }

        private void btnMiniPekka_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has seleccionado al MINI P.E.K.K.A.");
            Global.idCharacter = 2;
            Global.selectSpells.Show();

            this.Hide();
        }

        private void btnCaballero_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has seleccionado al CABALLERO.");
            Global.idCharacter = 3;
            Global.selectSpells.Show();
            this.Hide();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir configuración...");
            Global.settings.Show();
        }
    }
}

