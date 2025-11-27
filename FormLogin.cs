using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace ClashRPG
{
    public partial class FormLogin : Form
    {
        private Login login;
        private MapManager mapManager;
        private FormMap map;
        public static MusicManager musicManager = new MusicManager();
        public static MusicManager effectsManager = new MusicManager();

        public FormLogin()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            FormOptions form = new FormOptions();
            form.Show();

            login = new Login();
            mapManager = new MapManager(this);
            map = new FormMap();
            map.Show();

            CargarFondoLogin();
            CentrarPanelLogin();

            musicManager.PlayMusic();
        }

        private void CargarFondoLogin()
        {
            try
            {
                string rutaFondo = @"Assets\Images\Background\Login.png";

                if (File.Exists(rutaFondo))
                    pictureBoxFondo.Image = Image.FromFile(rutaFondo);
                else
                    pictureBoxFondo.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando fondo: {ex.Message}");
                pictureBoxFondo.BackColor = Color.LightGray;
            }
        }

        private void CentrarPanelLogin()
        {
            if (panelLogin != null)
            {
                panelLogin.Location = new Point(
                    (this.ClientSize.Width - panelLogin.Width) / 2,
                    this.ClientSize.Height - panelLogin.Height - 100
                );
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CentrarPanelLogin();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close without saving?",
                "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

            musicManager.Dispose();
            effectsManager.Dispose();
            base.OnFormClosing(e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Datos incompletos\nPor favor, completa todos los campos.");
                return;
            }

            if (login.VerificarLogin(usuario, contraseña))
            {
                MessageBox.Show("¡Login exitoso!");
                StartGame();
            }
            else
                MessageBox.Show("Usuario o contraseña incorrectos.");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Datos incompletos\nPor favor, completa todos los campos.");
                return;
            }

            if (login.RegistrarUsuario(usuario, contraseña))
                MessageBox.Show("Usuario registrado!");
        }

        private void StartGame()
        {
            musicManager?.StopMusic();
            this.Hide();
            mapManager.MostrarMapa();
        }

        private void MostrarControlesLogin()
        {
            panelLogin.Visible = true;
            pictureBoxFondo.Visible = true;

            musicManager?.PlayMusic();

            CentrarPanelLogin();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opciones del Login (próximamente...)");
        }
    }
}
