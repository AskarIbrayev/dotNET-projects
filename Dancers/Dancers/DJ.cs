namespace Dancers;
public class DJ
{
    public Track currentTrack { get; private set; }
    public DJ()
    {
        this.currentTrack = new Track("defaultTrack", "Hardbass");
    }
    public void StartMusic()
    {
        Nightclub.IsMusicOn = true;
        Console.WriteLine("DJ starts music");
    }
    public void SwitchTrack(Track track)
    {
        this.currentTrack = track;
        Console.WriteLine($"Dj switched track to {track.Name}");
    }
    public void StopMusic()
    {
        Nightclub.IsMusicOn = false;
        Console.WriteLine("DJ stops music");
    }
}