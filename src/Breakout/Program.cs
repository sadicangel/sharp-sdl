using Breakout;
using Version = SharpSDL.Version;

Console.WriteLine(Version.GetVersion());

var breakout = new Game(new GameSettings(
    Fps: 60,
    WindowSize: new Size(800, 600),
    BackgroundColor: new ColorRgba(0xFF181818),
    ObjectSize: new Size(100, 20)));

breakout.Run();
