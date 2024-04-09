namespace SharpSDL.IO;
public static class CpuInfo
{
    public static int Cores { get => SDL2.GetCPUCount(); }

    public static int L1CacheSize { get => SDL2.GetCPUCacheLineSize(); }

    public static bool HasRDTSC { get => SDL2.HasRDTSC(); }

    public static bool HasAltiVec { get => SDL2.HasAltiVec(); }

    public static bool HasMMX { get => SDL2.HasMMX(); }

    public static bool Has3DNow { get => SDL2.Has3DNow(); }

    public static bool HasSSE { get => SDL2.HasSSE(); }

    public static bool HasSSE2 { get => SDL2.HasSSE2(); }

    public static bool HasSSE3 { get => SDL2.HasSSE3(); }

    public static bool HasSSE41 { get => SDL2.HasSSE41(); }

    public static bool HasSSE42 { get => SDL2.HasSSE42(); }

    public static bool HasAVX { get => SDL2.HasAVX(); }

    public static bool HasAVX2 { get => SDL2.HasAVX2(); }

    public static bool HasAVX512F { get => SDL2.HasAVX512F(); }

    public static bool HasARMSIMD { get => SDL2.HasARMSIMD(); }

    public static bool HasNEON { get => SDL2.HasNEON(); }

    public static bool HasLSX { get => SDL2.HasLSX(); }

    public static bool HasLASX { get => SDL2.HasLASX(); }

    public static int SystemRamMiB { get => SDL2.GetSystemRAM(); }
}
