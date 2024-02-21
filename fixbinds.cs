using System.Collections.Generic;
using System.IO;
using System;
public static class FixBinds
{
    public static void Process(string[] files)
    {
        var map = new Dictionary<string, string>()
        {
            ["HWND__*"] = "nint",
            ["HDC__*"] = "nint",
            ["HINSTANCE__*"] = "nint",
        };

        foreach (var file in files)
        {
            foreach (var line in File.ReadLines(file))
            {
                var span = line.AsSpan().Trim();
                if (span.Contains("struct SDL_", StringComparison.Ordinal) || span.Contains("enum SDL_", StringComparison.Ordinal))
                {
                    var start = span.IndexOf("SDL_");
                    var end = span[(start + 1)..].IndexOfAny(" \r\n");
                    span = span[start..];
                    if (end >= 0) span = span[..end];

                    var key = span.ToString();
                    var value = key switch
                    {
                        "SDL_bool" => "CBool",
                        "SDL_WindowShapeMode" => "WindowShape",
                        "SDL_errorcode" => "ErrorCode",
                        "SDL_eventaction" => "EventAction",
                        "SDL_version" => "Version",
                        _ => span[4..].ToString()
                    };

                    map[key] = value;
                    Console.WriteLine($"{key} => {value}");
                }
            }
        }

        foreach (var file in files)
        {
            var text = File.ReadAllText(file);
            foreach (var (key, value) in map)
                text = text.Replace(key, value);
            File.WriteAllText(file, text);
        }
    }
}