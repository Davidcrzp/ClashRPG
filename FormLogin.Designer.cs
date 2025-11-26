namespace ClashRPG;

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
    private PictureBox pictureBoxFondo; // ← AGREGADO

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
        this.pictureBoxFondo = new PictureBox(); // ← AGREGADO
        this.panelLogin = new Panel();
        this.txtUsuario = new TextBox();
        this.txtContraseña = new TextBox();
        this.btnLogin = new Button();
        this.btnRegistrar = new Button();
        this.label1 = new Label();
        this.label2 = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondo)).BeginInit(); // ← AGREGADO
        this.panelLogin.SuspendLayout();
        this.SuspendLayout();

        // pictureBoxFondo - Fondo del login
        this.pictureBoxFondo.Dock = DockStyle.Fill;
        this.pictureBoxFondo.Location = new Point(0, 0);
        this.pictureBoxFondo.Name = "pictureBoxFondo";
        this.pictureBoxFondo.Size = new Size(1200, 800);
        this.pictureBoxFondo.SizeMode = PictureBoxSizeMode.StretchImage;
        this.pictureBoxFondo.TabIndex = 0;
        this.pictureBoxFondo.TabStop = false;

        // panelLogin - Para centrar los controles en pantalla completa
        this.panelLogin.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.panelLogin.BorderStyle = BorderStyle.FixedSingle;
        this.panelLogin.Controls.Add(this.label2);
        this.panelLogin.Controls.Add(this.label1);
        this.panelLogin.Controls.Add(this.btnRegistrar);
        this.panelLogin.Controls.Add(this.btnLogin);
        this.panelLogin.Controls.Add(this.txtContraseña);
        this.panelLogin.Controls.Add(this.txtUsuario);
        this.panelLogin.Location = new Point(0, 0);
        this.panelLogin.Name = "panelLogin";
        this.panelLogin.Size = new Size(350, 200);
        this.panelLogin.TabIndex = 1; // Cambiado de 0 a 1

        // txtUsuario
        this.txtUsuario.Location = new Point(120, 40);
        this.txtUsuario.Name = "txtUsuario";
        this.txtUsuario.Size = new Size(180, 20);
        this.txtUsuario.TabIndex = 0;

        // txtContraseña
        this.txtContraseña.Location = new Point(120, 80);
        this.txtContraseña.Name = "txtContraseña";
        this.txtContraseña.PasswordChar = '*';
        this.txtContraseña.Size = new Size(180, 20);
        this.txtContraseña.TabIndex = 1;

        // btnLogin
        this.btnLogin.BackColor = Color.SteelBlue;
        this.btnLogin.FlatStyle = FlatStyle.Flat;
        this.btnLogin.ForeColor = Color.White;
        this.btnLogin.Location = new Point(50, 130);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new Size(100, 35);
        this.btnLogin.TabIndex = 2;
        this.btnLogin.Text = "Iniciar Sesión";
        this.btnLogin.UseVisualStyleBackColor = false;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

        // btnRegistrar
        this.btnRegistrar.BackColor = Color.Gray;
        this.btnRegistrar.FlatStyle = FlatStyle.Flat;
        this.btnRegistrar.ForeColor = Color.White;
        this.btnRegistrar.Location = new Point(170, 130);
        this.btnRegistrar.Name = "btnRegistrar";
        this.btnRegistrar.Size = new Size(100, 35);
        this.btnRegistrar.TabIndex = 3;
        this.btnRegistrar.Text = "Registrar";
        this.btnRegistrar.UseVisualStyleBackColor = false;
        this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

        // label1
        this.label1.AutoSize = true;
        this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new Point(50, 43);
        this.label1.Name = "label1";
        this.label1.Size = new Size(54, 15);
        this.label1.TabIndex = 4;
        this.label1.Text = "Usuario:";

        // label2
        this.label2.AutoSize = true;
        this.label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new Point(35, 83);
        this.label2.Name = "label2";
        this.label2.Size = new Size(74, 15);
        this.label2.TabIndex = 5;
        this.label2.Text = "Contraseña:";

        // LoginForm - Configuración para pantalla completa
        this.AutoScaleDimensions = new SizeF(6F, 13F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(1200, 800);
        this.Controls.Add(this.panelLogin);
        this.Controls.Add(this.pictureBoxFondo); // ← AGREGADO - IMPORTANTE
        this.Name = "LoginForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Videojuego - Login";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondo)).EndInit(); // ← AGREGADO
        this.panelLogin.ResumeLayout(false);
        this.panelLogin.PerformLayout();
        this.ResumeLayout(false);
    }
}
