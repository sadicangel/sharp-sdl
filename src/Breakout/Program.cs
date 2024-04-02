using Breakout;
using SharpSDL.IO;
using SharpSDL.Objects;
using Version = SharpSDL.Version;

Logger.LogInformation($"{Version.GetVersion()} for {Version.GetPlatform()}");
Logger.LogInformation($"Locale: {(Locale.GetPreferredLocales() is [var locale, ..] ? locale.ToString() : "unknown")}");

var breakout = new Game(new GameSettings(
    Fps: 60,
    WindowSize: new Size(800, 600),
    BackgroundColor: new ColorRgba(0xFF181818),
    ObjectSize: new Size(100, 20)));

breakout.Run();
