namespace SharpSDL.IO;

public sealed class Music : IDisposable
{
    internal readonly nint _music;

    public Music(ReadOnlySpan<byte> fileName)
    {
        unsafe
        {
            fixed (byte* f = fileName)
                _music = SDL2.Mix_LoadMUS(f);
            if (_music is 0)
                SdlException.ThrowLastError();
        }
    }

    public Music(string fileName)
    {
        unsafe
        {
            _music = fileName.AsUtf8((f, _) => SDL2.Mix_LoadMUS(f));
            if (_music is 0)
                SdlException.ThrowLastError();
        }
    }

    public Music(RwStream stream)
    {
        unsafe
        {
            _music = SDL2.Mix_LoadMUS_RW(stream._stream, freesrc: 0);
            if (_music is 0)
                SdlException.ThrowLastError();
        }
    }

    public Music(RwStream stream, MusicType musicType)
    {
        unsafe
        {
            _music = SDL2.Mix_LoadMUSType_RW(stream._stream, (Mix_MusicType)musicType, freesrc: 0);
            if (_music is 0)
                SdlException.ThrowLastError();
        }
    }

    public MusicType Type { get => (MusicType)SDL2.Mix_GetMusicType(_music); }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.Mix_GetMusicTitle(_music));
            }
        }
    }

    public ReadOnlySpan<byte> Title
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.Mix_GetMusicTitleTag(_music));
            }
        }
    }

    public ReadOnlySpan<byte> Artist
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.Mix_GetMusicArtistTag(_music));
            }
        }
    }

    public ReadOnlySpan<byte> Album
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.Mix_GetMusicAlbumTag(_music));
            }
        }
    }

    public ReadOnlySpan<byte> Copyright
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.Mix_GetMusicCopyrightTag(_music));
            }
        }
    }

    public int Volume
    {
        get
        {
            unsafe
            {
                return SDL2.Mix_GetMusicVolume(_music);
            }
        }
    }

    public void Dispose()
    {
        if (_music is not 0)
        {
            unsafe
            {
                SDL2.Mix_FreeMusic(_music);
                fixed (nint* ptr = &_music)
                    *ptr = 0;
            }
        }
    }
}

public enum MusicType
{
    None = Mix_MusicType.MUS_NONE,
    Cmd = Mix_MusicType.MUS_CMD,
    Wav = Mix_MusicType.MUS_WAV,
    Mod = Mix_MusicType.MUS_MOD,
    Mid = Mix_MusicType.MUS_MID,
    Ogg = Mix_MusicType.MUS_OGG,
    Mp3 = Mix_MusicType.MUS_MP3,
    Mp3MadUnused = Mix_MusicType.MUS_MP3_MAD_UNUSED,
    Flac = Mix_MusicType.MUS_FLAC,
    ModPlugUnused = Mix_MusicType.MUS_MODPLUG_UNUSED,
    Opus = Mix_MusicType.MUS_OPUS,
    WavPack = Mix_MusicType.MUS_WAVPACK,
    Gme = Mix_MusicType.MUS_GME,
}