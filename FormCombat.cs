using System.Configuration;

namespace ClashRPG;

public partial class FormCombat : Form
{
    // Paleta Clash Royale
    private readonly Color CRPrimaryBlue = Color.FromArgb(46, 134, 255);
    private readonly Color CRDeepNavy = Color.FromArgb(27, 35, 82);
    private readonly Color CRGold = Color.FromArgb(255, 204, 0);
    private readonly Color CRWhite = Color.White;
    public static readonly Dictionary<string, string[]> SelectionSpells = new Dictionary<string, string[]>
    {
        { "MAGO", new string[] {"Fuego", "Hielo", "Rayo"} },
        { "GUERRERO", new string[]{"Espada", "Estocada", "Carga"} },
        { "MINI P.E.K.K.A.", new string[]{"Pegar", "Pega duro", "Espadazo"} }
    };
    public static readonly Dictionary<string, string> SelectionSprite = new Dictionary<string, string>
    {
        //"FURIA", "ENREDADERA", "RAYO", "VENENO", "CURACIÓN"
        { "MAGO", @"Assets/Images/Sprites/Mago_Acy_1.png" },
        { "GUERRERO", @"Assets/Images/Sprites/kni_Acy_1.png" },
        { "MINI P.E.K.K.A.", @"Assets/Images/Sprites/mpk_Wcy_1-export.png" },
        { "FURIA", @"Assets\Images\Sprites\furia.png" },
        { "ENREDADERA", @"Assets\Images\Sprites\enredadera.png" },
        { "RAYO", @"Assets\Images\Sprites\rayo.png" },
        { "VENENO", @"Assets\Images\Sprites\veneno.png" },
        { "CURACIÓN", @"Assets\Images\Sprites\curacion.png" },
        { "Hechizo Vacio", "" }
    };
    public static readonly Dictionary<int, string> LevelEnemy = new Dictionary<int, string>
    {
        { 1, @"Assets\Images\Sprites\ske_Acy_1.png" },
        { 2, @"Assets\Images\Sprites\gob_Acy_1-export.png" },
        { 3, @"Assets\Images\Sprites\gigEi1.png" },
        { 4, @"Assets\Images\Sprites\gigda1.png" },
        { 5, @"Assets\Images\Sprites\reinad_Icy_1.png" }
    };
    public static string character = "";
    public static string[] spells = { "Hechizo Vacio", "Hechizo Vacio" };
    public static int level = 1;

    public FormCombat()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        ApplyTheme();
        WireEvents();
        Console.WriteLine(FormCombat.character + " " + FormCombat.spells[0] + " " + FormCombat.spells[1]);
    }

    private void ApplyTheme()
    {
        this.BackColor = CRDeepNavy;

        lblTitulo.ForeColor = CRGold;
        lblNivel.ForeColor = CRWhite;
        lblDescripcion.ForeColor = CRWhite;
        lblDescripcion.BackColor = Color.FromArgb(18, 24, 60);
        lblDescripcion.Padding = new Padding(10);

        StylePictureBox(picA);
        StylePictureBox(picB);

        StyleActionButton(btnAtk1);
        StyleActionButton(btnAtk2);
        StyleActionButton(btnAtk3);

        StyleImageButton(btnImg1);
        StyleImageButton(btnImg2);

        btnConfig.BackColor = Color.FromArgb(20, 28, 70);
        btnConfig.FlatAppearance.BorderColor = CRGold;
        btnConfig.FlatAppearance.BorderSize = 1;
        btnConfig.ForeColor = CRGold;

        pnlTitleUnderline.BackColor = CRGold;
    }

    private void StylePictureBox(PictureBox pb)
    {
        pb.BackColor = Color.FromArgb(16, 22, 56);
        pb.BorderStyle = BorderStyle.FixedSingle;
        pb.SizeMode = PictureBoxSizeMode.Zoom;
    }

    private void StyleActionButton(Button b)
    {
        b.BackColor = CRPrimaryBlue;
        b.ForeColor = CRWhite;
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
    }

    private void StyleImageButton(Button b)
    {
        b.BackColor = Color.FromArgb(16, 22, 56);
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 1;
        b.FlatAppearance.BorderColor = CRGold;
        b.ForeColor = CRGold;
        b.Font = new Font("Segoe UI", 9, FontStyle.Regular);
    }

    private void WireEvents()
    {
        btnConfig.Paint += BtnConfig_Paint;
        btnConfig.Click += (s, e) => ShowToast("Abrir configuración");

        btnAtk1.Click += (s, e) => ShowToast("Ataque 1 ejecutado");
        btnAtk2.Click += (s, e) => ShowToast("Ataque 2 ejecutado");
        btnAtk3.Click += (s, e) => ShowToast("Ataque 3 ejecutado");

        btnImg1.Click += (s, e) => ShowToast("Hechizo vacio");
        btnImg2.Click += (s, e) => ShowToast("Hechizo vacio");
    }

    private void BtnConfig_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using var pen = new Pen(CRGold, 2);
        var padding = 8;
        var lineSpacing = 6;
        var startX = padding;
        var endX = btnConfig.Width - padding;
        var centerY = btnConfig.Height / 2;

        g.DrawLine(pen, startX, centerY - lineSpacing - 6, endX, centerY - lineSpacing - 6);
        g.DrawLine(pen, startX, centerY, endX, centerY);
        g.DrawLine(pen, startX, centerY + lineSpacing + 6, endX, centerY + lineSpacing + 6);
    }

    private void ShowToast(string message)
    {
        lblStatus.Text = message;
        lblStatus.ForeColor = CRGold;
        lblStatus.Visible = true;

        var t = new System.Windows.Forms.Timer { Interval = 2000 };
        t.Tick += (s, e) =>
        {
            lblStatus.Visible = false;
            t.Stop();
            t.Dispose();
        };
        t.Start();
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
        FormLogin.settings.Show();
    }
}