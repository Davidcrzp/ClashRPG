using System.Drawing;
using System.Windows.Forms;

namespace ClashRPG
{
    partial class FormCombat : Form
    {
        private Label lblTitulo;
        private Label lblNivel;
        private Panel pnlTitleUnderline;
        private Button btnConfig;

        private PictureBox picA;
        private PictureBox picB;
        private Label lblDescripcion;

        private Button btnAtk1;
        private Button btnAtk2;
        private Button btnAtk3;

        private Button btnImg1;
        private Button btnImg2;
        private Button btnImg3;

        private Label lblStatus;

        private System.ComponentModel.IContainer components = null;

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
            this.lblDescripcion = new Label();

            this.btnAtk1 = new Button();
            this.btnAtk2 = new Button();
            this.btnAtk3 = new Button();

            this.btnImg1 = new Button();
            this.btnImg2 = new Button();
            this.btnImg3 = new Button();

            this.lblStatus = new Label();

            this.SuspendLayout();

            // Form
            this.Text = "Consola";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 600);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "Consola";
            this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitulo.Location = new Point(20, 14);

            // lblNivel
            this.lblNivel.AutoSize = true;
            this.lblNivel.Text = "Nivel X";
            this.lblNivel.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.lblNivel.Location = new Point(22, 54);

            // pnlTitleUnderline
            this.pnlTitleUnderline.Size = new Size(180, 3);
            this.pnlTitleUnderline.Location = new Point(22, 82);

            // btnConfig
            this.btnConfig.Size = new Size(44, 34);
            this.btnConfig.FlatStyle = FlatStyle.Flat;
            this.btnConfig.Location = new Point(this.ClientSize.Width - 64, 18);
            this.btnConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnConfig.Text = "";

            // picA (bajado un poco)
            this.picA.Location = new Point(22, 120); // antes 100
            this.picA.Size = new Size(380, 200);

            // picB (más a la derecha y alineado con picA)
            this.picB.Location = new Point(440, 30); // antes 420
            this.picB.Size = new Size(380, 200);

            // lblDescripcion (bajada un poco)
            this.lblDescripcion.AutoSize = false;
            this.lblDescripcion.Location = new Point(22, 360); // antes 300
            this.lblDescripcion.Size = new Size(640, 80);
            this.lblDescripcion.Text = "Descripción del combate...";
            this.lblDescripcion.Font = new Font("Segoe UI", 10F);

            // Botones Ataques (izquierda)
            int btnW = 180;
            int btnH = 40;
            int margin = 22;
            int spacing = 40;
            int baseY = this.ClientSize.Height - btnH - 30;

            this.btnAtk1.Text = "Ataque 1";
            this.btnAtk1.Size = new Size(btnW, btnH);
            this.btnAtk1.Location = new Point(margin, baseY);
            this.btnAtk1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

            this.btnAtk2.Text = "Ataque 2";
            this.btnAtk2.Size = new Size(btnW, btnH);
            this.btnAtk2.Location = new Point(margin + (btnW + spacing), baseY);
            this.btnAtk2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

            this.btnAtk3.Text = "Ataque 3";
            this.btnAtk3.Size = new Size(btnW, btnH);
            this.btnAtk3.Location = new Point(margin + 2 * (btnW + spacing), baseY);
            this.btnAtk3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

            // Botones Imagen (alineados con picB)
            // Botones Imagen (alineados justo debajo de picB)
            int rightX = this.picB.Left + (this.picB.Width / 2) + 40; // centrados respecto al recuadro
            int startY = this.picB.Bottom + 20; // un margen de 20px debajo del recuadro

            this.btnImg1.Text = "Img 1";
            this.btnImg1.Size = new Size(140, 90);
            this.btnImg1.Location = new Point(rightX, startY);
            this.btnImg1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;

            this.btnImg2.Text = "Img 2";
            this.btnImg2.Size = new Size(140, 90);
            this.btnImg2.Location = new Point(rightX, startY + 100); // 100px más abajo
            this.btnImg2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;

            this.btnImg3.Text = "Img 3";
            this.btnImg3.Size = new Size(140, 90);
            this.btnImg3.Location = new Point(rightX, startY + 200); // 200px más abajo
            this.btnImg3.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;


            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(margin, baseY - 60);
            this.lblStatus.Text = "";
            this.lblStatus.Visible = false;
            this.lblStatus.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);

            // Agregar controles
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.pnlTitleUnderline);
            this.Controls.Add(this.btnConfig);

            this.Controls.Add(this.picA);
            this.Controls.Add(this.picB);
            this.Controls.Add(this.lblDescripcion);

            this.Controls.Add(this.btnAtk1);
            this.Controls.Add(this.btnAtk2);
            this.Controls.Add(this.btnAtk3);

            this.Controls.Add(this.btnImg1);
            this.Controls.Add(this.btnImg2);
            this.Controls.Add(this.btnImg3);

            this.Controls.Add(this.lblStatus);

            this.ResumeLayout(false);
        }
    }
}
