namespace ClashRPG;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.TextBox txtContraseña;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnRegistrar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panelLogin;
    private System.Windows.Forms.PictureBox pictureBoxFondo; // ← AGREGADO

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
        this.pictureBoxFondo = new System.Windows.Forms.PictureBox(); // ← AGREGADO
        this.panelLogin = new System.Windows.Forms.Panel();
        this.txtUsuario = new System.Windows.Forms.TextBox();
        this.txtContraseña = new System.Windows.Forms.TextBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnRegistrar = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondo)).BeginInit(); // ← AGREGADO
        this.panelLogin.SuspendLayout();
        this.SuspendLayout();

        // pictureBoxFondo - Fondo del login
        this.pictureBoxFondo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBoxFondo.Location = new System.Drawing.Point(0, 0);
        this.pictureBoxFondo.Name = "pictureBoxFondo";
        this.pictureBoxFondo.Size = new System.Drawing.Size(1200, 800);
        this.pictureBoxFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBoxFondo.TabIndex = 0;
        this.pictureBoxFondo.TabStop = false;

        // panelLogin - Para centrar los controles en pantalla completa
        this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.panelLogin.Controls.Add(this.label2);
        this.panelLogin.Controls.Add(this.label1);
        this.panelLogin.Controls.Add(this.btnRegistrar);
        this.panelLogin.Controls.Add(this.btnLogin);
        this.panelLogin.Controls.Add(this.txtContraseña);
        this.panelLogin.Controls.Add(this.txtUsuario);
        this.panelLogin.Location = new System.Drawing.Point(0, 0);
        this.panelLogin.Name = "panelLogin";
        this.panelLogin.Size = new System.Drawing.Size(350, 200);
        this.panelLogin.TabIndex = 1; // Cambiado de 0 a 1

        // txtUsuario
        this.txtUsuario.Location = new System.Drawing.Point(120, 40);
        this.txtUsuario.Name = "txtUsuario";
        this.txtUsuario.Size = new System.Drawing.Size(180, 20);
        this.txtUsuario.TabIndex = 0;

        // txtContraseña
        this.txtContraseña.Location = new System.Drawing.Point(120, 80);
        this.txtContraseña.Name = "txtContraseña";
        this.txtContraseña.PasswordChar = '*';
        this.txtContraseña.Size = new System.Drawing.Size(180, 20);
        this.txtContraseña.TabIndex = 1;

        // btnLogin
        this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
        this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLogin.ForeColor = System.Drawing.Color.White;
        this.btnLogin.Location = new System.Drawing.Point(50, 130);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(100, 35);
        this.btnLogin.TabIndex = 2;
        this.btnLogin.Text = "Iniciar Sesión";
        this.btnLogin.UseVisualStyleBackColor = false;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

        // btnRegistrar
        this.btnRegistrar.BackColor = System.Drawing.Color.Gray;
        this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRegistrar.ForeColor = System.Drawing.Color.White;
        this.btnRegistrar.Location = new System.Drawing.Point(170, 130);
        this.btnRegistrar.Name = "btnRegistrar";
        this.btnRegistrar.Size = new System.Drawing.Size(100, 35);
        this.btnRegistrar.TabIndex = 3;
        this.btnRegistrar.Text = "Registrar";
        this.btnRegistrar.UseVisualStyleBackColor = false;
        this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

        // label1
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(50, 43);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(54, 15);
        this.label1.TabIndex = 4;
        this.label1.Text = "Usuario:";

        // label2
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new System.Drawing.Point(35, 83);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(74, 15);
        this.label2.TabIndex = 5;
        this.label2.Text = "Contraseña:";

        // Form1 - Configuración para pantalla completa
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1200, 800);
        this.Controls.Add(this.panelLogin);
        this.Controls.Add(this.pictureBoxFondo); // ← AGREGADO - IMPORTANTE
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Videojuego - Login";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondo)).EndInit(); // ← AGREGADO
        this.panelLogin.ResumeLayout(false);
        this.panelLogin.PerformLayout();
        this.ResumeLayout(false);
    }
}
