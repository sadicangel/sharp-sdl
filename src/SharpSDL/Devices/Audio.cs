﻿namespace SharpSDL.Devices;
public abstract class Audio : IDisposable
{
    protected readonly uint _audio;
    protected readonly AudioSpec _spec;
    protected readonly AudioQueue _queue;

    protected Audio(ReadOnlySpan<byte> name, AudioSpec spec, AudioPermissions permissions, bool isPlayback)
    {
        unsafe
        {
            fixed (byte* namePtr = name)
            {
                var desired = spec.ToNative();
                var obtained = default(SDL_AudioSpec);
                var audio = SDL.OpenAudioDevice(namePtr, iscapture: isPlayback ? 0 : 1, &desired, &obtained, (int)permissions);
                if (audio is 0)
                    SdlException.ThrowLastError();

                _audio = audio;
                _spec = AudioSpec.FromNative(&obtained);
                _queue = new AudioQueue(_audio);
            }
        }
    }

    protected Audio(string name, AudioSpec spec, AudioPermissions permissions, bool isPlayback)
    {
        unsafe
        {
            (_audio, _spec) = name.AsUtf8((namePtr, _) =>
            {
                var obtained = default(SDL_AudioSpec);
                var desired = spec.ToNative();
                var audio = SDL.OpenAudioDevice(namePtr, iscapture: isPlayback ? 0 : 1, &desired, &obtained, (int)permissions);
                if (audio is 0)
                    SdlException.ThrowLastError();

                return (audio, AudioSpec.FromNative(&obtained));
            });
            _queue = new AudioQueue(_audio);
        }
    }

    public AudioStatus Status { get => (AudioStatus)SDL.GetAudioDeviceStatus(_audio); }

    public bool IsPaused { get => Status is AudioStatus.Paused; set => SDL.PauseAudioDevice(_audio, value ? 1 : 0); }

    public static int GetDriverCount() => SDL.GetNumAudioDrivers();

    public void Dispose()
    {
        if (_audio is not 0)
        {
            unsafe
            {
                SDL.CloseAudioDevice(_audio);
                fixed (uint* ptr = &_audio)
                    *ptr = 0;
            }
            GC.SuppressFinalize(this);
        }
    }

    public virtual IAudioQueue Queue { get => _queue; }
}

public enum AudioStatus
{
    Stopped = SDL_AudioStatus.SDL_AUDIO_STOPPED,
    Playing = SDL_AudioStatus.SDL_AUDIO_PLAYING,
    Paused = SDL_AudioStatus.SDL_AUDIO_PAUSED,
}

public sealed class AudioPlayback : Audio
{

    public AudioPlayback(ReadOnlySpan<byte> name, AudioSpec spec, AudioPermissions permissions = AudioPermissions.AnyChange)
        : base(name, spec, permissions, isPlayback: true)
    {
    }

    public AudioPlayback(string name, AudioSpec spec, AudioPermissions permissions = AudioPermissions.AnyChange)
        : base(name, spec, permissions, isPlayback: true)
    {
    }

    public override IAudioPlaybackQueue Queue { get => _queue; }

    public static int GetPlaybackDeviceCount() => SDL.GetNumAudioDevices(iscapture: 0);
}

public sealed class AudioRecording : Audio
{
    public AudioRecording(ReadOnlySpan<byte> name, AudioSpec spec, AudioPermissions permissions = AudioPermissions.AnyChange)
        : base(name, spec, permissions, isPlayback: false)
    {
    }

    public AudioRecording(string name, AudioSpec spec, AudioPermissions permissions = AudioPermissions.AnyChange)
        : base(name, spec, permissions, isPlayback: false)
    {
    }

    public override IAudioRecordingQueue Queue { get => _queue; }

    public static int GetRecordingDeviceCount() => SDL.GetNumAudioDevices(iscapture: 1);
}

[Flags]
public enum AudioFormat : ushort
{
    U8 = SDL.AUDIO_U8,
    S8 = SDL.AUDIO_S8,
    U16LSB = SDL.AUDIO_U16LSB,
    S16LSB = SDL.AUDIO_S16LSB,
    U16MSB = SDL.AUDIO_U16MSB,
    S16MSB = SDL.AUDIO_S16MSB,
    U16 = SDL.AUDIO_U16,
    S16 = SDL.AUDIO_S16,
    S32LSB = SDL.AUDIO_S32LSB,
    S32MSB = SDL.AUDIO_S32MSB,
    S32 = SDL.AUDIO_S32,
    F32LSB = SDL.AUDIO_F32LSB,
    F32MSB = SDL.AUDIO_F32MSB,
    F32 = SDL.AUDIO_F32,
}

[Flags]
public enum AudioPermissions
{
    FrequencyChange = SDL.SDL_AUDIO_ALLOW_FREQUENCY_CHANGE,
    FormatChange = SDL.SDL_AUDIO_ALLOW_FORMAT_CHANGE,
    ChannelsChange = SDL.SDL_AUDIO_ALLOW_CHANNELS_CHANGE,
    SamplesChange = SDL.SDL_AUDIO_ALLOW_SAMPLES_CHANGE,
    AnyChange = SDL.SDL_AUDIO_ALLOW_ANY_CHANGE,
}

public delegate void RequestAudio(Span<byte> buffer, object? userData);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void RequestAudioUnmanaged(void* userData, byte* buffer, int length);

public sealed class AudioSpec
{
    public int Frequency { get; init; }
    public AudioFormat Format { get; init; }
    public byte Channels { get; init; }
    public byte Silence { get; init; }
    public short Samples { get; init; }
    public uint Size { get; init; }
    public RequestAudio? RequestAudio { get; init; }
    public object? UserData { get; init; }

    internal unsafe SDL_AudioSpec ToNative()
    {
        var d = new SDL_AudioSpec
        {
            freq = Frequency,
            format = (ushort)Format,
            channels = Channels,
            silence = Silence,
            size = Size
        };
        if (RequestAudio is not null)
        {
            var f = new RequestAudioUnmanaged((_, buffer, length) => RequestAudio(new Span<byte>(buffer, length), UserData));
            d.callback = (delegate* unmanaged[Cdecl]<void*, byte*, int, void>)Marshal.GetFunctionPointerForDelegate(f);
        }
        return d;
    }

    internal static unsafe AudioSpec FromNative(SDL_AudioSpec* spec)
    {
        return new AudioSpec
        {
            Frequency = spec->freq,
            Format = (AudioFormat)spec->format,
            Channels = spec->channels,
            Silence = spec->silence,
            Size = spec->size,
        };
    }
}

public interface IAudioQueue
{
    int Length { get; }
    void Clear();
}

public interface IAudioPlaybackQueue : IAudioQueue
{
    void Enqueue(ReadOnlySpan<byte> buffer);
}

public interface IAudioRecordingQueue : IAudioQueue
{
    int Dequeue(Span<byte> buffer);
}

public sealed class AudioQueue(uint audio) : IAudioPlaybackQueue, IAudioRecordingQueue
{
    public int Length { get => (int)SDL.GetQueuedAudioSize(audio); }

    public void Clear() => SDL.ClearQueuedAudio(audio);

    public void Enqueue(ReadOnlySpan<byte> buffer)
    {
        unsafe
        {
            fixed (byte* data = buffer)
            {
                if (SDL.QueueAudio(audio, data, (uint)buffer.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public int Dequeue(Span<byte> buffer)
    {
        unsafe
        {
            SDL.ClearError();
            var bytesRead = 0;
            fixed (byte* data = buffer)
            {
                bytesRead = (int)SDL.DequeueAudio(audio, data, (uint)buffer.Length);
            }
            var _error = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetError());
            if (_error.Length > 0)
                throw new SdlException(StringHelper.ToUtf16(_error));
            return bytesRead;
        };
    }

}