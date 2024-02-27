namespace Dancers;
public class Nightclub
{
    private List<string> _musicTypes;
    private Dictionary<string, string> _danceMoves;
    private List<Track> _trackList;
    private DJ _dj = new DJ();
    private readonly List<Thread> _allDancers = new List<Thread>();
    public static bool IsMusicOn = false;

    public Nightclub(List<Track> trackList)
    {
        this._musicTypes = new List<string>() { "Hardbass", "Latino", "Rock" };
        this._danceMoves = new Dictionary<string, string>()
        {
            {"Hardbass", "Elbow"},
            {"Latino", "Hips"},
            {"Rock", "Head"}
        };
        this._trackList = trackList;
    }
    public void OpenNightClub()
    {
        Console.WriteLine("Nighclub opens");
        _dj.StartMusic();
        for (var i = 0; i < 5; i++)
        {
            var dancerThread = new Thread(Dance);
            dancerThread.Name = $"Dancer-{i + 1}";
            _allDancers.Add(dancerThread);
            dancerThread.Start();
        }
        foreach (var track in _trackList)
        {
            _dj.SwitchTrack(track);
            Thread.Sleep(2000);
        }
        _dj.StopMusic();
        foreach (var thread in _allDancers)
        {
            thread.Join();
        }
        Console.WriteLine("Nighclub closes");
    }
    public void Dance()
    {
        while(IsMusicOn)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is dancing {_danceMoves[_dj.currentTrack.MusicType]} dance");
            Thread.Sleep(1000);
        }
        Console.WriteLine($"{Thread.CurrentThread.Name} goes home");
    }
}