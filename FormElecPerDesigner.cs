using System.Windows.Forms;
using System.Drawing;

namespace ClashRPG;

partial class FormElecPer
{
    private PictureBox imgMago;
    private PictureBox imgGuerrero;
    private PictureBox imgMiniPekka;

    private Button btnMago;
    private Button btnGuerrero;
    private Button btnMiniPekka;

    private Label lblMago;
    private Label lblGuerrero;
    private Label lblMiniPekka;

    private Panel panelMago;
    private Panel panelGuerrero;
    private Panel panelMiniPekka;

    private Label lblTitulo;

    private Button btnConfig;

    private void InitializeComponent()
    {
        // FORM
        this.Text = "Selección de Personaje";
        this.Size = new Size(1100, 520);
        this.FormBorderStyle = FormBorderStyle.None; // Quitamos borde para poner uno dorado propio
        this.BackColor = Color.FromArgb(0, 87, 183);

        // ---- BORDE DORADO DEL FORM ----
        this.Padding = new Padding(4);
        Panel fondo = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(212, 175, 55) // ORO
        };
        this.Controls.Add(fondo);

        Panel contenido = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(0, 87, 183)
        };
        fondo.Controls.Add(contenido);

        // ---- TÍTULO ----
        lblTitulo = new Label
        {
            Text = "ELIGE TU CAMPEÓN",
            Font = new Font("Verdana", 20, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(1100, 60),
            Location = new Point(0, 10)
        };
        contenido.Controls.Add(lblTitulo);

        // ---- BOTÓN CONFIGURACIÓN ----
        btnConfig = new Button
        {
            Size = new Size(45, 45),
            Location = new Point(1030, 10),
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
        // PANEL POSICIONES
        // =============================
        int panelY = 100;
        int panelX1 = 60;
        int panelX2 = 390;
        int panelX3 = 720;

        // PANEL 1 - MAGO
        panelMago = CrearPanelConBordeOro(new Point(panelX1, panelY));
        Panel slotMago = panelMago.Controls[0] as Panel;
        contenido.Controls.Add(panelMago);

        imgMago = CrearImagen();
        imgMago.Image = Image.FromFile("Assets/Images/Sprites/Mago.png");  
        slotMago.Controls.Add(imgMago);

        lblMago = CrearTextoDescripcion("MAGO\n\nPoder místico a distancia. Hechizos devastadores.");
        slotMago.Controls.Add(lblMago);

        btnMago = CrearBoton();
        btnMago.Click += this.btnMago_Click;
        slotMago.Controls.Add(btnMago);

        // PANEL 2 - MINI P.E.K.K.A
        panelMiniPekka = CrearPanelConBordeOro(new Point(panelX2, panelY));
        Panel slotPekka = panelMiniPekka.Controls[0] as Panel;
        contenido.Controls.Add(panelMiniPekka);

        imgMiniPekka = CrearImagen();
        imgMiniPekka.Image = Image.FromFile("Assets/Images/Sprites/Mini_pekka.png");  
        slotPekka.Controls.Add(imgMiniPekka);

        lblMiniPekka = CrearTextoDescripcion("MINI P.E.K.K.A\n\nGolpes extremadamente poderosos.");
        slotPekka.Controls.Add(lblMiniPekka);

        btnMiniPekka = CrearBoton();
        btnMiniPekka.Click += this.btnMiniPekka_Click;
        slotPekka.Controls.Add(btnMiniPekka);

        // PANEL 3 - GUERRERO
        panelGuerrero = CrearPanelConBordeOro(new Point(panelX3, panelY));
        Panel slotGuerrero = panelGuerrero.Controls[0] as Panel;
        contenido.Controls.Add(panelGuerrero);

        imgGuerrero = CrearImagen();
        imgGuerrero.Image = Image.FromFile("Assets/Images/Sprites/Caballero.png");
        slotGuerrero.Controls.Add(imgGuerrero);

        lblGuerrero = CrearTextoDescripcion("GUERRERO\n\nFuerza y resistencia en combate cuerpo a cuerpo.");
        slotGuerrero.Controls.Add(lblGuerrero);

        btnGuerrero = CrearBoton();
        btnGuerrero.Click += this.btnGuerrero_Click;
        slotGuerrero.Controls.Add(btnGuerrero);
    }

    // =====================================
    // ELEMENTOS CON BORDES DORADOS
    // =====================================

    private Panel CrearPanelConBordeOro(Point location)
    {
        Panel marco = new Panel
        {
            Size = new Size(300, 380),
            Location = location,
            BackColor = Color.FromArgb(212, 175, 55) // ORO
        };

        Panel interno = new Panel
        {
            Size = new Size(290, 360),
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
            Size = new Size(270, 160),
            Location = new Point(10, 10),
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackColor = Color.Black,
            BorderStyle = BorderStyle.None,

            // Truco: borde dorado con Panel interior
        };
    }

    private Label CrearTextoDescripcion(string texto)
    {
        return new Label
        {
            Text = texto,
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.White,
            Location = new Point(10, 180),
            Size = new Size(260, 100)
        };
    }

    private Button CrearBoton()
    {
        var b = new Button
        {
            Text = "Seleccionar",
            Size = new Size(140, 35),
            Location = new Point(75, 300),
            BackColor = Color.FromArgb(255, 204, 0),
            ForeColor = Color.Black,
            Font = new Font("Verdana", 10, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat
        };

        b.FlatAppearance.BorderSize = 3;
        b.FlatAppearance.BorderColor = Color.FromArgb(212, 175, 55);

        return b;
    }
}
