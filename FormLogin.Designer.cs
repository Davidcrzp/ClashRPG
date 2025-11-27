namespace ClashRPG
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnLogin;
        private Button btnRegistrar;
        private Label label1;
        private Label label2;
        private Panel panelLogin;
        private PictureBox pictureBoxFondo;
        private Button btnOpciones; // ← BOTÓN HAMBURGUESA

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxFondo = new PictureBox();
            this.panelLogin = new Panel();
            this.txtUsuario = new TextBox();
            this.txtContraseña = new TextBox();
            this.btnLogin = new Button();
            this.btnRegistrar = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnOpciones = new Button(); // ← BOTÓN NUEVO

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondo)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();

            // pictureBoxFondo
            this.pictureBoxFondo.Dock = DockStyle.Fill;
            this.pictureBoxFondo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxFondo.Location = new Point(0, 0);
            this.pictureBoxFondo.Name = "pictureBoxFondo";
            this.pictureBoxFondo.Size = new Size(1200, 800);

            // panelLogin
            this.panelLogin.BackColor = Color.FromArgb(240, 240, 240);
            this.panelLogin.BorderStyle = BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.btnRegistrar);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txtContraseña);
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Location = new Point(0, 0);
            this.panelLogin.Size = new Size(350, 200);

            // txtUsuario
            this.txtUsuario.Location = new Point(120, 40);
            this.txtUsuario.Size = new Size(180, 20);

            // txtContraseña
            this.txtContraseña.Location = new Point(120, 80);
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new Size(180, 20);

            // btnLogin
            this.btnLogin.BackColor = Color.SteelBlue;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(50, 130);
            this.btnLogin.Size = new Size(100, 35);
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRegistrar
            this.btnRegistrar.BackColor = Color.Gray;
            this.btnRegistrar.FlatStyle = FlatStyle.Flat;
            this.btnRegistrar.ForeColor = Color.White;
            this.btnRegistrar.Location = new Point(170, 130);
            this.btnRegistrar.Size = new Size(100, 35);
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new Point(50, 43);
            this.label1.Text = "Usuario:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new Point(35, 83);
            this.label2.Text = "Contraseña:";

            // BOTÓN OPCIONES (HAMBURGUESA)
            this.btnOpciones.Location = new Point(1120, 10);
            this.btnOpciones.Size = new Size(60, 45);
            this.btnOpciones.FlatStyle = FlatStyle.Flat;
            this.btnOpciones.FlatAppearance.BorderSize = 2;
            this.btnOpciones.FlatAppearance.BorderColor = Color.Gold;
            this.btnOpciones.BackColor = Color.FromArgb(20, 90, 200);

            this.btnOpciones.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using (var pen = new System.Drawing.Pen(Color.White, 4))
                {
                    g.DrawLine(pen, 10, 10, 50, 10);
                    g.DrawLine(pen, 10, 20, 50, 20);
                    g.DrawLine(pen, 10, 30, 50, 30);
                }
            };

            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);

            // FormLogin
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.btnOpciones);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.pictureBoxFondo);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Videojuego - Login";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondo)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
