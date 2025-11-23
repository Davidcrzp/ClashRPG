using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace ClashRPG
{
    public class MusicManager : IDisposable
    {
        private AudioFileReader? audioFile;
        private WaveOutEvent? outputDevice;
        private bool isPlaying;
        private bool isMuted;

        public void ReproducirMusica()
        {
            try
            {
                string rutaMusica = @"Resources\Theme.mp3";

                if (File.Exists(rutaMusica))
                {
                    // Detener música anterior si está reproduciéndose
                    DetenerMusica();

                    // Crear nuevos objetos para reproducir
                    audioFile = new AudioFileReader(rutaMusica);
                    outputDevice = new WaveOutEvent();

                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    isPlaying = true;
                    isMuted = false;

                    // Repetir automáticamente cuando termine
                    outputDevice.PlaybackStopped += (s, e) =>
                    {
                        if (isPlaying && !isMuted)
                        {
                            audioFile!.Position = 0; // Volver al inicio
                            outputDevice!.Play();
                        }
                    };
                }
                else
                {
                    MessageBox.Show($"Archivo de música no encontrado en: {rutaMusica}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reproduciendo música: {ex.Message}");
            }
        }

        public void DetenerMusica()
        {
            outputDevice?.Stop();
            isPlaying = false;
        }

        public void ToggleMusica()
        {
            if (isMuted)
            {
                // Reactivar música
                outputDevice?.Play();
                isMuted = false;
            }
            else
            {
                // Silenciar música
                outputDevice?.Pause();
                isMuted = true;
            }
        }

        public void Dispose()
        {
            DetenerMusica();
            outputDevice?.Dispose();
            audioFile?.Dispose();
        }
    }
}
