namespace ClashRPG;

public partial class FormCombat : Form
{
    // Diccionario de personaje
    public readonly Dictionary<int, string[]> CharacterNameAttackAndSprite = new Dictionary<int, string[]>
        {
            { 1, new string[] {"Mago", "Bola de fuego", "Escudo de fuego", "Showtime", @"Assets\Images\Sprites\mago.png", @"Assets\Images\Sprites\magoAtk.png"} },
            { 2, new string[] {"Mini P.E.K.K.A.", "Aña", "Pancakes", "Enojarse", @"Assets\Images\Sprites\minpekka.png", @"Assets\Images\Sprites\minpekkaAtk.png"} },
            { 3, new string[] {"Caballero", "Estocada", "Defensa", "Corte fuerte", @"Assets\Images\Sprites\caballero.png", @"Assets\Images\Sprites\caballeroAtk.png"} }
        };

    // Diccionario de hechizos
    public readonly Dictionary<int, string[]> SpellNameAndSprite = new Dictionary<int, string[]>{
            { 1, new string[] {"Furia", @"Assets\Images\Sprites\furia.png", @"Assets\Images\Sprites\furiaEff.png"} },
            { 2, new string[] {"Enredadera", @"Assets\Images\Sprites\enredadera.png", @"Assets\Images\Sprites\enredaderaEff.png"} },
            { 3, new string[] {"Rayo", @"Assets\Images\Sprites\rayo.png", @"Assets\Images\Sprites\rayoEff.png"} },
            { 4, new string[] {"Veneno", @"Assets\Images\Sprites\veneno.png", @"Assets\Images\Sprites\venenoEff.png"} },
            { 5, new string[] {"Curacion", @"Assets\Images\Sprites\curacion.png", @"Assets\Images\Sprites\curacionEff.png"} },
            { 0, new string[] {"Hechizo Vacio"} }
        };

    // Diccionario de enemigo
    public readonly Dictionary<int, string[]> MonsterNameAndSprite = new Dictionary<int, string[]>
        {
            { 1, new string[] {"Esqueleto", @"Assets\Images\Sprites\esqueleto.png",  @"Assets\Images\Sprites\esqueletoAtk.png"} },
            { 2, new string[] {"Goblin", @"Assets\Images\Sprites\goblin.png", @"Assets\Images\Sprites\goblinAtk.png"} },
            { 3, new string[] {"Gigante Esqueleto", @"Assets\Images\Sprites\gigEsqueleto.png", @"Assets\Images\Sprites\gigEsqueletoAtk.png"} },
            { 4, new string[] {"Gigante Goblin", @"Assets\Images\Sprites\gigDuende.png", @"Assets\Images\Sprites\gigDuendeAtk.png"} },
            { 5, new string[] {"Reina Goblin", @"Assets\Images\Sprites\reinaDuende.png", @"Assets\Images\Sprites\reinaDuendeAtk.png"} }
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
    }

    private void UpdateForm()
    {
        EnableBtn();
        UpdateText();
    }

    private void btnAtk_Click(int attack)
    {
        Console.WriteLine("Tu turno");
        if (Global.effect == 1)
        {
            Console.WriteLine("Estas aturdido");
            Global.effect = 0;
            return;
        }
        if (attack == 1)
        {
            AnimateCharacter();
            // SQL ATAQUE 1
            int damage = 5; // DAÑO EJEMPLO
            Global.life = Global.life; // VIDA RESTANTE EJEMPLO
            Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
            Global.effectEnemy = Global.effectEnemy;

            Console.WriteLine(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
        }
        else if (attack == 2)
        {
            AnimateCharacter();
            // SQL ATAQUE 2
            int damage = 10; // DAÑO EJEMPLO
            // Global.life = Global.life; // VIDA RESTANTE EJEMPLO
            Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO

            Console.WriteLine(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
        }
        else if (attack == 3)
        {
            AnimateCharacter();
            // SQL ATAQUE 3
            int damage = 15; // DAÑO EJEMPLO
            // Global.life = Global.life; // VIDA RESTANTE EJEMPLO
            Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO

            Console.WriteLine(CharacterNameAttackAndSprite[Global.idCharacter][attack] + ". " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
        }
        else if (attack == 4)
        {
            if (Global.idSpells[0] == 0)
            {
                Console.WriteLine("Hechizo no equipado");
                return;
            }
            if (Global.chargeSpells[0] == 0)
            {
                Console.WriteLine("Hechizo agotado");
                return;
            }
            //AnimateSpell(null, Global.idSpells[1]);
            // SQL ATAQUE 4 CON HECHIZO Y GUARDAS VIDA RESTANTE DE AMBOS, DAÑO REALIZADO Y ESTADO
            if (Global.idSpells[0] == 5)
            {
                int heal = 10;
                Global.life += heal; // HECHIZO EJEMPLO
                Console.WriteLine(SpellNameAndSprite[Global.idSpells[0]][0] + " lanzado. " + "Curacion: " + heal);
            }
            else
            {
                int damage = 5; // DAÑO EJEMPLO
                // Global.life = Global.life; // VIDA RESTANTE EJEMPLO
                Global.lifeMonster -= damage;  // VIDA RESTANTE EJEMPLO
                if (Global.idSpells[0] == 2) Global.effectEnemy = 1; // HECHIZO EJEMPLO
                else if (Global.idSpells[0] == 4) Global.effectEnemy = 2; // HECHIZO EJEMPLO
                Global.chargeSpells[0]--;
                Console.WriteLine(SpellNameAndSprite[Global.idSpells[0]][0] + " lanzado. " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
            }

        }
        else if (attack == 5)
        {
            if (Global.idSpells[1] == 0)
            {
                Console.WriteLine("Hechizo no equipado");
                return;
            }
            if (Global.chargeSpells[1] == 0)
            {
                Console.WriteLine("Hechizo agotado");
                return;
            }
            //AnimateSpell(null, Global.idSpells[1]);
            // SQL ATAQUE 5 CON HECHIZO
            int damage = 5; // DAÑO EJEMPLO
            // Global.life = Global.life; // VIDA RESTANTE EJEMPLO
            Global.lifeMonster = Global.lifeMonster - damage;  // VIDA RESTANTE EJEMPLO
            if (Global.effectEnemy == 0) Global.effectEnemy = 2; // VIDA RESTANTE EJEMPLO
            else if (Global.effectEnemy == 2) Global.effectEnemy = 0;
            Global.chargeSpells[1]--;

            Console.WriteLine(SpellNameAndSprite[Global.idSpells[1]][0] + " lanzado! " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);
        }

        System.Windows.Forms.Timer t;

        if (Global.lifeMonster <= 0)
        {
            Console.WriteLine(round);
            if (round == 5)
            {
                UpdateForm();
                t = new System.Windows.Forms.Timer();
                t.Interval = 1000;
                t.Tick += (s, e) =>
                {
                    FinishGame(1);
                    t.Stop();
                    t.Dispose();
                };
                t.Start();
                return;
            }
            round++;
            NextRound();
            UpdateForm();
            return;
        }

        turn = !turn;

        UpdateForm();
        t = new System.Windows.Forms.Timer();
        t.Interval = 1000;
        t.Tick += (s, e) =>
        {
            Atk_Enemy();
            t.Stop();
            t.Dispose();
        };
        t.Start();
    }

    private void Atk_Enemy()
    {
        Console.WriteLine("Turno enemigo");
        if (Global.effectEnemy == 1)
        {
            Console.WriteLine("Enemigo aturdido");
            Global.effectEnemy = 0;

            turn = !turn;

            UpdateForm();
            return;
        }
        AnimateMonster();
        // SQL ATAQUE ENEMIGO
        int damage = 5; // DAÑO EJEMPLO
        Global.life = Global.life - damage; // VIDA RESTANTE EJEMPLO
        Global.lifeMonster = Global.lifeMonster;  // VIDA RESTANTE EJEMPLO
        Console.WriteLine("Ataque Enemigo! " + "Daño realizado: " + damage + ", Efecto aplicado: " + Global.effectName[Global.effectEnemy]);

        if (Global.life <= 0)
        {
            UpdateForm();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += (s, e) =>
            {
                FinishGame(0);
                t.Stop();
                t.Dispose();
            };
            FinishGame(0);
            return;
        }

        turn = !turn;

        UpdateForm();
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
        Global.settings.Show();
    }

    private void WireEvents()
    {
        btnConfig.Paint += BtnConfig_Paint;
        btnConfig.Click += (s, e) => Global.settings.Show();

        // Conectar los botones de ataque al método simplificado
        btnAtk1.Click += (s, e) => btnAtk_Click(1);
        btnAtk2.Click += (s, e) => btnAtk_Click(2);
        btnAtk3.Click += (s, e) => btnAtk_Click(3);

        btnImg1.Click += (s, e) => btnAtk_Click(4);
        btnImg2.Click += (s, e) => btnAtk_Click(5);
    }

    private void FinishGame(int status)
    {
        // SQL FINPARTIDA
        Global.end = new FormEnd(status);
        this.Hide();
        Global.end.Show();
    }

    private void NextRound()
    {
        lblNivel.Text = "Nivel " + round;
        picB.Image = Image.FromFile(MonsterNameAndSprite[round][1]);
        // SQL SELECCIONAR MONSTRUO Y ASIGNAR VIDA DE MONSTRUO EN BASE A RONDA
        // sp_seleccionarMonstruo(@p_round)
        Global.lifeMonster = 100;
    }

    private void UpdateText()
    {
        lblDescripcion.Text = "Vida: " + Global.life + "\nEfectos: " + Global.effectName[Global.effect];
        lblDescripcion2.Text = "Vida " + MonsterNameAndSprite[round][0] + ": " + Global.lifeMonster + "\nEfectos: " + Global.effectName[Global.effectEnemy];
        btnImg1.Text = Global.idSpells[0] != 0 ? SpellNameAndSprite[Global.idSpells[0]][0] + ": " + Global.chargeSpells[0] : SpellNameAndSprite[Global.idSpells[0]][0];
        btnImg2.Text = Global.idSpells[1] != 0 ? SpellNameAndSprite[Global.idSpells[1]][0] + ": " + Global.chargeSpells[0] : SpellNameAndSprite[Global.idSpells[1]][0];
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
    private void AnimateCharacter()
    {
        picA.Image = Image.FromFile(CharacterNameAttackAndSprite[Global.idCharacter][5]);
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        t.Interval = 500;
        t.Tick += (s, e) =>
        {
            picA.Image = Image.FromFile(CharacterNameAttackAndSprite[Global.idCharacter][4]);
            t.Stop();
            t.Dispose();
        };
        t.Start();
    }
    private void AnimateSpell(Button picAtk, int spell)
    {
        picAtk.Image = Image.FromFile(SpellNameAndSprite[Global.idSpells[spell]][2]);
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        t.Interval = 500;
        t.Tick += (s, e) =>
        {
            picAtk.Image = null;
            t.Stop();
            t.Dispose();
        };
        t.Start();
    }
    private void AnimateMonster()
    {
        picB.Image = Image.FromFile(MonsterNameAndSprite[round][2]);
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        t.Interval = 500;
        t.Tick += (s, e) =>
        {
            picB.Image = Image.FromFile(MonsterNameAndSprite[round][1]);
            t.Stop();
            t.Dispose();
        };
        t.Start();
    }
}