using SharpSDL.Objects;

namespace SharpSDL;

public readonly struct Surface
{
    public readonly SurfaceFlags flags;
    public readonly unsafe PixelFormat* format;
    public readonly int Width;
    public readonly int Height;
    public readonly int Pitch;
    public readonly nint Pixels;
    public readonly nint UserData;
    public readonly int Locked;
    public readonly nint BlitMap;
    public readonly Rect ClipRect;
    public readonly nint Map;
    public readonly int RefCount;
}

public enum SurfaceFlags : uint
{
    SwCompat = SDL.SDL_SWSURFACE,
    PreAllocated = SDL.SDL_PREALLOC,
    RunLengthEncoded = SDL.SDL_RLEACCEL,
    InternalReference = SDL.SDL_DONTFREE,
    SimdAligned = SDL.SDL_SIMD_ALIGNED,
}