using System.Drawing;
using System.Windows.Forms;

namespace ClashRPG;

partial class FormCombat : Form
{
    private Label lblTitulo;
    private Label lblNivel;
    private Panel pnlTitleUnderline;
    private Button btnConfig;

    private PictureBox picA;
    private PictureBox picB;

    private Panel pnlDescripcionA;
    private Panel pnlDescripcionB;

    private Label lblDescripcion;   // dentro del panel A
    private Label lblDescripcion2;  // dentro del panel B

    private Button btnAtk1;
    private Button btnAtk2;
    private Button btnAtk3;

    private Button btnImg1;
    private Button btnImg2;

    private Label lblStatus;

    private System.ComponentModel.IContainer components = null;

    // Paleta Clash Royale
    private readonly Color CRPrimaryBlue = Color.FromArgb(46, 134, 255);
    private readonly Color CRDeepNavy = Color.FromArgb(27, 35, 82);
    private readonly Color CRGold = Color.FromArgb(255, 204, 0);
    private readonly Color CRWhite = Color.White;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.lblTitulo = new Label();
        this.lblNivel = new Label();
        this.pnlTitleUnderline = new Panel();
        this.btnConfig = new Button();

        this.picA = new PictureBox();
        this.picB = new PictureBox();

        this.pnlDescripcionA = new Panel();
        this.pnlDescripcionB = new Panel();

        this.lblDescripcion = new Label();
        this.lblDescripcion2 = new Label();

        this.btnAtk1 = new Button();
        this.btnAtk2 = new Button();
        this.btnAtk3 = new Button();

        this.btnImg1 = new Button();
        this.btnImg2 = new Button();

        this.lblStatus = new Label();

        this.SuspendLayout();

        // Form
        this.Text = "Combate";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.MinimumSize = new Size(900, 600);

        // lblTitulo
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Text = CharacterNameAttackAndSprite[Global.idCharacter][0];
        this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitulo.Location = new Point(20, 14);

        // lblNivel
        this.lblNivel.AutoSize = true;
        this.lblNivel.Text = "Nivel " + round;
        this.lblNivel.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
        this.lblNivel.Location = new Point(22, 54);

        // linea decoración
        this.pnlTitleUnderline.Size = new Size(180, 3);
        this.pnlTitleUnderline.Location = new Point(22, 82);

        // Config
        this.btnConfig.Size = new Size(44, 34);
        this.btnConfig.FlatStyle = FlatStyle.Flat;
        this.btnConfig.Location = new Point(this.ClientSize.Width - 64, 18);
        this.btnConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.btnConfig.Click += new EventHandler(this.btnConfig_Click);

        // picA
        this.picA.Location = new Point(22, 120);
        this.picA.Size = new Size(380, 200);
        this.picA.SizeMode = PictureBoxSizeMode.StretchImage;
        this.picA.Image = Image.FromFile(CharacterNameAttackAndSprite[Global.idCharacter][4]);

        // picB
        this.picB.Location = new Point(440, 30);
        this.picB.Size = new Size(380, 200);
        this.picB.SizeMode = PictureBoxSizeMode.StretchImage;

        // PANEL DESCRIPCIÓN A (debajo de picA)
        this.pnlDescripcionA.Location = new Point(this.picA.Left, this.picA.Bottom + 10);
        this.pnlDescripcionA.Size = new Size(this.picA.Width, 70);
        this.pnlDescripcionA.BorderStyle = BorderStyle.FixedSingle;

        // Label descripción A
        this.lblDescripcion.Dock = DockStyle.Fill;
        this.lblDescripcion.Text = "Descripción A...";
        this.lblDescripcion.Font = new Font("Segoe UI", 9F);
        this.lblDescripcion.TextAlign = ContentAlignment.MiddleLeft;
        this.lblDescripcion.ForeColor = Color.White;
        this.lblDescripcion.BackColor = Color.Transparent;

        // Agregar label A al panel A
        this.pnlDescripcionA.Controls.Add(this.lblDescripcion);

        // PANEL DESCRIPCIÓN B (debajo de picB)
        this.pnlDescripcionB.Location = new Point(this.picB.Left, this.picB.Bottom + 10);
        this.pnlDescripcionB.Size = new Size(this.picB.Width, 70);
        this.pnlDescripcionB.BorderStyle = BorderStyle.FixedSingle;

        // Label descripción B
        this.lblDescripcion2.Dock = DockStyle.Fill;
        this.lblDescripcion2.Text = "Descripción B...";
        this.lblDescripcion2.Font = new Font("Segoe UI", 9F);
        this.lblDescripcion2.TextAlign = ContentAlignment.MiddleLeft;
        this.lblDescripcion2.ForeColor = Color.White;
        this.lblDescripcion2.BackColor = Color.Transparent;

        // Agregar label B al panel B
        this.pnlDescripcionB.Controls.Add(this.lblDescripcion2);

        // botones ataque
        int btnW = 180;
        int btnH = 40;
        int margin = 22;
        int spacing = 40;
        int baseY = this.ClientSize.Height - btnH - 30;

        this.btnAtk1.Text = CharacterNameAttackAndSprite[Global.idCharacter][1];
        this.btnAtk1.Size = new Size(btnW, btnH);
        this.btnAtk1.Location = new Point(margin, baseY);
        this.btnAtk1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

        this.btnAtk2.Text = CharacterNameAttackAndSprite[Global.idCharacter][2];
        this.btnAtk2.Size = new Size(btnW, btnH);
        this.btnAtk2.Location = new Point(margin + btnW + spacing, baseY);
        this.btnAtk2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

        this.btnAtk3.Text = CharacterNameAttackAndSprite[Global.idCharacter][3];
        this.btnAtk3.Size = new Size(btnW, btnH);
        this.btnAtk3.Location = new Point(margin + 2 * (btnW + spacing), baseY);
        this.btnAtk3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

        // Botones magias (debajo de picB)
        int rightX = this.picB.Left + (this.picB.Width / 2) + 40;
        int startY = this.picB.Bottom + 20;

        this.btnImg1.Size = new Size(140, 90);
        this.btnImg1.Location = new Point(rightX, startY + 100);
        this.btnImg1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
        if (Global.idSpells[0] != 0)
            this.btnImg1.Image = Image.FromFile(SpellNameAndSprite[Global.idSpells[0]][1]);

        this.btnImg2.Size = new Size(140, 90);
        this.btnImg2.Location = new Point(rightX, startY + 200);
        this.btnImg2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
        if (Global.idSpells[1] != 0)
            this.btnImg2.Image = Image.FromFile(SpellNameAndSprite[Global.idSpells[1]][1]);

        // lblStatus
        this.lblStatus.AutoSize = true;
        this.lblStatus.Location = new Point(margin, baseY - 60);
        this.lblStatus.Visible = false;
        this.lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);

        // Agregar controles
        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.lblNivel);
        this.Controls.Add(this.pnlTitleUnderline);
        this.Controls.Add(this.btnConfig);

        this.Controls.Add(this.picA);
        this.Controls.Add(this.picB);

        this.Controls.Add(this.pnlDescripcionA);
        this.Controls.Add(this.pnlDescripcionB);

        this.Controls.Add(this.btnAtk1);
        this.Controls.Add(this.btnAtk2);
        this.Controls.Add(this.btnAtk3);

        this.Controls.Add(this.btnImg1);
        this.Controls.Add(this.btnImg2);

        this.Controls.Add(this.lblStatus);

        this.ResumeLayout(false);
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
}
