namespace SharpSDL.Interop;

internal unsafe partial struct SDL_AudioSpec
{
    public int freq;

    [NativeTypeName("SDL_AudioFormat")]
    public ushort format;

    public byte channels;

    public byte silence;

    public ushort samples;

    public ushort padding;

    public uint size;

    [NativeTypeName("SDL_AudioCallback")]
    public delegate* unmanaged[Cdecl]<void*, byte*, int, void> callback;

    public void* userdata;
}

internal unsafe partial struct SDL_AudioCVT
{
    public int needed;

    [NativeTypeName("SDL_AudioFormat")]
    public ushort src_format;

    [NativeTypeName("SDL_AudioFormat")]
    public ushort dst_format;

    public double rate_incr;

    [NativeTypeName(" *")]
    public byte* buf;

    public int len;

    public int len_cvt;

    public int len_mult;

    public double len_ratio;

    [NativeTypeName("SDL_AudioFilter[10]")]
    public _filters_e__FixedBuffer filters;

    public int filter_index;

    internal unsafe partial struct _filters_e__FixedBuffer
    {
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e0;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e1;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e2;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e3;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e4;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e5;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e6;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e7;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e8;
        public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e9;

        public ref delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> this[int index]
        {
            get
            {
                fixed (delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void>* pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}

internal enum SDL_AudioStatus
{
    SDL_AUDIO_STOPPED = 0,
    SDL_AUDIO_PLAYING,
    SDL_AUDIO_PAUSED,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumAudioDrivers")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetNumAudioDrivers();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetAudioDriver")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetAudioDriver(int index);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioInit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int AudioInit([NativeTypeName("const char *")] byte* driver_name);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioQuit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void AudioQuit();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetCurrentAudioDriver")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetCurrentAudioDriver();

    [LibraryImport("SDL2", EntryPoint = "SDL_OpenAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int OpenAudio(SDL_AudioSpec* desired, SDL_AudioSpec* obtained);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumAudioDevices")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetNumAudioDevices(int iscapture);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetAudioDeviceName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetAudioDeviceName(int index, int iscapture);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetAudioDeviceSpec")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetAudioDeviceSpec(int index, int iscapture, SDL_AudioSpec* spec);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDefaultAudioInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetDefaultAudioInfo([NativeTypeName("char **")] byte** name, SDL_AudioSpec* spec, int iscapture);

    [LibraryImport("SDL2", EntryPoint = "SDL_OpenAudioDevice")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_AudioDeviceID")]
    public static partial uint OpenAudioDevice([NativeTypeName("const char *")] byte* device, int iscapture, [NativeTypeName("const SDL_AudioSpec *")] SDL_AudioSpec* desired, SDL_AudioSpec* obtained, int allowed_changes);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetAudioStatus")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_AudioStatus GetAudioStatus();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetAudioDeviceStatus")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_AudioStatus GetAudioDeviceStatus([NativeTypeName("SDL_AudioDeviceID")] uint dev);

    [LibraryImport("SDL2", EntryPoint = "SDL_PauseAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void PauseAudio(int pause_on);

    [LibraryImport("SDL2", EntryPoint = "SDL_PauseAudioDevice")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void PauseAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev, int pause_on);

    [LibraryImport("SDL2", EntryPoint = "SDL_LoadWAV_RW")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_AudioSpec* LoadWAV_RW(SDL_RWops* src, int freesrc, SDL_AudioSpec* spec, [NativeTypeName(" **")] byte** audio_buf, [NativeTypeName(" *")] uint* audio_len);

    [LibraryImport("SDL2", EntryPoint = "SDL_FreeWAV")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void FreeWAV([NativeTypeName(" *")] byte* audio_buf);

    [LibraryImport("SDL2", EntryPoint = "SDL_BuildAudioCVT")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int BuildAudioCVT(SDL_AudioCVT* cvt, [NativeTypeName("SDL_AudioFormat")] ushort src_format, byte src_channels, int src_rate, [NativeTypeName("SDL_AudioFormat")] ushort dst_format, byte dst_channels, int dst_rate);

    [LibraryImport("SDL2", EntryPoint = "SDL_ConvertAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int ConvertAudio(SDL_AudioCVT* cvt);

    [LibraryImport("SDL2", EntryPoint = "SDL_NewAudioStream")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_AudioStream *")]
    public static partial nint NewAudioStream([NativeTypeName("const SDL_AudioFormat")] ushort src_format, byte src_channels, [NativeTypeName("const int")] int src_rate, [NativeTypeName("const SDL_AudioFormat")] ushort dst_format, byte dst_channels, [NativeTypeName("const int")] int dst_rate);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioStreamPut")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int AudioStreamPut([NativeTypeName("SDL_AudioStream *")] nint stream, [NativeTypeName("const void *")] void* buf, int len);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioStreamGet")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int AudioStreamGet([NativeTypeName("SDL_AudioStream *")] nint stream, void* buf, int len);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioStreamAvailable")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int AudioStreamAvailable([NativeTypeName("SDL_AudioStream *")] nint stream);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioStreamFlush")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int AudioStreamFlush([NativeTypeName("SDL_AudioStream *")] nint stream);

    [LibraryImport("SDL2", EntryPoint = "SDL_AudioStreamClear")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void AudioStreamClear([NativeTypeName("SDL_AudioStream *")] nint stream);

    [LibraryImport("SDL2", EntryPoint = "SDL_FreeAudioStream")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void FreeAudioStream([NativeTypeName("SDL_AudioStream *")] nint stream);

    [LibraryImport("SDL2", EntryPoint = "SDL_MixAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void MixAudio([NativeTypeName(" *")] byte* dst, [NativeTypeName(" *")] byte* src, uint len, int volume);

    [LibraryImport("SDL2", EntryPoint = "SDL_MixAudioFormat")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void MixAudioFormat([NativeTypeName(" *")] byte* dst, [NativeTypeName(" *")] byte* src, [NativeTypeName("SDL_AudioFormat")] ushort format, uint len, int volume);

    [LibraryImport("SDL2", EntryPoint = "SDL_QueueAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int QueueAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev, [NativeTypeName("const void *")] void* data, uint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_DequeueAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint DequeueAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev, void* data, uint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetQueuedAudioSize")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetQueuedAudioSize([NativeTypeName("SDL_AudioDeviceID")] uint dev);

    [LibraryImport("SDL2", EntryPoint = "SDL_ClearQueuedAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ClearQueuedAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev);

    [LibraryImport("SDL2", EntryPoint = "SDL_LockAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LockAudio();

    [LibraryImport("SDL2", EntryPoint = "SDL_LockAudioDevice")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LockAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

    [LibraryImport("SDL2", EntryPoint = "SDL_UnlockAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnlockAudio();

    [LibraryImport("SDL2", EntryPoint = "SDL_UnlockAudioDevice")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnlockAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

    [LibraryImport("SDL2", EntryPoint = "SDL_CloseAudio")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void CloseAudio();

    [LibraryImport("SDL2", EntryPoint = "SDL_CloseAudioDevice")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void CloseAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

    [NativeTypeName("#define SDL_AUDIO_MASK_BITSIZE (0xFF)")]
    public const int SDL_AUDIO_MASK_BITSIZE = (0xFF);

    [NativeTypeName("#define SDL_AUDIO_MASK_DATATYPE (1<<8)")]
    public const int SDL_AUDIO_MASK_DATATYPE = (1 << 8);

    [NativeTypeName("#define SDL_AUDIO_MASK_ENDIAN (1<<12)")]
    public const int SDL_AUDIO_MASK_ENDIAN = (1 << 12);

    [NativeTypeName("#define SDL_AUDIO_MASK_SIGNED (1<<15)")]
    public const int SDL_AUDIO_MASK_SIGNED = (1 << 15);

    [NativeTypeName("#define AUDIO_U8 0x0008")]
    public const int AUDIO_U8 = 0x0008;

    [NativeTypeName("#define AUDIO_S8 0x8008")]
    public const int AUDIO_S8 = 0x8008;

    [NativeTypeName("#define AUDIO_U16LSB 0x0010")]
    public const int AUDIO_U16LSB = 0x0010;

    [NativeTypeName("#define AUDIO_S16LSB 0x8010")]
    public const int AUDIO_S16LSB = 0x8010;

    [NativeTypeName("#define AUDIO_U16MSB 0x1010")]
    public const int AUDIO_U16MSB = 0x1010;

    [NativeTypeName("#define AUDIO_S16MSB 0x9010")]
    public const int AUDIO_S16MSB = 0x9010;

    [NativeTypeName("#define AUDIO_U16 AUDIO_U16LSB")]
    public const int AUDIO_U16 = 0x0010;

    [NativeTypeName("#define AUDIO_S16 AUDIO_S16LSB")]
    public const int AUDIO_S16 = 0x8010;

    [NativeTypeName("#define AUDIO_S32LSB 0x8020")]
    public const int AUDIO_S32LSB = 0x8020;

    [NativeTypeName("#define AUDIO_S32MSB 0x9020")]
    public const int AUDIO_S32MSB = 0x9020;

    [NativeTypeName("#define AUDIO_S32 AUDIO_S32LSB")]
    public const int AUDIO_S32 = 0x8020;

    [NativeTypeName("#define AUDIO_F32LSB 0x8120")]
    public const int AUDIO_F32LSB = 0x8120;

    [NativeTypeName("#define AUDIO_F32MSB 0x9120")]
    public const int AUDIO_F32MSB = 0x9120;

    [NativeTypeName("#define AUDIO_F32 AUDIO_F32LSB")]
    public const int AUDIO_F32 = 0x8120;

    [NativeTypeName("#define AUDIO_U16SYS AUDIO_U16LSB")]
    public const int AUDIO_U16SYS = 0x0010;

    [NativeTypeName("#define AUDIO_S16SYS AUDIO_S16LSB")]
    public const int AUDIO_S16SYS = 0x8010;

    [NativeTypeName("#define AUDIO_S32SYS AUDIO_S32LSB")]
    public const int AUDIO_S32SYS = 0x8020;

    [NativeTypeName("#define AUDIO_F32SYS AUDIO_F32LSB")]
    public const int AUDIO_F32SYS = 0x8120;

    [NativeTypeName("#define SDL_AUDIO_ALLOW_FREQUENCY_CHANGE 0x00000001")]
    public const int SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;

    [NativeTypeName("#define SDL_AUDIO_ALLOW_FORMAT_CHANGE 0x00000002")]
    public const int SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;

    [NativeTypeName("#define SDL_AUDIO_ALLOW_CHANNELS_CHANGE 0x00000004")]
    public const int SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;

    [NativeTypeName("#define SDL_AUDIO_ALLOW_SAMPLES_CHANGE 0x00000008")]
    public const int SDL_AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008;

    [NativeTypeName("#define SDL_AUDIO_ALLOW_ANY_CHANGE (SDL_AUDIO_ALLOW_FREQUENCY_CHANGE|SDL_AUDIO_ALLOW_FORMAT_CHANGE|SDL_AUDIO_ALLOW_CHANNELS_CHANGE|SDL_AUDIO_ALLOW_SAMPLES_CHANGE)")]
    public const int SDL_AUDIO_ALLOW_ANY_CHANGE = (0x00000001 | 0x00000002 | 0x00000004 | 0x00000008);

    [NativeTypeName("#define SDL_AUDIOCVT_MAX_FILTERS 9")]
    public const int SDL_AUDIOCVT_MAX_FILTERS = 9;

    [NativeTypeName("#define SDL_MIX_MAXVOLUME 128")]
    public const int SDL_MIX_MAXVOLUME = 128;
}
