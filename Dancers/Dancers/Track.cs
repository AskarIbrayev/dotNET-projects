namespace Dancers;
public class Track
{
    public string Name { get; set; }
    public string MusicType { get; set; }
    public Track(string name, string musicType)
    {
        this.Name = name;
        this.MusicType = musicType;
    }
}