using System;

namespace Dancers;
internal class Program
{
    static void Main(string[] args)
    {
        var trackList = new List<Track>()
        {
            new Track("track1", "Rock"),
            new Track("track2", "Hardbass"),
            new Track("track3", "Latino"),
            new Track("track4", "Hardbass"),
            new Track("track5", "Rock"),
        };
        var Nightclub = new Nightclub(trackList);
        Nightclub.OpenNightClub();
    }
}