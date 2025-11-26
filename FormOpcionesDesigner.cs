namespace ClashRPG
{
    partial class FormOpciones
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox groupSonido;
        private System.Windows.Forms.GroupBox groupPantalla;

        private System.Windows.Forms.TrackBar trackBarVolumenEfectos;
        private System.Windows.Forms.TrackBar trackBarVolumenMusica;
        private System.Windows.Forms.TrackBar trackBarBrillo;

        private System.Windows.Forms.ComboBox comboResolucion;

        private System.Windows.Forms.Label lblVolumenEfectos;
        private System.Windows.Forms.Label lblVolumenMusica;
        private System.Windows.Forms.Label lblBrillo;
        private System.Windows.Forms.Label lblResolucion;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

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
            this.trackBarBrillo = new System.Windows.Forms.TrackBar();

            this.comboResolucion = new System.Windows.Forms.ComboBox();

            this.lblVolumenEfectos = new System.Windows.Forms.Label();
            this.lblVolumenMusica = new System.Windows.Forms.Label();
            this.lblBrillo = new System.Windows.Forms.Label();
            this.lblResolucion = new System.Windows.Forms.Label();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenEfectos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenMusica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrillo)).BeginInit();

            // =============================
            // ESTILO FORM
            // =============================
            this.BackColor = azulFondo;
            this.ForeColor = dorado;
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

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
            // GRUPO PANTALLA
            // =============================
            this.groupPantalla.Text = "Configuración de pantalla";
            this.groupPantalla.Location = new System.Drawing.Point(20, 190);
            this.groupPantalla.Size = new System.Drawing.Size(450, 180);
            this.groupPantalla.BackColor = grisPiedra;
            this.groupPantalla.ForeColor = dorado;

            // --- Brillo etiqueta ---
            this.lblBrillo.Location = new System.Drawing.Point(20, 30);
            this.lblBrillo.Text = "Brillo: 50%";
            this.lblBrillo.AutoSize = true;

            // --- Brillo TrackBar ---
            this.trackBarBrillo.Location = new System.Drawing.Point(20, 60);
            this.trackBarBrillo.Maximum = 100;
            this.trackBarBrillo.Value = 50;
            this.trackBarBrillo.TickFrequency = 10;
            this.trackBarBrillo.Scroll += new System.EventHandler(this.trackBarBrillo_Scroll);

            // --- Resolución etiqueta ---
            this.lblResolucion.Location = new System.Drawing.Point(240, 30); // al lado derecho del brillo
            this.lblResolucion.Text = "Resolución:";
            this.lblResolucion.AutoSize = true;

            // --- Combo resolución ---
            this.comboResolucion.Location = new System.Drawing.Point(240, 60); // debajo de la etiqueta
            this.comboResolucion.Size = new System.Drawing.Size(180, 25);
            this.comboResolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResolucion.Items.AddRange(new object[]
            {
                "1280x720",
                "1920x1080",
                "2560x1440",
                "3840x2160"
            });
            this.comboResolucion.SelectedIndex = 1; // por defecto Full HD
            this.comboResolucion.SelectedIndexChanged += new System.EventHandler(this.comboResolucion_SelectedIndexChanged);

            this.groupPantalla.Controls.Add(this.lblBrillo);
            this.groupPantalla.Controls.Add(this.trackBarBrillo);
            this.groupPantalla.Controls.Add(this.lblResolucion);
            this.groupPantalla.Controls.Add(this.comboResolucion);

            // =============================
            // BOTONES
            // =============================
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(260, 390);
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.BackColor = azulClaro;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(370, 390);
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;

            // FORM
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.groupSonido);
            this.Controls.Add(this.groupPantalla);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Text = "Opciones - Clash Royale Style";

            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenEfectos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumenMusica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrillo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
