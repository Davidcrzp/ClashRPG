using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormOpciones : Form
{
    public FormOpciones()
    {
        InitializeComponent();
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
        lblResolucion.Text = $"Resolución: {comboResolucion.SelectedItem}";
    }
}
