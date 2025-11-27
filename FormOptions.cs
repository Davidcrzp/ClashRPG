using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormOptions : Form
{
    public FormOptions()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        if (comboResolucion.SelectedItem != null)
            lblResolucion.Text = $"Resolución: {comboResolucion.SelectedItem}";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        FormLogin.musicManager.Volume((float)trackBarVolumenMusica.Value / 100);
        FormLogin.effectsManager.Volume((float)trackBarVolumenEfectos.Value / 100);
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        this.Close();
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
