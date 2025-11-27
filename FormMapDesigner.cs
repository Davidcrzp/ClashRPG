namespace PantallaBotones
{
    partial class Form1
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

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            ClientSize = new Size(278, 244);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pantalla con Botones";
            Load += Form1_Load_1;
            ResumeLayout(false);
        }
    }
}
