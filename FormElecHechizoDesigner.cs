using System.Drawing;
using System.Windows.Forms;

namespace ClashRPG;

partial class FormElecHechizo
{
    private Label lblTitulo;
    private Button btnConfig;
    private Button btnContinuar;

    private Panel[] paneles = new Panel[5];
    private PictureBox[] imagenes = new PictureBox[5];
    private Label[] descripciones = new Label[5];
    private Button[] botones = new Button[5];

    private void InitializeComponent()
    {
        // FORM
        this.Text = "Selección de Hechizos";
        this.Size = new Size(1200, 700);
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = Color.FromArgb(0, 87, 183);

        // BORDE
        this.Padding = new Padding(4);
        Panel fondo = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(212, 175, 55)
        };
        this.Controls.Add(fondo);

        Panel contenido = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(0, 87, 183)
        };
        fondo.Controls.Add(contenido);

        // TÍTULO
        lblTitulo = new Label
        {
            Text = "ELIGE TUS HECHIZOS",
            Font = new Font("Verdana", 20, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(1200, 60),
            Location = new Point(0, 10)
        };
        contenido.Controls.Add(lblTitulo);

        // BOTÓN CONFIG
        btnConfig = new Button
        {
            Size = new Size(45, 45),
            Location = new Point(1130, 10),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(28, 40, 51),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            Text = "≡",
            Cursor = Cursors.Hand
        };
        btnConfig.FlatAppearance.BorderSize = 3;
        btnConfig.FlatAppearance.BorderColor = Color.FromArgb(212, 175, 55);
        btnConfig.Click += this.btnConfig_Click;
        contenido.Controls.Add(btnConfig);

        // =============================
        // PANELES DE HECHIZOS
        // =============================
        string[] nombres = { "FURIA", "ENREDADERA", "RAYO", "VENENO", "CURACIÓN" };
        string[] textos = {
            "FURIA\n\nAumenta la velocidad por un turno.",
            "ENREDADERAS\n\nQuita un turno del oponente.",
            "RAYO\n\nImpacto eléctrico que daña al enemigo.",
            "VENENO\n\nSe inflinge daño al enemigo durante toda la batalla.",
            "CURACIÓN\n\nRecupera vida."
        };

        int panelY = 100;
        int panelX = 60;
        int separacion = 220;

        for (int i = 0; i < 5; i++)
        {
            paneles[i] = CrearPanelConBordeOro(new Point(panelX + i * separacion, panelY));
            Panel slot = paneles[i].Controls[0] as Panel;
            contenido.Controls.Add(paneles[i]);

            // Recuadro negro en lugar de imagen
            imagenes[i] = CrearImagen();
            slot.Controls.Add(imagenes[i]);

            descripciones[i] = CrearTextoDescripcion(textos[i]);
            slot.Controls.Add(descripciones[i]);

            botones[i] = CrearBoton();
            botones[i].Tag = nombres[i];
            botones[i].Click += this.Hechizo_Click;
            slot.Controls.Add(botones[i]);
        }

        // BOTÓN CONTINUAR
        btnContinuar = new Button
        {
            Text = "CONTINUAR",
            Size = new Size(200, 45),
            Location = new Point(500, 520),
            BackColor = Color.FromArgb(255, 204, 0),
            ForeColor = Color.Black,
            Font = new Font("Verdana", 12, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnContinuar.FlatAppearance.BorderSize = 3;
        btnContinuar.FlatAppearance.BorderColor = Color.FromArgb(212, 175, 55);
        btnContinuar.Click += this.btnContinuar_Click;
        contenido.Controls.Add(btnContinuar);
    }

    // REUTILIZABLES
    private Panel CrearPanelConBordeOro(Point location)
    {
        Panel marco = new Panel
        {
            Size = new Size(200, 380),
            Location = location,
            BackColor = Color.FromArgb(212, 175, 55)
        };

        Panel interno = new Panel
        {
            Size = new Size(190, 360),
            Location = new Point(5, 5),
            BackColor = Color.FromArgb(28, 40, 51)
        };

        marco.Controls.Add(interno);
        return marco;
    }

    private PictureBox CrearImagen()
    {
        return new PictureBox
        {
            Size = new Size(170, 120),
            Location = new Point(10, 10),
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackColor = Color.Black // Recuadro negro
        };
    }

    private Label CrearTextoDescripcion(string texto)
    {
        return new Label
        {
            Text = texto,
            Font = new Font("Segoe UI", 9, FontStyle.Regular),
            ForeColor = Color.White,
            Location = new Point(10, 140),
            Size = new Size(160, 100)
        };
    }

    private Button CrearBoton()
    {
        var b = new Button
        {
            Text = "Seleccionar",
            Size = new Size(140, 35),
            Location = new Point(25, 270),
            BackColor = Color.FromArgb(255, 204, 0),
            ForeColor = Color.Black,
            Font = new Font("Verdana", 9, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat
        };
        b.FlatAppearance.BorderSize = 3;
        b.FlatAppearance.BorderColor = Color.FromArgb(212, 175, 55);
        return b;
    }
}

