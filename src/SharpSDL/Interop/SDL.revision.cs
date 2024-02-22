using System;

namespace SharpSDL.Interop;

public static partial class SDL
{
    [NativeTypeName("#define SDL_REVISION \"\"")]
    public static ReadOnlySpan<byte> SDL_REVISION => ""u8;

    [NativeTypeName("#define SDL_REVISION_NUMBER 0")]
    public const int SDL_REVISION_NUMBER = 0;
}
