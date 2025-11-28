namespace ClashRPG
{
    partial class FormSettings
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox groupSonido;
        private System.Windows.Forms.GroupBox groupPantalla;

        private System.Windows.Forms.TrackBar trackBarVolumenEfectos;
        private System.Windows.Forms.TrackBar trackBarVolumenMusica;

        private System.Windows.Forms.Label lblVolumenEfectos;
        private System.Windows.Forms.Label lblVolumenMusica;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Colores Clash Royale
            var azulFondo = System.Drawing.Color.FromArgb(0, 31, 63);
            var azulClaro = System.Drawing.Color.FromArgb(0, 91, 187);
            var dorado = System.Drawing.Color.FromArgb(255, 215, 0);
            var grisPiedra = System.Drawing.Color.FromArgb(46, 46, 46);

            this.groupSonido = new System.Windows.Forms.GroupBox();
            this.groupPantalla = new System.Windows.Forms.GroupBox();

            this.trackBarVolumenEfectos = new System.Windows.Forms.TrackBar();
            this.trackBarVolumenMusica = new System.Windows.Forms.TrackBar();

            this.lblVolumenEfectos = new System.Windows.Forms.Label();
            this.lblVolumenMusica = new System.Windows.Forms.Label();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenEfectos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenMusica)).BeginInit();

            // =============================
            // ESTILO GENERAL DEL FORM
            // =============================
            this.BackColor = azulFondo;
            this.ForeColor = dorado;
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Configuracion - Clash Royale";

            // =============================
            // GRUPO SONIDO
            // =============================
            this.groupSonido.Text = "Configuración de sonido";
            this.groupSonido.Location = new System.Drawing.Point(20, 20);
            this.groupSonido.Size = new System.Drawing.Size(450, 150);
            this.groupSonido.BackColor = grisPiedra;
            this.groupSonido.ForeColor = dorado;

            // --- Etiqueta Volumen Efectos ---
            this.lblVolumenEfectos.Location = new System.Drawing.Point(20, 30);
            this.lblVolumenEfectos.Text = "Volumen efectos: 50%";
            this.lblVolumenEfectos.AutoSize = true;

            // --- Trackbar Volumen Efectos ---
            this.trackBarVolumenEfectos.Location = new System.Drawing.Point(20, 60);
            this.trackBarVolumenEfectos.Maximum = 100;
            this.trackBarVolumenEfectos.Value = 50;
            this.trackBarVolumenEfectos.TickFrequency = 10;
            this.trackBarVolumenEfectos.Scroll += new System.EventHandler(this.trackBarVolumenEfectos_Scroll);

            // --- Etiqueta Volumen Música ---
            this.lblVolumenMusica.Location = new System.Drawing.Point(240, 30);
            this.lblVolumenMusica.Text = "Volumen música: 50%";
            this.lblVolumenMusica.AutoSize = true;

            // --- Trackbar Volumen Música ---
            this.trackBarVolumenMusica.Location = new System.Drawing.Point(240, 60);
            this.trackBarVolumenMusica.Maximum = 100;
            this.trackBarVolumenMusica.Value = 50;
            this.trackBarVolumenMusica.TickFrequency = 10;
            this.trackBarVolumenMusica.Scroll += new System.EventHandler(this.trackBarVolumenMusica_Scroll);

            this.groupSonido.Controls.Add(this.lblVolumenEfectos);
            this.groupSonido.Controls.Add(this.trackBarVolumenEfectos);
            this.groupSonido.Controls.Add(this.lblVolumenMusica);
            this.groupSonido.Controls.Add(this.trackBarVolumenMusica);

            // =============================
            // GRUPO PANTALLA (SIN BRILLO)
            // =============================
            this.groupPantalla.Text = "Configuración de pantalla";
            this.groupPantalla.Location = new System.Drawing.Point(20, 190);
            this.groupPantalla.Size = new System.Drawing.Size(450, 120);
            this.groupPantalla.BackColor = grisPiedra;
            this.groupPantalla.ForeColor = dorado;

            // =============================
            // BOTONES
            // =============================
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(260, 330);
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.BackColor = azulClaro;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new System.Drawing.Point(370, 330);
            this.btnCerrar.Size = new System.Drawing.Size(100, 40);
            this.btnCerrar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.btnSalir.Text = "Salir";
            this.btnSalir.Location = new System.Drawing.Point(20, 330); // esquina inferior izquierda
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // =============================
            // AGREGAR TODO AL FORM
            // =============================
            this.Controls.Add(this.groupSonido);
            this.Controls.Add(this.groupPantalla);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSalir);

            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenEfectos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenMusica)).EndInit();
            this.ResumeLayout(false);
        }
    }
}