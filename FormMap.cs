namespace ClashRPG;

public partial class FormMap : Form
{
    public static int widthScreen;
    public static int heightScreen;

    public FormMap()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        widthScreen = Width;
        heightScreen = Height;
    }

    public void LoadMap(string setResolution)
    {
        string[] res = setResolution.Split('x');
        widthScreen = Convert.ToInt32(res[0]);
        heightScreen = Convert.ToInt32(res[1]);

        this.ClientSize = new Size(widthScreen, heightScreen);

        // 42x24
        int tamW = widthScreen / 42; // tamaño del botón (cuadrado)
        int tamH = heightScreen / 24; // tamaño del botón (cuadrado)
        int cols = widthScreen / tamW;
        int rows = heightScreen / tamH;

        // Primera fila de botones
        for (int y = 0; y < 2; y++)
        {
            for (int x = 0; x < cols - 2; x++)
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

        // ===== Botón Configuración con estilo Clash Royale =====
        Button btnSettings = new Button();
        btnSettings.Size = new Size(tamW * 2, tamH * 2);
        btnSettings.Location = new Point((cols - 2) * tamW, 0);
        btnSettings.Text = "≡";
        btnSettings.Font = new Font("Segoe UI", 24F, FontStyle.Bold);

        // Colores estilo Clash Royale
        var azulBoton = Color.FromArgb(20, 90, 200);
        var azulHover = Color.FromArgb(35, 120, 230);
        var dorado = Color.FromArgb(255, 204, 0);

        btnSettings.FlatStyle = FlatStyle.Flat;
        btnSettings.FlatAppearance.BorderSize = 3;
        btnSettings.FlatAppearance.BorderColor = dorado;
        btnSettings.ForeColor = Color.White;
        btnSettings.BackColor = azulBoton;
        btnSettings.FlatAppearance.MouseOverBackColor = azulHover;

        btnSettings.Margin = new Padding(0);
        btnSettings.Click += new EventHandler(this.btnSettings_Click);

        this.Controls.Add(btnSettings);

        // Resto de botones
        for (int y = 2; y < rows; y++)
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

    private void btnSettings_Click(object? sender, EventArgs e)
    {
        FormLogin.settings.Show();
    }
}
