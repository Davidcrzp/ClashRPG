using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DnsClient.Protocol;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;

namespace ClashRPG
{
    public partial class FormCombat : Form
    {
        // Paleta Clash Royale
        private readonly Color CRPrimaryBlue = Color.FromArgb(46, 134, 255);
        private readonly Color CRDeepNavy = Color.FromArgb(27, 35, 82);
        private readonly Color CRGold = Color.FromArgb(255, 204, 0);
        private readonly Color CRWhite = Color.White;

        // Diccionario de personaje
        public readonly Dictionary<int, string[]> CharacterNameAttackAndSprite = new Dictionary<int, string[]>
        {
            { 1, new string[] {"Mago", "Bola de fuego", "Escudo de fuego", "Showtime", @"Assets\Images\Sprites\Mago_Acy_1.png"} },
            { 2, new string[] {"Mini P.E.K.K.A.", "Aña", "Pancakes", "Enojarse", @"Assets\Images\Sprites\mpk_Wcy_1-export.png"} },
            { 3, new string[] {"Caballero", "Estocada", "Defensa", "Corte fuerte", @"Assets\Images\Sprites\kni_Wcy_1.png"} }
        };

        // Diccionario de hechizos
        public readonly Dictionary<int, string[]> SpellNameAndSprite = new Dictionary<int, string[]>{
            { 1, new string[] {"Furia", @"Assets\Images\Sprites\furia.png"} },
            { 2, new string[] {"Enredadera", @"Assets\Images\Sprites\enredadera.png"} },
            { 3, new string[] {"Rayo", @"Assets\Images\Sprites\rayo.png"} },
            { 4, new string[] {"Veneno", @"Assets\Images\Sprites\veneno.png"} },
            { 5, new string[] {"Curacion", @"Assets\Images\Sprites\curacion.png"} },
            { 0, new string[] {"Hechizo Vacio"} }
        };

        // Diccionario de enemigo
        public readonly Dictionary<int, string[]> MonsterNameAndSprite = new Dictionary<int, string[]>
        {
            { 1, new string[] {"Esqueleto", @"Assets\Images\Sprites\ske_Acy_1.png"} },
            { 2, new string[] {"Goblin", @"Assets\Images\Sprites\gob_Acy_1-export.png"} },
            { 3, new string[] {"Gigante Esqueleto", @"Assets\Images\Sprites\gigEi1.png"} },
            { 4, new string[] {"Gigante Goblin", @"Assets\Images\Sprites\gigda1.png"} },
            { 5, new string[] {"Reina Goblin", @"Assets\Images\Sprites\reinad_Icy_1.png"} }
        };

        private int round = 1;
        private bool turn = true;

        public FormCombat()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyTheme();
            WireEvents();

            Console.WriteLine(CharacterNameAttackAndSprite[Global.idCharacter][0] + " " + SpellNameAndSprite[Global.idSpells[0]][0] + " " + SpellNameAndSprite[Global.idSpells[1]][0]);
            NextRound();
            UpdateForm();
            ShowToast("Tu Turno");
        }

        private void UpdateForm()
        {
            EnableBtn();
            UpdateText();
        }

        private void NextRound()
        {
            SelectMonster(round);
        }

        private void btnAtk_Click(int attack)
        {
            Console.WriteLine(attack);
            if (Global.effect == 1)
            {
                ShowToast("Estas aturdido");
                Thread.Sleep(1000);
                Global.effect = 0;
                return;
            }
            if (attack == 1)
            {
                AnimateCharacter(attack);
                // SQL ATAQUE 1
                int damage = 5; // DAÑO EJEMPLO
                Global.life = Global.life; // VIDA RESTANTE EJEMPLO
                Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
                // if (Global.effectEnemy == 0) Global.effectEnemy = 1; // EFECTO EJEMPLO
                // else if (Global.effectEnemy == 1) Global.effectEnemy = 0;

                ShowToast(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            }
            else if (attack == 2)
            {
                AnimateCharacter(attack);
                // SQL ATAQUE 2
                int damage = 10; // DAÑO EJEMPLO
                Global.life = Global.life; // VIDA RESTANTE EJEMPLO
                Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
                // if (Global.effectEnemy == 0) Global.effectEnemy = 1; // EFECTO EJEMPLO
                // else if (Global.effectEnemy == 1) Global.effectEnemy = 0;

                ShowToast(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);

            }
            else if (attack == 3)
            {
                AnimateCharacter(attack);
                // SQL ATAQUE 3
                int damage = 15; // DAÑO EJEMPLO
                Global.life = Global.life; // VIDA RESTANTE EJEMPLO
                Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
                // if (Global.effectEnemy == 0) Global.effectEnemy = 1; // EFECTO EJEMPLO
                // else if (Global.effectEnemy == 1) Global.effectEnemy = 0;

                ShowToast(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            }
            else if (attack == 4)
            {
                if (Global.idSpells[0] == 0)
                {
                    ShowToast("Hechizo no equipado");
                    return;
                }
                if (Global.chargeSpells[0] == 0)
                {
                    ShowToast("Hechizo agotado");
                    return;
                }
                AnimateCharacter(attack);
                // SQL ATAQUE 4 CON HECHIZO Y GUARDAS VIDA RESTANTE DE AMBOS, DAÑO REALIZADO Y ESTADO
                int damage = 5; // DAÑO EJEMPLO
                Global.life = Global.life; // VIDA RESTANTE EJEMPLO
                Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
                if (Global.effectEnemy == 0) Global.effectEnemy = 1; // VIDA RESTANTE EJEMPLO
                else if (Global.effectEnemy == 1) Global.effectEnemy = 0;
                Global.chargeSpells[0]--;

                ShowToast(SpellNameAndSprite[Global.idSpells[0]][0] + " lanzado. " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            }
            else if (attack == 5)
            {
                if (Global.idSpells[1] == 0)
                {
                    ShowToast("Hechizo no equipado");
                    return;
                }
                if (Global.chargeSpells[0] == 0)
                {
                    ShowToast("Hechizo agotado");
                    return;
                }
                AnimateCharacter(attack);
                // SQL ATAQUE 5 CON HECHIZO
                int damage = 5; // DAÑO EJEMPLO
                Global.life = Global.life; // VIDA RESTANTE EJEMPLO
                Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
                if (Global.effectEnemy == 0) Global.effectEnemy = 2; // VIDA RESTANTE EJEMPLO
                else if (Global.effectEnemy == 2) Global.effectEnemy = 0;
                Global.chargeSpells[1]--;

                ShowToast(SpellNameAndSprite[Global.idSpells[1]][0] + " lanzado! " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            }
            Console.WriteLine(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + 5 + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            Thread.Sleep(500);

            turn = !turn;

            UpdateForm();
            Atk_Enemy();
        }

        private void Atk_Enemy()
        {
            if (Global.effect == 1)
            {
                ShowToast("Enemigo aturdido");
                Thread.Sleep(1000);
                turn = !turn;
                UpdateForm();
                return;
            }
            ShowToast("Turno enemigo");
            Thread.Sleep(1000);
            // SQL ATAQUE ENEMIGO
            int damage = 5; // DAÑO EJEMPLO
            Global.life = Global.life - damage; // VIDA RESTANTE EJEMPLO
            Global.lifeMonster = Global.lifeMonster;  // VIDA RESTANTE EJEMPLO
            ShowToast("Ataque Enemigo! " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            turn = !turn;
            UpdateForm();
            return;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Global.settings.Show();
        }

        private void WireEvents()
        {
            btnConfig.Paint += BtnConfig_Paint;
            btnConfig.Click += (s, e) => ShowToast("Abrir configuración");

            // Conectar los botones de ataque al método simplificado
            btnAtk1.Click += (s, e) => btnAtk_Click(1);
            btnAtk2.Click += (s, e) => btnAtk_Click(2);
            btnAtk3.Click += (s, e) => btnAtk_Click(3);

            btnImg1.Click += (s, e) => btnAtk_Click(4);
            btnImg2.Click += (s, e) => btnAtk_Click(5);
        }

        private void FinishGame()
        {
            MessageBox.Show("Termino");
        }

        private void SelectMonster(int roundMonster)
        {
            lblNivel.Text = "Nivel " + round;
            ApplyMonsterSprites(round);
            // SQL SELECCIONAR MONSTRUO Y ASIGNAR VIDA DE MONSTRUO EN BASE A RONDA
            Global.lifeMonster = 100;
        }

        private void ApplyMonsterSprites(int roundMonster)
        {
            picB.Image = Image.FromFile(MonsterNameAndSprite[round][1]);
        }

        private void UpdateText()
        {
            lblDescripcion.Text = "Vida: " + Global.life + "                                                                                                          Vida " + MonsterNameAndSprite[round][0] + ": " + Global.lifeMonster + "\n\n";
            lblDescripcion.Text += "Efectos: " + Global.effectName[Global.effect] + "                                                                                               Efectos: " + Global.effectName[Global.effectEnemy];
            btnImg2.Text = SpellNameAndSprite[Global.idSpells[0]][0] + ": " + Global.chargeSpells[0];
            btnImg2.Text = SpellNameAndSprite[Global.idSpells[1]][0] + ": " + Global.chargeSpells[1];
        }

        private void EnableBtn()
        {
            btnAtk1.Enabled = turn;
            btnAtk2.Enabled = turn;
            btnAtk3.Enabled = turn;
            btnImg1.Enabled = turn;
            btnImg2.Enabled = turn;
        }


        // --- MÉTODOS DE ESTILO Y EVENTOS ---
        private void AnimateCharacter(int attack) { }
        private void AnimateMonster() { }

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
}