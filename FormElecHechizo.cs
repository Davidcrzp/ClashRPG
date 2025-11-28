using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormElecHechizo : Form
{
    private List<string> hechizosSeleccionados = new List<string>();

    public FormElecHechizo()
    {
        InitializeComponent();
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
        else
        {
            string seleccion = string.Join(", ", hechizosSeleccionados);
            MessageBox.Show("Has seleccionado: " + seleccion);
        }
    }
}
