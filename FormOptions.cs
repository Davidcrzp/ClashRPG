using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormOptions : Form
{
    public FormOptions()
    {
        InitializeComponent();

        if (comboResolucion.SelectedItem != null)
            lblResolucion.Text = $"Resolución: {comboResolucion.SelectedItem}";
    }

    private void trackBarVolumenEfectos_Scroll(object sender, EventArgs e)
    {
        lblVolumenEfectos.Text = $"Volumen efectos: {trackBarVolumenEfectos.Value}%";
    }

    private void trackBarVolumenMusica_Scroll(object sender, EventArgs e)
    {
        lblVolumenMusica.Text = $"Volumen música: {trackBarVolumenMusica.Value}%";
    }

    private void trackBarBrillo_Scroll(object sender, EventArgs e)
    {
        lblBrillo.Text = $"Brillo: {trackBarBrillo.Value}%";
    }

    private void comboResolucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboResolucion.SelectedItem != null)
            lblResolucion.Text = $"Resolución: {comboResolucion.SelectedItem}";
    }
}
