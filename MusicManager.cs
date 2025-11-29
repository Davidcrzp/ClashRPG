using NAudio.Wave;

namespace ClashRPG;

public class MusicManager : IDisposable
{
    private AudioFileReader? audioFile;
    private WaveOutEvent? outputDevice;
    private bool isPlaying;
    private bool isMuted;

    public void PlayMusic()
    {
        try
        {
            string themePath = @"C:\Users\ferow\Downloads\ClashRPG-main\Assets\Sounds\Music\Theme.mp3";
            if (File.Exists(themePath))
            {
                // Detener música anterior si está reproduciéndose
                StopMusic();

                // Crear nuevos objetos para reproducir
                audioFile = new AudioFileReader(themePath);
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
                MessageBox.Show($"Archivo de música no encontrado en: {themePath}");
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
