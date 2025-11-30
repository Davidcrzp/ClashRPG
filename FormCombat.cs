using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClashRPG
{
    public partial class FormCombat : Form
    {
        // Paleta Clash Royale
        private readonly Color CRPrimaryBlue = Color.FromArgb(46, 134, 255);
        private readonly Color CRDeepNavy = Color.FromArgb(27, 35, 82);
        private readonly Color CRGold = Color.FromArgb(255, 204, 0);
        private readonly Color CRWhite = Color.White;

        // Diccionario de hechizos por personaje
        public static readonly Dictionary<string, string[]> SelectionSpells = new Dictionary<string, string[]>
        {
            { "MAGO", new string[] {"Fireball", "escudo de fuego", "showtime"} },
            { "GUERRERO", new string[]{"estocada", "defensa", "corte fuerte"} },
            { "MINI P.E.K.K.A.", new string[]{"aña", "pancake", "enojarse"} }
        };

        // Diccionario de sprites
        public static readonly Dictionary<string, string> SelectionSprite = new Dictionary<string, string>
        {
            { "MAGO", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\Mago_Acy_1.png" },
            { "GUERRERO", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\kni_Wcy_1.png" },
            { "MINI P.E.K.K.A.", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\mpk_Wcy_1-export.png" },
            { "FURIA", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\furia.png" },
            { "ENREDADERA", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\enredadera.png" },
            { "RAYO", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\rayo.png" },
            { "VENENO", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\veneno.png" },
            { "CURACIÓN", @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\curacion.png" },
            { "Hechizo Vacio", "" }
        };

        // Diccionario de enemigos por nivel
        public static readonly Dictionary<int, string> LevelEnemy = new Dictionary<int, string>
        {
            { 1, @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\ske_Acy_1.png" },
            { 2, @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\gob_Acy_1-export.png" },
            { 3, @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\gigEi1.png" },
            { 4, @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\gigda1.png" },
            { 5, @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Images\Sprites\reinad_Icy_1.png" }
        };

        // Diccionario de IDs de personajes
        public static readonly Dictionary<string, int> CharacterIds = new Dictionary<string, int>
        {
            { "GUERRERO", 1 },
            { "MINI P.E.K.K.A.", 2 },
            { "MAGO", 3 }
        };

        // Variables globales
        public static string character = "";
        public static string[] spells = { "Hechizo Vacio", "Hechizo Vacio" };
        public static int level = 1;
        public static int idPersonajeActual = 0;

        public FormCombat()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyTheme();
            WireEvents();

            using var conn = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Database=base de datos;Uid=root;Pwd=;");
            Conexion conexion = new Conexion();
            using (MySqlConnection connection = conexion.ObtenerConexion())
            {
                using (MySqlCommand command = new MySqlCommand("sp_ReiniciarTodo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    int result = command.ExecuteNonQuery();
                }
            }


            // 👉 Llamamos al método asincrónico al abrir el form
            this.Load += async (s, e) => await FinalizarPartidaAsync();

            Console.WriteLine(FormCombat.character + " " + FormCombat.spells[0] + " " + FormCombat.spells[1]);
        }

        // MÉTODO ACTUALIZADO PARA PROCESAR BATALLA - AHORA SOLO CON ID
        public static async Task<Dictionary<string, object>> ProcesarBatallaAsync(int idPersonaje, int idAtaque, int idMonstruo)
        {
            var resultado = new Dictionary<string, object>();

            try
            {
                using var conn = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Database=base de datos;Uid=root;Pwd=;");
                await conn.OpenAsync();

                using var cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_Batalla", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // ✅ PARÁMETROS ACTUALIZADOS - ahora solo usamos IDs
                cmd.Parameters.AddWithValue("@p_id_personaje", idPersonaje);
                cmd.Parameters.AddWithValue("@p_id_ataque", idAtaque);
                cmd.Parameters.AddWithValue("@p_id_monstruo", idMonstruo);

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    // Mapear resultados basados en el SELECT final del SP
                    resultado["resultado"] = reader["resultado"]?.ToString() ?? "";
                    resultado["danio_personaje"] = reader["danio_personaje"] != DBNull.Value ? Convert.ToInt32(reader["danio_personaje"]) : 0;
                    resultado["hp_monstruo_restante"] = reader["hp_monstruo_restante"] != DBNull.Value ? Convert.ToInt32(reader["hp_monstruo_restante"]) : 0;
                    resultado["hp_personaje_restante"] = reader["hp_personaje_restante"] != DBNull.Value ? Convert.ToInt32(reader["hp_personaje_restante"]) : 0;
                    resultado["mana_personaje"] = reader["mana_personaje"] != DBNull.Value ? Convert.ToInt32(reader["mana_personaje"]) : 0;
                    resultado["danio_boss"] = reader["danio_boss"] != DBNull.Value ? Convert.ToInt32(reader["danio_boss"]) : 0;
                    resultado["estado_monstruo"] = reader["estado_monstruo"]?.ToString() ?? "normal";
                    resultado["aturdido_aplicado"] = reader["aturdido_aplicado"] != DBNull.Value ? Convert.ToBoolean(reader["aturdido_aplicado"]) : false;
                    resultado["id_partida"] = reader["id_partida"] != DBNull.Value ? Convert.ToInt32(reader["id_partida"]) : 0;
                    resultado["experiencia_ganada"] = reader["experiencia_ganada"] != DBNull.Value ? Convert.ToInt32(reader["experiencia_ganada"]) : 0;
                }
            }
            catch (Exception ex)
            {
                resultado["error"] = ex.Message;
                Console.WriteLine($"Error en ProcesarBatallaAsync: {ex.Message}");
            }

            return resultado;
        }

        // MÉTODO PARA FINALIZAR PARTIDA
        public static async Task FinalizarPartidaAsync()
        {
            using var conn = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Database=base de datos;Uid=root;Pwd=;");
            await conn.OpenAsync();

            using var cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_FinalizarPartida", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@p_id_personaje", idPersonajeActual);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                string resultado = reader["resultado"].ToString();
                int idPartida = Convert.ToInt32(reader["id_partida"]);

                int duracionSegundos = 0;
                if (resultado.Contains("Duración"))
                {
                    var partes = resultado.Split(' ');
                    int.TryParse(partes[^2], out duracionSegundos);
                }

                bool victoria = !resultado.Contains("DERROTA");
                string motivoFin = resultado;

                var mongo = new MongoDB();
                await mongo.CrearNotaPartidaFinalizada(
                    idPartida,
                    idPersonajeActual,
                    duracionSegundos,
                    victoria,
                    motivoFin
                );
            }
        }

        // MÉTODO PARA OBTENER ID DE ATAQUE
        public static int ObtenerIdAtaque(int idPersonaje, int numeroAtaque)
        {
            if (numeroAtaque < 1 || numeroAtaque > 3)
                return 0;

            var ataquesPorPersonaje = new Dictionary<int, int[]>
            {
                { 1, new int[] { 1, 2, 3 } },    // Guerrero: ataques 1,2,3
                { 2, new int[] { 4, 5, 6 } },    // Mini P.E.K.K.A.: ataques 4,5,6
                { 3, new int[] { 7, 8, 9 } }     // Mago: ataques 7,8,9
            };

            if (ataquesPorPersonaje.ContainsKey(idPersonaje))
            {
                return ataquesPorPersonaje[idPersonaje][numeroAtaque - 1];
            }

            return 0;
        }

        // MÉTODO PARA OBTENER ID DE MONSTRUO SEGÚN NIVEL
        public static int ObtenerIdMonstruo(int nivel)
        {
            return 3; // Siempre el monstruo con ID 3
        }

        // MÉTODO SIMPLIFICADO PARA MANEJAR ATAQUES
        private async void ManejarAtaque(int numeroAtaque)
        {
            try
            {
                // ✅ AHORA DIRECTAMENTE USAMOS idPersonajeActual
                int idAtaque = ObtenerIdAtaque(idPersonajeActual, numeroAtaque);
                int idMonstruo = ObtenerIdMonstruo(level);

                if (idAtaque == 0)
                {
                    ShowToast("Ataque no válido");
                    return;
                }

                Console.WriteLine($"Ejecutando batalla - Personaje ID: {idPersonajeActual}, Ataque ID: {idAtaque}, Monstruo ID: {idMonstruo}");

                // ✅ LLAMADA SIMPLIFICADA - solo IDs
                var resultado = await ProcesarBatallaAsync(idPersonajeActual, idAtaque, idMonstruo);

                if (resultado.ContainsKey("error"))
                {
                    ShowToast($"Error: {resultado["error"]}");
                    return;
                }

                // Procesar resultado
                string mensajeResultado = resultado["resultado"].ToString();
                int danioInfligido = (int)resultado["danio_personaje"];
                int hpMonstruoRestante = (int)resultado["hp_monstruo_restante"];
                int hpPersonajeRestante = (int)resultado["hp_personaje_restante"];
                int manaPersonaje = (int)resultado["mana_personaje"];
                bool aturdido = (bool)resultado["aturdido_aplicado"];

                string mensajeUsuario = $"{mensajeResultado}";
                if (danioInfligido > 0)
                {
                    mensajeUsuario += $"\nDaño infligido: {danioInfligido}";
                }
                if (aturdido)
                {
                    mensajeUsuario += "\n¡MONSTRUO ATURDIDO!";
                }

                ShowToast(mensajeUsuario);
                ActualizarInterfazUsuario(hpPersonajeRestante, hpMonstruoRestante, manaPersonaje);

                if (hpMonstruoRestante <= 0)
                {
                    ShowToast("¡Monstruo derrotado!");
                    level++;
                    MessageBox.Show($"¡HAS GANADO!");
                    // Aquí podrías actualizar la imagen del monstruo según el nuevo nivel
                }
                else if (hpPersonajeRestante <= 0)
                {
                    ShowToast("¡Has sido derrotado!");
                    await FinalizarPartidaAsync();
                }
            }
            catch (Exception ex)
            {
                ShowToast($"Error en la batalla: {ex.Message}");
            }
        }

        // MÉTODO PARA ACTUALIZAR INTERFAZ DE USUARIO
        private void ActualizarInterfazUsuario(int hpPersonaje, int hpMonstruo, int manaPersonaje)
        {
            Console.WriteLine($"HP Personaje: {hpPersonaje}, HP Monstruo: {hpMonstruo}, Mana: {manaPersonaje}");
            this.lblDescripcion.Text = $"HP Personaje: {hpPersonaje}, HP Monstruo: {hpMonstruo}, Mana: {manaPersonaje}";

            // Aquí puedes agregar la actualización de tus controles UI:
            // Ejemplo:
            // progressBarPlayerHP.Value = hpPersonaje;
            // progressBarMonsterHP.Value = hpMonstruo;
            // labelMana.Text = manaPersonaje.ToString();
            // lblPlayerHP.Text = $"HP: {hpPersonaje}";
            // lblMonsterHP.Text = $"HP: {hpMonstruo}";
        }

        // MÉTODO PARA ASIGNAR PERSONAJE
        public static void SetCharacter(string personaje)
        {
            if (CharacterIds.ContainsKey(personaje))
            {
                idPersonajeActual = CharacterIds[personaje];
                character = personaje;
                Console.WriteLine($"Personaje elegido: {character}, ID: {idPersonajeActual}");
            }
            else
            {
                idPersonajeActual = 0;
                Console.WriteLine("Personaje no válido");
            }
        }

        // --- MÉTODOS DE ESTILO Y EVENTOS ---
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

            // Conectar los botones de ataque al método simplificado
            btnAtk1.Click += (s, e) => ManejarAtaque(1);
            btnAtk2.Click += (s, e) => ManejarAtaque(2);
            btnAtk3.Click += (s, e) => ManejarAtaque(3);

            btnImg1.Click += (s, e) => ShowToast("Hechizo de " + FormCombat.spells[0] + ": Fallido");
            btnImg2.Click += (s, e) => ShowToast("Hechizo de " + FormCombat.spells[1] + ": Fallido");
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

        private void btnImg1_Click(object sender, EventArgs e)
        {
            ShowToast("Hechizo vacio");
        }

        private void btnImg2_Click(object sender, EventArgs e)
        {
            ShowToast("Hechizo vacio");
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FormLogin.settings.Show();
        }
    }
}