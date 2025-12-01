using System.Drawing.Imaging.Effects;

namespace ClashRPG;

public class Global
{
    // Login
    public static Conexion conexion;
    public static string username;

    // Forms
    public static FormSettings settings;
    public static FormSelectCharacter selectCharacter;
    public static FormSelectSpells selectSpells;
    public static MusicManager musicManager;
    public static MusicManager effectsManager;
    public static FormStartMenu startMenu;
    public static FormCombat combat;
    public static FormLoading loading;
    public static FormEnd end;

    // Variables
    public static int idCharacter = 0;
    public static int[] idSpells = { 0, 0 };
    public static int[] chargeSpells = { 3, 3 };
    public static Dictionary<string, int> spellsId = new Dictionary<string, int>
    {
        {"FURIA", 1},
        {"ENREDADERA", 2},
        {"RAYO", 3},
        {"VENENO", 4},
        {"CURACIÓN", 5},
    };
    public static int life = 100, lifeMonster = 100, effect = 0, effectEnemy = 0;
    public static string[] effectName = { "Ninguno", "Aturdido", "Envenenado" };

    public Global()
    {
        conexion = new Conexion();
        settings = new FormSettings();
        selectCharacter = new FormSelectCharacter();
        selectSpells = new FormSelectSpells();
        musicManager = new MusicManager();
        effectsManager = new MusicManager();
        startMenu = new FormStartMenu();
    }
}