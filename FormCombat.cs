namespace ClashRPG;

public partial class FormCombat : Form
{
    // Paleta Clash Royale
    private readonly Color CRPrimaryBlue = Color.FromArgb(46, 134, 255);
    private readonly Color CRDeepNavy = Color.FromArgb(27, 35, 82);
    private readonly Color CRGold = Color.FromArgb(255, 204, 0);
    private readonly Color CRWhite = Color.White;

    public FormCombat()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        ApplyTheme();
        WireEvents();
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
        StyleImageButton(btnImg3);

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

        btnImg1.Click += (s, e) => ShowToast("Botón imagen 1");
        btnImg2.Click += (s, e) => ShowToast("Botón imagen 2");
        btnImg3.Click += (s, e) => ShowToast("Botón imagen 3");
    }

    private void BtnConfig_Paint(object? sender, PaintEventArgs e)
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
}