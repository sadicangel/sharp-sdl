namespace SharpSDL.Devices;
public sealed class Cursor : IDisposable
{
    internal readonly nint _cursor;
    internal readonly bool _owned = true;

    internal Cursor(nint cursor, bool owned)
    {
        _cursor = cursor;
        _owned = owned;
    }

    public Cursor(ReadOnlySpan<byte> data, ReadOnlySpan<byte> mask, Size size, Point topLeft)
    {
        unsafe
        {
            fixed (byte* dataPtr = data, maskPtr = mask)
            {
                _cursor = SDL.CreateCursor(dataPtr, maskPtr, size.Width, size.Height, topLeft.X, topLeft.Y);
                if (_cursor is 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public Cursor(Surface surface, Point topLeft)
    {
        unsafe
        {
            _cursor = SDL.CreateColorCursor((SDL_Surface*)&surface, topLeft.X, topLeft.Y);
            if (_cursor is 0)
                SdlException.ThrowLastError();
        }
    }

    public Cursor(SystemCursor cursor)
    {
        _cursor = SDL.CreateSystemCursor((SDL_SystemCursor)cursor);
        if (_cursor is 0)
            SdlException.ThrowLastError();
    }

    public static Cursor? DefaultCursor { get => SDL.GetDefaultCursor() is var cursor and not 0 ? new Cursor(cursor, false) : null; }

    public static Cursor? ActiveCursor
    {
        get => SDL.GetCursor() is var cursor and not 0 ? new Cursor(cursor, false) : null;
        set => SDL.SetCursor(value?._cursor ?? 0);
    }

    public static bool IsCursorVisible
    {
        get => SDL.ShowCursor(SDL.SDL_QUERY) switch
        {
            SDL.SDL_ENABLE => true,
            SDL.SDL_DISABLE => false,
            _ => SdlException.ThrowLastError<bool>()
        };
        set
        {
            if (SDL.ShowCursor(value ? SDL.SDL_ENABLE : SDL.SDL_DISABLE) < 0)
                SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        if (_owned && _cursor is not 0)
        {
            unsafe
            {
                SDL.FreeCursor(_cursor);
                ref var ptr = ref Unsafe.AsRef(in _cursor);
                ptr = 0;
            }
        }
    }
}

public enum SystemCursor
{
    Arrow = SDL_SystemCursor.SDL_SYSTEM_CURSOR_ARROW,
    IBeam = SDL_SystemCursor.SDL_SYSTEM_CURSOR_IBEAM,
    Wait = SDL_SystemCursor.SDL_SYSTEM_CURSOR_WAIT,
    Crosshair = SDL_SystemCursor.SDL_SYSTEM_CURSOR_CROSSHAIR,
    WaitArrow = SDL_SystemCursor.SDL_SYSTEM_CURSOR_WAITARROW,
    SizeNWSE = SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENWSE,
    SizeNESW = SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENESW,
    SizeWE = SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEWE,
    SizeNS = SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENS,
    SizeAll = SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEALL,
    No = SDL_SystemCursor.SDL_SYSTEM_CURSOR_NO,
    Hand = SDL_SystemCursor.SDL_SYSTEM_CURSOR_HAND,
}
