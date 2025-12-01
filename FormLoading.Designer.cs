namespace ClashRPG;

public partial class FormLoading : Form
{
    private System.ComponentModel.IContainer components = null;
    private PictureBox picLoading;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.FormBorderStyle = FormBorderStyle.None;

        this.picLoading = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
        this.SuspendLayout();

        // ======== FORM ========
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Vista de Fondo";

        // ======== PICTUREBOX ========
        this.picLoading.Dock = DockStyle.Fill;
        this.picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Controls.Add(this.picLoading);

        ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
        this.ResumeLayout(false);
    }
}