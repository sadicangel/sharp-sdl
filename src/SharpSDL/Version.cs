﻿namespace SharpSDL;
public readonly record struct Version(byte Major, byte Minor, byte Patch)
{
    public readonly byte Major = Major;
    public readonly byte Minor = Minor;
    public readonly byte Patch = Patch;

    public override string ToString() => $"SDL {Major}.{Minor}.{Patch}";

    public static Version GetVersion()
    {
        unsafe
        {
            Unsafe.SkipInit(out Version version);
            SDL2.GetVersion((SDL_version*)&version);
            return version;
        }
    }

    public static string GetPlatform()
    {
        unsafe
        {
            return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.GetPlatform()).ToStringUtf16();
        }
    }

    public static Version GetMixerVersion()
    {
        unsafe
        {
            var version = (Version*)SDL2.Mix_Linked_Version();
            return *version;
        }
    }
}