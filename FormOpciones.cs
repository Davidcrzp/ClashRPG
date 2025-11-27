using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormOpciones : Form
{
    public FormOpciones()
    {
        InitializeComponent();

        // Mostrar la resolución inicial en la etiqueta
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

    private void comboResolucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboResolucion.SelectedItem != null)
            lblResolucion.Text = $"Resolución: {comboResolucion.SelectedItem}";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Configuración guardada.", "Opciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
