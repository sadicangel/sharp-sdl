﻿using System.Diagnostics;

namespace SharpSDL.IO;
public sealed class RwStream : IDisposable
{
    internal readonly unsafe SDL_RWops* _stream;

    public RwStream(ReadOnlySpan<byte> fileName, ReadOnlySpan<byte> fileMode)
    {
        // TODO: Make sure fileMode is null terminated.
        unsafe
        {
            fixed (byte* f = fileName, m = fileMode)
            {
                _stream = SDL2.RWFromFile(f, m);
                if (_stream is null)
                    SdlException.ThrowLastError();
            }
        }
    }

    public RwStream(string fileName, string fileMode)
    {
        // TODO: Make sure fileMode is null terminated.
        unsafe
        {
            SDL_RWops* stream = null;
            fileName.AsUtf8((f, _) => fileMode.AsUtf8((m, l) => stream = SDL2.RWFromFile(f, m)));
            if (stream is null)
                SdlException.ThrowLastError();
        }
    }

    public long Length
    {
        get
        {
            unsafe
            {
                return SDL2.RWsize(_stream) is var length and >= -1 ? length : SdlException.ThrowLastError<long>();
            }
        }
    }

    public long Seek(long offset, SeekOrigin origin)
    {
        unsafe
        {
            return SDL2.RWseek(_stream, offset, (int)origin) is var result and >= 0 ? result : SdlException.ThrowLastError<long>();
        }
    }

    public long Tell()
    {
        unsafe
        {
            return SDL2.RWtell(_stream);
        }
    }

    public RwFile ReadToEnd()
    {
        unsafe
        {
            nuint size = 0;
            void* data = SDL2.LoadFile_RW(_stream, &size, freesrc: 0);
            return new RwFile(data, size);
        }
    }

    public nuint Read<T>(Span<T> buffer) where T : unmanaged
    {
        unsafe
        {
            nuint read = 0;
            SDL2.ClearError();
            fixed (T* ptr = buffer)
                read = SDL2.RWread(_stream, ptr, (nuint)sizeof(T), (nuint)buffer.Length);

            if (read == 0 && MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.GetError()).Length > 0)
                SdlException.ThrowLastError();

            return read;
        }
    }

    public void Write<T>(ReadOnlySpan<T> buffer) where T : unmanaged
    {
        unsafe
        {
            nuint written = 0;
            fixed (T* ptr = buffer)
                written = SDL2.RWwrite(_stream, ptr, (nuint)sizeof(T), (nuint)buffer.Length);
            if (written != (nuint)buffer.Length)
                SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        unsafe
        {
            if (_stream is not null)
            {
                var result = SDL2.RWclose(_stream);
                Debug.Assert(result == 0, StringHelper.ToUtf16(SDL2.GetError()));
                fixed (SDL_RWops** ptr = &_stream)
                    *ptr = null;
            }
        }
    }
}
