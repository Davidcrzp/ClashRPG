namespace ClashRPG;

partial class FormEnd
{
    private System.ComponentModel.IContainer components = null;
    private PictureBox picFondo;
    private Button btnSalir;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.FormBorderStyle = FormBorderStyle.None;

        this.picFondo = new System.Windows.Forms.PictureBox();
        this.btnSalir = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.picFondo)).BeginInit();
        this.SuspendLayout();

        // ========= FORM =========
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Vista de Fondo";

        this.picFondo.Dock = DockStyle.Fill;
        this.picFondo.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Controls.Add(this.picFondo);

        this.btnSalir.Text = "Salir";
        this.btnSalir.Size = new Size(100, 40);
        this.btnSalir.Location = new Point(this.ClientSize.Width - 115, this.ClientSize.Height - 55);
        this.btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.btnSalir.BackColor = Color.DarkRed;
        this.btnSalir.ForeColor = Color.White;
        this.btnSalir.FlatStyle = FlatStyle.Flat;
        this.btnSalir.FlatAppearance.BorderSize = 2;
        this.btnSalir.Click += new EventHandler(this.btnSalir_Click);

        // Agregar controles
        this.Controls.Add(this.btnSalir);
        this.Controls.Add(this.picFondo);

        ((System.ComponentModel.ISupportInitialize)(this.picFondo)).EndInit();
        this.ResumeLayout(false);
    }
}
