namespace SharpSDL.IO;
public static class CpuInfo
{
    public static int Cores { get => SDL.GetCPUCount(); }

    public static int L1CacheSize { get => SDL.GetCPUCacheLineSize(); }

    public static bool HasRDTSC { get => SDL.HasRDTSC(); }

    public static bool HasAltiVec { get => SDL.HasAltiVec(); }

    public static bool HasMMX { get => SDL.HasMMX(); }

    public static bool Has3DNow { get => SDL.Has3DNow(); }

    public static bool HasSSE { get => SDL.HasSSE(); }

    public static bool HasSSE2 { get => SDL.HasSSE2(); }

    public static bool HasSSE3 { get => SDL.HasSSE3(); }

    public static bool HasSSE41 { get => SDL.HasSSE41(); }

    public static bool HasSSE42 { get => SDL.HasSSE42(); }

    public static bool HasAVX { get => SDL.HasAVX(); }

    public static bool HasAVX2 { get => SDL.HasAVX2(); }

    public static bool HasAVX512F { get => SDL.HasAVX512F(); }

    public static bool HasARMSIMD { get => SDL.HasARMSIMD(); }

    public static bool HasNEON { get => SDL.HasNEON(); }

    public static bool HasLSX { get => SDL.HasLSX(); }

    public static bool HasLASX { get => SDL.HasLASX(); }

    public static int SystemRamMiB { get => SDL.GetSystemRAM(); }
}
