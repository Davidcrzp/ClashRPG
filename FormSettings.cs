using System;
using System.Windows.Forms;

namespace ClashRPG;

public partial class FormOpciones : Form
{
    public FormOpciones()
    {
        InitializeComponent();

        // Mostrar valores iniciales
        lblVolumenEfectos.Text = $"Volumen efectos: {trackBarVolumenEfectos.Value}%";
        lblVolumenMusica.Text = $"Volumen música: {trackBarVolumenMusica.Value}%";
    }

    private void trackBarVolumenEfectos_Scroll(object sender, EventArgs e)
    {
        lblVolumenEfectos.Text = $"Volumen efectos: {trackBarVolumenEfectos.Value}%";
    }

    private void trackBarVolumenMusica_Scroll(object sender, EventArgs e)
    {
        lblVolumenMusica.Text = $"Volumen música: {trackBarVolumenMusica.Value}%";
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
