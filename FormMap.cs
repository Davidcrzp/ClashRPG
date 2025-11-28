namespace ClashRPG;

public partial class FormMap : Form
{
    FormSettings? form;
    public static int widthScreen;
    public static int heightScreen;
    public FormMap()
    {
        InitializeComponent();
        widthScreen = Width;
        heightScreen = Height;
        this.FormBorderStyle = FormBorderStyle.None;
    }

    public void LoadMap(string setResolution)
    {
        string[] res = setResolution.Split('x');
        widthScreen = Convert.ToInt32(res[0]);
        heightScreen = Convert.ToInt32(res[1]);
        Console.WriteLine("1=" + widthScreen + " 2=" + heightScreen);

        this.ClientSize = new Size(widthScreen, heightScreen);

        // 42x24
        int tamW = widthScreen / 42; // tamaño del botón (cuadrado)
        int tamH = heightScreen / 24; // tamaño del botón (cuadrado)
        int cols = widthScreen / tamW;
        int rows = heightScreen / tamH;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Button btn = new Button();
                btn.Size = new Size(tamW, tamH);
                btn.Location = new Point(x * tamW, y * tamH);
                btn.Margin = new Padding(0);
                btn.FlatStyle = FlatStyle.Popup;
                btn.BackColor = Color.LightGray;

                this.Controls.Add(btn);
            }
        }
    }
}

