using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
public static class FixBinds
{
    public static void Fix(string dst)
    {
        var files = Directory.GetFiles(dst, "SDL*.cs");

        var main = files.SingleOrDefault(f => f.EndsWith("main.cs"));
        if (main is not null)
        {
            var inLines = File.ReadAllLines(main);
            var outLines = new List<string>();
            outLines.AddRange(inLines[..17]);
            outLines.AddRange(inLines[20..]);
            File.WriteAllLines(main, outLines);
        }

        var pixels = files.SingleOrDefault(f => f.EndsWith("pixels.cs"));
        if (pixels is not null)
        {
            var text = File.ReadAllText(pixels);
            text = text.Replace("public enum SDL_PixelFormatEnum", "public enum SDL_PixelFormatEnum : uint");
            File.WriteAllText(pixels, text);
        }

        var platform = files.SingleOrDefault(f => f.EndsWith("platform.cs"));
        if (platform is not null)
        {
            var inLines = File.ReadAllLines(platform);
            var outLines = new List<string>();
            outLines.AddRange(inLines[..9]);
            outLines.AddRange(inLines[24..]);
            File.WriteAllLines(platform, outLines);
        }

        foreach (var file in files)
        {
            var text = File.ReadAllText(file);
            text = text
                .Replace("public static partial ", "internal static partial ")
                .Replace("public static unsafe partial ", "internal static unsafe partial ")
                .Replace("public enum ", "internal enum ")
                .Replace("public partial ", "internal partial ")
                .Replace("public unsafe partial ", "internal unsafe partial ");
            File.WriteAllText(file, text);
        }
    }
}