<<<<<<< HEAD
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PantallaBotones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarPantallaConBotones();
        }

        private void LlenarPantallaConBotones()
        {
            int anchoPantalla = 1280;
            int altoPantalla = 720;

            this.ClientSize = new Size(anchoPantalla, altoPantalla);

            int tam = 30; // tamaño del botón cuadrado
            int cols = anchoPantalla / tam;
            int rows = altoPantalla / tam;

            Button btnConfig = null;

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

                    // Detectar el botón en la esquina superior derecha
                    if (y == 0 && x == cols - 1)
                    {
                        btnConfig = btn;
                    }
                }
            }

            if (btnConfig != null)
            {
                btnConfig.Paint += BtnConfig_Paint;
                btnConfig.Click += BtnConfig_Click;
                btnConfig.BackColor = Color.White; // lo diferenciamos un poco
            }
        }

        private void BtnConfig_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int margen = 5;
            int espacio = 7;
            Pen pen = new Pen(Color.Black, 2);

            // Dibujar 3 líneas horizontales dentro del botón
            for (int i = 0; i < 3; i++)
            {
                int y = margen + i * espacio;
                e.Graphics.DrawLine(pen, margen, y, btn.Width - margen, y);
            }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir menú de configuración");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // vacío, lo usa el Designer
        }
    }
}
=======
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

>>>>>>> 92f868ed4a2ea774b1d2f4f57b4be12d8d30a18b
