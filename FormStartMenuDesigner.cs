namespace ClashRPG
{
    partial class FormStartMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private PictureBox picLogo;
        private Button btnContinuar;
        private Button btnNuevaPartida;
        private Button btnSalir;
        private Button btnOpciones;  // botón hamburguesa

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
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnNuevaPartida = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnOpciones = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // Colores estilo Clash Royale
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
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(784, 80);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CLASH RPG";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===== LOGO (CUADRO NEGRO) =====
            this.picLogo.Location = new System.Drawing.Point(120, 100);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(540, 250);
            this.picLogo.BackColor = System.Drawing.Color.Black;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;

            // ===== FUNCIÓN PARA BOTONES =====
            void EstiloBoton(Button b, bool esSalir = false)
            {
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 3;
                b.FlatAppearance.BorderColor = dorado;
                b.ForeColor = System.Drawing.Color.White;
                b.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                b.BackColor = esSalir ? rojoSalir : azulBoton;
                b.FlatAppearance.MouseOverBackColor = esSalir ? System.Drawing.Color.DarkRed : azulHover;
            }

            // ===== BOTÓN OPCIONES (HAMBURGUESA) =====
            this.btnOpciones.Location = new System.Drawing.Point(720, 10);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(50, 45);
            this.btnOpciones.TabIndex = 5;

            this.btnOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpciones.FlatAppearance.BorderSize = 3;
            this.btnOpciones.FlatAppearance.BorderColor = dorado;
            this.btnOpciones.BackColor = azulBoton;
            this.btnOpciones.FlatAppearance.MouseOverBackColor = azulHover;

            this.btnOpciones.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.White, 4))
                {
                    g.DrawLine(pen, 10, 10, 40, 10);
                    g.DrawLine(pen, 10, 20, 40, 20);
                    g.DrawLine(pen, 10, 30, 40, 30);
                }
            };

            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);

            // ===== BOTÓN CONTINUAR =====
            this.btnContinuar.Location = new System.Drawing.Point(230, 380);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(320, 55);
            this.btnContinuar.TabIndex = 2;
            this.btnContinuar.Text = "Continuar";
            EstiloBoton(this.btnContinuar);
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);

            // ===== BOTÓN NUEVA PARTIDA =====
            this.btnNuevaPartida.Location = new System.Drawing.Point(230, 445);
            this.btnNuevaPartida.Name = "btnNuevaPartida";
            this.btnNuevaPartida.Size = new System.Drawing.Size(320, 55);
            this.btnNuevaPartida.TabIndex = 3;
            this.btnNuevaPartida.Text = "Nueva Partida";
            EstiloBoton(this.btnNuevaPartida);
            this.btnNuevaPartida.Click += new System.EventHandler(this.btnNuevaPartida_Click);

            // ===== BOTÓN SALIR =====
            this.btnSalir.Location = new System.Drawing.Point(230, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(320, 55);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            EstiloBoton(this.btnSalir, esSalir: true);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // ===== FORM =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 591);

            this.Controls.Add(this.btnOpciones);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevaPartida);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitulo);

            this.Name = "FormStartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClashRPG - Menú Principal";

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

    }
}
