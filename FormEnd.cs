namespace ClashRPG;

public partial class FormEnd : Form
{
    private string[] endScreen = { @"Assets\Images\Background\Gameover.png", @"Assets\Images\Background\Mwin.png", @"Assets\Images\Background\Pwin.png", @"Assets\Images\Background\Kwin.png" };
    public FormEnd(int status)
    {
        InitializeComponent();

        if (status == 0) this.picFondo.Image = Image.FromFile(endScreen[0]);
        else this.picFondo.Image = Image.FromFile(endScreen[Global.idCharacter]);
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}