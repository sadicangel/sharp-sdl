using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    [Flags]
    public enum AudioAllowedFlags
    {
        [NativeTypeName("#define SDL_AUDIO_ALLOW_FREQUENCY_CHANGE 0x00000001")]
        FREQUENCY_CHANGE = 0x00000001,

        [NativeTypeName("#define SDL_AUDIO_ALLOW_FORMAT_CHANGE 0x00000002")]
        FORMAT_CHANGE = 0x00000002,

        [NativeTypeName("#define SDL_AUDIO_ALLOW_CHANNELS_CHANGE 0x00000004")]
        CHANNELS_CHANGE = 0x00000004,

        [NativeTypeName("#define SDL_AUDIO_ALLOW_SAMPLES_CHANGE 0x00000008")]
        SAMPLES_CHANGE = 0x00000008,

        [NativeTypeName("#define SDL_AUDIO_ALLOW_ANY_CHANGE (SDL_AUDIO_ALLOW_FREQUENCY_CHANGE|SDL_AUDIO_ALLOW_FORMAT_CHANGE|SDL_AUDIO_ALLOW_CHANNELS_CHANGE|SDL_AUDIO_ALLOW_SAMPLES_CHANGE)")]
        ANY_CHANGE = (0x00000001 | 0x00000002 | 0x00000004 | 0x00000008),
    }

    [Flags]
    public enum AudioFormat : ushort
    {
        [NativeTypeName("#define AUDIO_U8 0x0008")]
        U8 = 0x0008,
        [NativeTypeName("#define AUDIO_S8 0x8008")]
        S8 = 0x8008,
        [NativeTypeName("#define AUDIO_U16LSB 0x0010")]
        U16LSB = 0x0010,
        [NativeTypeName("#define AUDIO_S16LSB 0x8010")]
        S16LSB = 0x8010,
        [NativeTypeName("#define AUDIO_U16MSB 0x1010")]
        U16MSB = 0x1010,
        [NativeTypeName("#define AUDIO_S16MSB 0x9010")]
        S16MSB = 0x9010,
        [NativeTypeName("#define AUDIO_U16 AUDIO_U16LSB")]
        U16 = 0x0010,
        [NativeTypeName("#define AUDIO_S16 AUDIO_S16LSB")]
        S16 = 0x8010,
        [NativeTypeName("#define AUDIO_S32LSB 0x8020")]
        S32LSB = 0x8020,
        [NativeTypeName("#define AUDIO_S32MSB 0x9020")]
        S32MSB = 0x9020,
        [NativeTypeName("#define AUDIO_S32 AUDIO_S32LSB")]
        S32 = 0x8020,
        [NativeTypeName("#define AUDIO_F32LSB 0x8120")]
        F32LSB = 0x8120,
        [NativeTypeName("#define AUDIO_F32MSB 0x9120")]
        F32MSB = 0x9120,
        [NativeTypeName("#define AUDIO_F32 AUDIO_F32LSB")]
        F32 = 0x8120,
        [NativeTypeName("#define AUDIO_U16SYS AUDIO_U16LSB")]
        U16SYS = 0x0010,
        [NativeTypeName("#define AUDIO_S16SYS AUDIO_S16LSB")]
        S16SYS = 0x8010,
        [NativeTypeName("#define AUDIO_S32SYS AUDIO_S32LSB")]
        S32SYS = 0x8020,
        [NativeTypeName("#define AUDIO_F32SYS AUDIO_F32LSB")]
        F32SYS = 0x8120,
    }

    public unsafe partial struct AudioSpec
    {
        public int freq;

        public AudioFormat format;

        public byte channels;

        public byte silence;

        public ushort samples;

        public ushort padding;

        public uint size;

        [NativeTypeName("SDL_AudioCallback")]
        public delegate* unmanaged[Cdecl]<void*, byte*, int, void> callback;

        public void* userdata;
    }

    public unsafe partial struct AudioCVT
    {
        public int needed;

        public AudioFormat src_format;

        public AudioFormat dst_format;

        public double rate_incr;

        public byte* buf;

        public int len;

        public int len_cvt;

        public int len_mult;

        public double len_ratio;

        [NativeTypeName("SDL_AudioFilter[10]")]
        public _filters_e__FixedBuffer filters;

        public int filter_index;

        public unsafe partial struct _filters_e__FixedBuffer
        {
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e0;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e1;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e2;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e3;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e4;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e5;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e6;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e7;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e8;
            public delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> e9;

            public ref delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void> this[int index]
            {
                get
                {
                    fixed (delegate* unmanaged[Cdecl]<AudioCVT*, ushort, void>* pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public enum AudioStatus
    {
        STOPPED = 0,
        PLAYING,
        PAUSED,
    }

    public partial struct _SDL_AudioStream
    {
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAudioDrivers", ExactSpelling = true)]
        public static extern int GetNumAudioDrivers();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDriver", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetAudioDriver(int index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioInit", ExactSpelling = true)]
        public static extern int AudioInit([NativeTypeName("const char *")] byte* driver_name);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioQuit", ExactSpelling = true)]
        public static extern void AudioQuit();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentAudioDriver", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetCurrentAudioDriver();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudio", ExactSpelling = true)]
        public static extern int OpenAudio(AudioSpec* desired, AudioSpec* obtained);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAudioDevices", ExactSpelling = true)]
        public static extern int GetNumAudioDevices(int iscapture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetAudioDeviceName(int index, int iscapture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceSpec", ExactSpelling = true)]
        public static extern int GetAudioDeviceSpec(int index, int iscapture, AudioSpec* spec);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDefaultAudioInfo", ExactSpelling = true)]
        public static extern int GetDefaultAudioInfo([NativeTypeName("char **")] byte** name, AudioSpec* spec, int iscapture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudioDevice", ExactSpelling = true)]
        [return: NativeTypeName("SDL_AudioDeviceID")]
        public static extern uint OpenAudioDevice([NativeTypeName("const char *")] byte* device, int iscapture, [NativeTypeName("const AudioSpec *")] AudioSpec* desired, AudioSpec* obtained, AudioAllowedFlags allowed_changes);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioStatus", ExactSpelling = true)]
        public static extern AudioStatus GetAudioStatus();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceStatus", ExactSpelling = true)]
        public static extern AudioStatus GetAudioDeviceStatus([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PauseAudio", ExactSpelling = true)]
        public static extern void PauseAudio(int pause_on);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PauseAudioDevice", ExactSpelling = true)]
        public static extern void PauseAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev, int pause_on);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadWAV_RW", ExactSpelling = true)]
        public static extern AudioSpec* LoadWAV_RW(RWops* src, int freesrc, AudioSpec* spec, [NativeTypeName(" **")] byte** audio_buf, [NativeTypeName(" *")] uint* audio_len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeWAV", ExactSpelling = true)]
        public static extern void FreeWAV([NativeTypeName(" *")] byte* audio_buf);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_BuildAudioCVT", ExactSpelling = true)]
        public static extern int BuildAudioCVT(AudioCVT* cvt, AudioFormat src_format, byte src_channels, int src_rate, AudioFormat dst_format, byte dst_channels, int dst_rate);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertAudio", ExactSpelling = true)]
        public static extern int ConvertAudio(AudioCVT* cvt);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NewAudioStream", ExactSpelling = true)]
        [return: NativeTypeName("SDL_AudioStream *")]
        public static extern _SDL_AudioStream* NewAudioStream(AudioFormat src_format, byte src_channels, [NativeTypeName("const int")] int src_rate, AudioFormat dst_format, [NativeTypeName("const ")] byte dst_channels, [NativeTypeName("const int")] int dst_rate);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamPut", ExactSpelling = true)]
        public static extern int AudioStreamPut([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream, [NativeTypeName("const void *")] void* buf, int len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamGet", ExactSpelling = true)]
        public static extern int AudioStreamGet([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream, void* buf, int len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamAvailable", ExactSpelling = true)]
        public static extern int AudioStreamAvailable([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamFlush", ExactSpelling = true)]
        public static extern int AudioStreamFlush([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamClear", ExactSpelling = true)]
        public static extern void AudioStreamClear([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeAudioStream", ExactSpelling = true)]
        public static extern void FreeAudioStream([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MixAudio", ExactSpelling = true)]
        public static extern void MixAudio([NativeTypeName(" *")] byte* dst, [NativeTypeName("const  *")] byte* src, uint len, int volume);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MixAudioFormat", ExactSpelling = true)]
        public static extern void MixAudioFormat([NativeTypeName(" *")] byte* dst, [NativeTypeName("const  *")] byte* src, AudioFormat format, uint len, int volume);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueueAudio", ExactSpelling = true)]
        public static extern int QueueAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev, [NativeTypeName("const void *")] void* data, uint len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DequeueAudio", ExactSpelling = true)]
        public static extern uint DequeueAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev, void* data, uint len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetQueuedAudioSize", ExactSpelling = true)]
        public static extern uint GetQueuedAudioSize([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearQueuedAudio", ExactSpelling = true)]
        public static extern void ClearQueuedAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockAudio", ExactSpelling = true)]
        public static extern void LockAudio();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockAudioDevice", ExactSpelling = true)]
        public static extern void LockAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockAudio", ExactSpelling = true)]
        public static extern void UnlockAudio();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockAudioDevice", ExactSpelling = true)]
        public static extern void UnlockAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CloseAudio", ExactSpelling = true)]
        public static extern void CloseAudio();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CloseAudioDevice", ExactSpelling = true)]
        public static extern void CloseAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [NativeTypeName("#define SDL_AUDIO_MASK_BITSIZE (0xFF)")]
        public const int SDL_AUDIO_MASK_BITSIZE = (0xFF);

        [NativeTypeName("#define SDL_AUDIO_MASK_DATATYPE (1<<8)")]
        public const int SDL_AUDIO_MASK_DATATYPE = (1 << 8);

        [NativeTypeName("#define SDL_AUDIO_MASK_ENDIAN (1<<12)")]
        public const int SDL_AUDIO_MASK_ENDIAN = (1 << 12);

        [NativeTypeName("#define SDL_AUDIO_MASK_SIGNED (1<<15)")]
        public const int SDL_AUDIO_MASK_SIGNED = (1 << 15);

        [NativeTypeName("#define SDL_AUDIOCVT_MAX_FILTERS 9")]
        public const int SDL_AUDIOCVT_MAX_FILTERS = 9;

        [NativeTypeName("#define SDL_MIX_MAXVOLUME 128")]
        public const int SDL_MIX_MAXVOLUME = 128;
    }
}
