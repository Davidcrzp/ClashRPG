namespace ClashRPG;

partial class FormMap
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

<<<<<<< HEAD
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla con Botones";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
        }
=======
    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // FormMap
        // 
        ClientSize = new Size(278, 244);
        Name = "FormMap";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Pantalla con Botones";
        Load += FormMap_Load_1;
        ResumeLayout(false);
>>>>>>> 92f868ed4a2ea774b1d2f4f57b4be12d8d30a18b
    }
}

