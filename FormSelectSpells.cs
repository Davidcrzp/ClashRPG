namespace ClashRPG;

public partial class FormSelectSpells : Form
{
    private List<string> hechizosSeleccionados = new List<string>();

    public FormSelectSpells()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.None;
    }

    private void Hechizo_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string nombre = btn.Tag.ToString();

        if (hechizosSeleccionados.Contains(nombre))
        {
            hechizosSeleccionados.Remove(nombre);
            btn.BackColor = Color.FromArgb(255, 204, 0); // Amarillo normal
        }
        else
        {
            if (hechizosSeleccionados.Count >= 2)
            {
                MessageBox.Show("Solo puedes seleccionar máximo 2 hechizos.");
                return;
            }
            hechizosSeleccionados.Add(nombre);
            btn.BackColor = Color.LightGreen; // Indica selección
        }
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Abrir configuración...");
    }

    private void btnContinuar_Click(object sender, EventArgs e)
    {
        if (hechizosSeleccionados.Count == 0)
        {
            MessageBox.Show("No seleccionaste ningún hechizo. Continuando...");
        }
        else if (hechizosSeleccionados.Count == 1)
        {
            Global.idSpells[0] = Global.spellsId[hechizosSeleccionados[0]];
        }
        else
        {
            Global.idSpells[0] = Global.spellsId[hechizosSeleccionados[0]];
            Global.idSpells[1] = Global.spellsId[hechizosSeleccionados[1]];

            MessageBox.Show("Has seleccionado: " + hechizosSeleccionados[0] + ", " + hechizosSeleccionados[1]);
        }
        this.Hide();
        Global.combat = new FormCombat();
        Global.combat.Show();
    }
}