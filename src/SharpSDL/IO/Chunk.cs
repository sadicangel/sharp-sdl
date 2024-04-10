namespace SharpSDL.IO;

public sealed class Chunk : IDisposable
{
    internal readonly unsafe Mix_Chunk* _chunk;

    public Chunk(ReadOnlySpan<byte> fileName)
    {
        unsafe
        {
            fixed (byte* f = fileName)
                _chunk = SDL2.Mix_LoadWAV(f);
            if (_chunk is null)
                SdlException.ThrowLastError();
        }
    }

    public Chunk(string fileName)
    {
        unsafe
        {
            Mix_Chunk* chunk = null;
            fileName.AsUtf8((f, _) => chunk = SDL2.Mix_LoadWAV(f));
            if (chunk is null)
                SdlException.ThrowLastError();
            _chunk = chunk;
        }
    }

    public Chunk(RwStream stream)
    {
        unsafe
        {
            _chunk = SDL2.Mix_LoadWAV_RW(stream._stream, freesrc: 0);
            if (_chunk is null)
                SdlException.ThrowLastError();
        }
    }

    public int Volume
    {
        get
        {
            unsafe
            {
                return SDL2.Mix_VolumeChunk(_chunk, -1);
            }
        }
        set
        {
            unsafe
            {
                _ = SDL2.Mix_VolumeChunk(_chunk, value);
            }
        }
    }

    public void Dispose()
    {
        unsafe
        {
            if (_chunk is not null)
            {
                SDL2.Mix_FreeChunk(_chunk);
                fixed (Mix_Chunk** ptr = &_chunk)
                    *ptr = null;
            }
        }
    }

}