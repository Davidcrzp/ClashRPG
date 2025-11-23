using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    public class MapaManager
    {
        private PictureBox? pictureBoxMapa;
        private Form formPadre;

        public event Action? VolverAlLoginRequested;

        public MapaManager(Form formPadre)
        {
            this.formPadre = formPadre;
        }

        public void MostrarMapa()
        {
            // Crear PictureBox
            pictureBoxMapa = new PictureBox();
            pictureBoxMapa.Dock = DockStyle.Fill;
            pictureBoxMapa.SizeMode = PictureBoxSizeMode.Zoom;

            // Ruta ABSOLUTA exacta
            string rutaAbsoluta = @"C:\Users\erick\source\repos\Proyecto\Proyecto\Resources\48765.png";

            if (File.Exists(rutaAbsoluta))
            {
                try
                {
                    pictureBoxMapa.Image = Image.FromFile(rutaAbsoluta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cargando la imagen: {ex.Message}");
                    CrearMapaPrueba();
                }
            }
            else
            {
                CrearMapaPrueba();
            }

            // Agregar al formulario
            formPadre.Controls.Add(pictureBoxMapa);
            pictureBoxMapa.BringToFront();
            formPadre.Text = "Mapa del Juego - Emoti's Way";

            // ⚠️ ELIMINADO: AgregarBotonVolver() - Ya no hay botón de volver
        }

        public void OcultarMapa()
        {
            if (pictureBoxMapa != null)
            {
                formPadre.Controls.Remove(pictureBoxMapa);
                pictureBoxMapa.Dispose();
                pictureBoxMapa = null;
            }

            // ⚠️ ELIMINADO: Código para remover botón volver
        }

        private void CrearMapaPrueba()
        {
            if (pictureBoxMapa == null) return;

            // Crear un mapa de prueba que se adapte a la pantalla completa
            int ancho = formPadre.ClientSize.Width;
            int alto = formPadre.ClientSize.Height;

            Bitmap mapaPrueba = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(mapaPrueba))
            {
                g.Clear(Color.LightBlue);

                // Texto centrado
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                g.DrawString("MAPA DE PRUEBA",
                            new Font("Arial", 24, FontStyle.Bold),
                            Brushes.DarkBlue,
                            new RectangleF(0, 0, ancho, alto),
                            format);
            }
            pictureBoxMapa.Image = mapaPrueba;
        }

        // ⚠️ ELIMINADO: Método AgregarBotonVolver() completo

        protected virtual void OnVolverAlLoginRequested()
        {
            VolverAlLoginRequested?.Invoke();
        }
    }
}
