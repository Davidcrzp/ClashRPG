namespace ClashRPG;

public partial class FormMap : Form
{
    public FormMap()
    {
        InitializeComponent();
        this.Load += FormMap_Load;
    }

    private void FormMap_Load(object sender, EventArgs e)
    {
        LlenarPantallaConBotones();
    }

    private void LlenarPantallaConBotones()
    {
        int anchoPantalla = 1280;
        int altoPantalla = 720;

        this.ClientSize = new Size(anchoPantalla, altoPantalla);

        int tam = 30; // tamaño del botón (cuadrado)
        int cols = anchoPantalla / tam;
        int rows = altoPantalla / tam;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Button btn = new Button();
                btn.Size = new Size(tam, tam);
                btn.Location = new Point(x * tam, y * tam);
                btn.Margin = new Padding(0);
                btn.FlatStyle = FlatStyle.Popup;
                btn.BackColor = Color.LightGray;

                this.Controls.Add(btn);
            }
        }
    }

    private void FormMap_Load_1(object sender, EventArgs e)
    {

    }
}

