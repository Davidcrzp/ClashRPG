using NAudio.Wave;

namespace ClashRPG;

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
            string rutaMusica = @"Assets\Sounds\Music\Theme.mp3";

            if (File.Exists(rutaMusica))
            {
                // Detener música anterior si está reproduciéndose
                StopMusic();

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

    public void StopMusic()
    {
        outputDevice?.Stop();
        isPlaying = false;
    }

    public void PlayMusic()
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

    public void Volume(float newVol)
    {
        outputDevice?.Volume = newVol;
    }

    public void Dispose()
    {
        StopMusic();
        outputDevice?.Dispose();
        audioFile?.Dispose();
    }
}
