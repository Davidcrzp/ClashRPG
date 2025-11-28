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
        ResumeLayout(false);
    }
}
