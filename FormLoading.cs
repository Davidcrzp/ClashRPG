namespace ClashRPG;

public partial class FormLoading : Form
{
    private string[] loadingScreens = { @"Assets\Images\Background\Carga1.png", @"Assets\Images\Background\Carga2.png", @"Assets\Images\Background\Carga3.png", @"Assets\Images\Background\Carga4.png", @"Assets\Images\Background\Carga5.png", @"Assets\Images\Background\Carga6.png", @"Assets\Images\Background\Carga7.png" };

    public FormLoading()
    {
        InitializeComponent();
        Random rnd = new Random();
        picLoading.Image = Image.FromFile(loadingScreens[rnd.Next(0, 7)]);
    }
}