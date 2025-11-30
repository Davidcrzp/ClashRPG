namespace ClashRPG
{
    partial class FormStartMenu
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private PictureBox picLogo;
        private Button btnNuevaPartida;
        private Button btnConfig;    // ← AHORA EN MEDIO
        private Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnNuevaPartida = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // ===== COLORES =====
            var azulFondo = System.Drawing.Color.FromArgb(15, 55, 110);
            var azulBoton = System.Drawing.Color.FromArgb(20, 90, 200);
            var azulHover = System.Drawing.Color.FromArgb(35, 120, 230);
            var dorado = System.Drawing.Color.FromArgb(255, 204, 0);
            var rojoSalir = System.Drawing.Color.FromArgb(200, 40, 40);

            this.BackColor = azulFondo;

            // ===== TÍTULO =====
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = dorado;
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.Size = new System.Drawing.Size(784, 80);
            this.lblTitulo.Text = "CLASH RPG";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===== IMAGEN =====
            this.picLogo.Location = new System.Drawing.Point(120, 100);
            this.picLogo.Size = new System.Drawing.Size(540, 250);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = System.Drawing.Color.Transparent;

            this.picLogo.Image = Image.FromFile(
                @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Background\Banner.png"
            );

            // ===== MÉTODO PARA ESTILOS =====
            void EstiloBoton(Button b, bool esSalir = false)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 3;
                b.FlatAppearance.BorderColor = dorado;
                b.ForeColor = System.Drawing.Color.White;
                b.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                b.BackColor = esSalir ? rojoSalir : azulBoton;
                b.FlatAppearance.MouseOverBackColor =
                    esSalir ? System.Drawing.Color.DarkRed : azulHover;
            }

            // ============================================================
            //  BOTÓN NUEVA PARTIDA
            // ============================================================
            this.btnNuevaPartida.Location = new System.Drawing.Point(230, 445);
            this.btnNuevaPartida.Size = new System.Drawing.Size(320, 55);
            this.btnNuevaPartida.Text = "Nueva Partida";
            EstiloBoton(this.btnNuevaPartida);
            this.btnNuevaPartida.Click += new System.EventHandler(this.btnNuevaPartida_Click);

            // ============================================================
            //  BOTÓN CONFIG (entre Nueva Partida y Salir)
            // ============================================================
            this.btnConfig.Location = new System.Drawing.Point(230, 510);
            this.btnConfig.Size = new System.Drawing.Size(320, 55);
            this.btnConfig.Text = "Configuración";
            EstiloBoton(this.btnConfig);
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);

            // ============================================================
            //  BOTÓN SALIR (abajo del de Configuración)
            // ============================================================
            this.btnSalir.Location = new System.Drawing.Point(230, 575);
            this.btnSalir.Size = new System.Drawing.Size(320, 55);
            this.btnSalir.Text = "Salir del juego";
            EstiloBoton(this.btnSalir, esSalir: true);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // ===== FORM =====
            this.ClientSize = new System.Drawing.Size(784, 661);

            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevaPartida);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitulo);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClashRPG - Menú Principal";

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
