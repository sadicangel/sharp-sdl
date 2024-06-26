﻿using SharpSDL.Devices;
using System.Collections.Concurrent;

namespace SharpSDL.IO;

public delegate void AudioMixDelegate(Span<byte> buffer);
public delegate void MusicFinished();
public delegate void ChannelFinished(int channel);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void AudioMixDelegateUnmanaged(void* userData, byte* stream, int length);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void MusicFinishedUnmanaged();
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void ChannelFinishedUnmanaged(int channel);

public sealed class Mixer : IDisposable
{
    private static readonly object Mutex = new();
    private static bool Initialized;
    private static bool IsAudioOpen;
    private readonly ConcurrentDictionary<int, List<EffectWrapper>> _effects = [];

    public event AudioMixDelegate HookMusic
    {
        add
        {
            unsafe
            {
                var f = new AudioMixDelegateUnmanaged((_, stream, length) => value.Invoke(new Span<byte>(stream, length)));
                SDL2.Mix_HookMusic((delegate* unmanaged[Cdecl]<void*, byte*, int, void>)Marshal.GetFunctionPointerForDelegate(f), null);
            }
        }
        remove
        {
            unsafe
            {
                SDL2.Mix_HookMusic(null, null);
            }
        }
    }
    public event AudioMixDelegate AudioMixed
    {
        add
        {
            unsafe
            {
                var f = new AudioMixDelegateUnmanaged((_, stream, length) => value.Invoke(new Span<byte>(stream, length)));
                SDL2.Mix_SetPostMix((delegate* unmanaged[Cdecl]<void*, byte*, int, void>)Marshal.GetFunctionPointerForDelegate(f), null);
            }
        }
        remove
        {
            unsafe
            {
                SDL2.Mix_SetPostMix(null, null);
            }
        }
    }
    public event MusicFinished MusicFinished
    {
        add
        {
            unsafe
            {
                var f = new MusicFinishedUnmanaged(value.Invoke);
                SDL2.Mix_HookMusicFinished((delegate* unmanaged[Cdecl]<void>)Marshal.GetFunctionPointerForDelegate(f));
            }
        }
        remove
        {
            unsafe
            {
                SDL2.Mix_HookMusicFinished(null);
            }
        }
    }
    public event ChannelFinished ChannelFinished
    {
        add
        {
            unsafe
            {
                var f = new ChannelFinishedUnmanaged(value.Invoke);
                SDL2.Mix_ChannelFinished((delegate* unmanaged[Cdecl]<int, void>)Marshal.GetFunctionPointerForDelegate(f));
            }
        }
        remove
        {
            unsafe
            {
                SDL2.Mix_ChannelFinished(null);
            }
        }
    }

    public Mixer(MixerFlags flags)
    {
        lock (Mutex)
        {
            if (Initialized)
                throw new SdlException("SDL already initialized");
            Initialized = true;
            if (SDL2.Mix_Init((int)flags) == 0)
                SdlException.ThrowLastError();
        }
    }

    public MixerFlags Flags { get => (MixerFlags)SDL2.Mix_Init(0); }

    public int Channels { get => SDL2.Mix_AllocateChannels(-1); set => _ = SDL2.Mix_AllocateChannels(value); }

    public void OpenAudio(int frequency, AudioFormat format, int channels, int chunkSize)
    {
        lock (Mutex)
        {
            IsAudioOpen = SDL2.Mix_OpenAudio(frequency, (ushort)format, channels, chunkSize) == 0 || SdlException.ThrowLastError<bool>();
        }
    }

    public void OpenAudio(int frequency, AudioFormat format, int channels, int chunkSize, string device, AudioPermissions permissions)
    {
        lock (Mutex)
        {
            unsafe
            {
                var result = device.AsUtf8((f, _) =>
                    SDL2.Mix_OpenAudioDevice(frequency, (ushort)format, channels, chunkSize, f, (int)permissions));
                IsAudioOpen = result == 0 || SdlException.ThrowLastError<bool>();
            }
        }
    }

    public void Pause() => SDL2.Mix_PauseAudio(pause_on: 1);

    public void Resume() => SDL2.Mix_PauseAudio(pause_on: 0);

    public bool QueryAudioSpec(out int frequency, out AudioFormat format, out int channels)
    {
        unsafe
        {
            fixed (int* p1 = &frequency)
            fixed (AudioFormat* p2 = &format)
            fixed (int* p3 = &channels)
                return SDL2.Mix_QuerySpec(p1, (ushort*)p2, p3) == 1;
        }
    }

    public int ChunkDecodersCount() => SDL2.Mix_GetNumChunkDecoders();

    public string? GetChunkDecoder(int index)
    {
        unsafe
        {
            return SDL2.Mix_GetChunkDecoder(index) is var ptr and not null
                ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(ptr).ToStringUtf16()
                : null;
        }
    }

    public bool HasChunkDecoder(string name)
    {
        unsafe
        {
            return name.AsUtf8((f, _) => SDL2.Mix_HasChunkDecoder(f));
        }
    }

    public int MusicDecodersCount() => SDL2.Mix_GetNumMusicDecoders();

    public string? GetMusicDecoder(int index)
    {
        unsafe
        {
            return SDL2.Mix_GetMusicDecoder(index) is var ptr and not null
                ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(ptr).ToStringUtf16()
                : null;
        }
    }

    public bool HasMusicDecoder(string name)
    {
        unsafe
        {
            return name.AsUtf8((f, _) => SDL2.Mix_HasMusicDecoder(f));
        }
    }

    public void RegisterEffect(int channel, ApplyAudioEffect applyEffect, AudioEffectDone? effectDone, object? userData)
    {
        _effects.AddOrUpdate(
            channel,
            c => [new EffectWrapper(channel, applyEffect, effectDone)],
            (c, l) =>
            {
                l.Add(new EffectWrapper(channel, applyEffect, effectDone));
                return l;
            });
    }

    public void UnregisterEffect(int channel, ApplyAudioEffect applyEffect)
    {
        if (_effects.TryGetValue(channel, out var list))
        {
            if (list.RemoveAll(w => w.ApplyEffect == applyEffect) == 0)
                SdlException.ThrowLastError();
        }
    }

    public void UnregisterAllEffects(int channel)
    {
        if (_effects.Remove(channel, out var list))
            if (SDL2.Mix_UnregisterAllEffects(channel) == 0)
                SdlException.ThrowLastError();
    }

    public void SetPanning(int channel, byte left, byte right)
    {
        if (SDL2.Mix_SetPanning(channel, left, right) == 0)
            SdlException.ThrowLastError();
    }

    public void SetPosition(int channel, short angle, byte distance)
    {
        if (SDL2.Mix_SetPosition(channel, angle, distance) == 0)
            SdlException.ThrowLastError();
    }

    public void SetDistance(int channel, byte distance)
    {
        if (SDL2.Mix_SetDistance(channel, distance) == 0)
            SdlException.ThrowLastError();
    }

    public void SetReverseStereo(int channel, int flip)
    {
        if (SDL2.Mix_SetReverseStereo(channel, flip) == 0)
            SdlException.ThrowLastError();
    }

    public int GetChannelsVolume() => SDL2.Mix_Volume(-1, -1);
    public void SetChannelsVolume(int volume) => _ = SDL2.Mix_Volume(-1, volume);

    public int GetChannelVolume(int channel) => SDL2.Mix_Volume(channel, -1);
    public void SetChannelVolume(int channel, int volume) => _ = SDL2.Mix_Volume(channel, volume);

    public int GetMusicVolume() => SDL2.Mix_VolumeMusic(-1);
    public void SetMusicVolume(int volume) => _ = SDL2.Mix_VolumeMusic(volume);

    public int GetMasterVolume() => SDL2.Mix_MasterVolume(-1);
    public void SetMasterVolume(int volume) => _ = SDL2.Mix_MasterVolume(volume);

    public int ReserveChannels(int count) => SDL2.Mix_ReserveChannels(count);

    public int PlayChannel(int channel, Chunk chunk, int loops, TimeSpan duration = default, TimeSpan fadeTime = default)
    {
        unsafe
        {
            return fadeTime == default
                ? SDL2.Mix_PlayChannelTimed(
                    channel,
                    chunk._chunk,
                    loops,
                    duration == default ? -1 : (int)duration.TotalMilliseconds)
                : SDL2.Mix_FadeInChannelTimed(
                    channel,
                    chunk._chunk,
                    loops,
                    (int)fadeTime.TotalMilliseconds,
                    duration == default ? -1 : (int)duration.TotalMilliseconds);
        }
    }

    public void HaltChannel(int channel, TimeSpan fadeTime = default)
    {
        var result = fadeTime == default
            ? SDL2.Mix_HaltChannel(channel)
            : SDL2.Mix_FadeOutChannel(channel, (int)fadeTime.TotalMilliseconds);

        if (result != 0)
            SdlException.ThrowLastError();
    }

    public void HaltChannelAfter(int channel, TimeSpan duration) =>
        _ = SDL2.Mix_ExpireChannel(channel, (int)duration.TotalMilliseconds);

    public void HaltChannelsAfter(TimeSpan duration) => HaltChannel(-1, duration);

    public void HaltChannels(TimeSpan fadeTime = default) => HaltChannel(-1, fadeTime);

    public void PlayMusic(Music music, int loops = 0, TimeSpan fadeTime = default, TimeSpan startAt = default)
    {
        unsafe
        {
            if (SDL2.Mix_FadeInMusicPos(music._music, loops, (int)fadeTime.TotalMilliseconds, startAt.TotalSeconds) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void HaltMusic(TimeSpan fadeTime = default)
    {
        _ = fadeTime == default
            ? SDL2.Mix_HaltMusic()
            : SDL2.Mix_FadeOutMusic((int)fadeTime.TotalMilliseconds);
    }

    public FadingStatus GetChannelFadingStatus(int channel) => (FadingStatus)SDL2.Mix_FadingChannel(channel);

    public FadingStatus GetMusicFadingStatus() => (FadingStatus)SDL2.Mix_FadingMusic();

    public void PauseChannel(int channel) => SDL2.Mix_Pause(channel);
    public void PauseChannels() => PauseChannel(-1);

    public void ResumeChannel(int channel) => SDL2.Mix_Resume(channel);
    public void ResumeChannels() => ResumeChannel(-1);

    public bool IsChannelPaused(int channel) => SDL2.Mix_Paused(channel) == 1;
    public int GetChannelsPausedCount() => SDL2.Mix_Paused(-1);

    public void PauseMusic() => SDL2.Mix_PauseMusic();
    public void ResumeMusic() => SDL2.Mix_ResumeMusic();
    public bool IsMusicPaused() => SDL2.Mix_PausedMusic() == 1;

    public void RewindMusic() => SDL2.Mix_RewindMusic();

    public void Dispose()
    {
        lock (Mutex)
        {
            if (IsAudioOpen)
            {
                IsAudioOpen = false;
                SDL2.Mix_CloseAudio();
            }
            if (Initialized)
            {
                Initialized = false;
                SDL2.Mix_Quit();
            }
        }
    }
}

[Flags]
public enum MixerFlags
{
    Flac = MIX_InitFlags.MIX_INIT_FLAC,
    Mod = MIX_InitFlags.MIX_INIT_MOD,
    Mp3 = MIX_InitFlags.MIX_INIT_MP3,
    Ogg = MIX_InitFlags.MIX_INIT_OGG,
    Mid = MIX_InitFlags.MIX_INIT_MID,
    Opus = MIX_InitFlags.MIX_INIT_OPUS,
    WavPack = MIX_InitFlags.MIX_INIT_WAVPACK,
}

public enum FadingStatus
{
    None = Mix_Fading.MIX_NO_FADING,
    FadingOut = Mix_Fading.MIX_FADING_OUT,
    FadingIn = Mix_Fading.MIX_FADING_IN,
}

public delegate void ApplyAudioEffect(int channel, Span<byte> buffer);
public delegate void AudioEffectDone(int channel);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void ApplyAudioEffectUnmanaged(int channel, byte* buffer, int length, void* userData);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void AudioEffectDoneUnmanaged(int channel, void* userData);

internal sealed class EffectWrapper
{
    private readonly ApplyAudioEffectUnmanaged _applyEffectNativeCallback;
    private readonly AudioEffectDoneUnmanaged? _effectDoneNativeCallback;

    public EffectWrapper(int channel, ApplyAudioEffect applyEffect, AudioEffectDone? effectDone)
    {
        ApplyEffect = applyEffect;
        EffectDone = effectDone;
        unsafe
        {
            _applyEffectNativeCallback = new ApplyAudioEffectUnmanaged((channel, stream, length, _) => ApplyEffect(channel, new Span<byte>(stream, length)));
            if (EffectDone is not null)
                _effectDoneNativeCallback = new AudioEffectDoneUnmanaged((channel, _) => EffectDone.Invoke(channel));

            var f1 = Marshal.GetFunctionPointerForDelegate(_applyEffectNativeCallback);
            var f2 = _effectDoneNativeCallback is not null ? Marshal.GetFunctionPointerForDelegate(_effectDoneNativeCallback).ToPointer() : null;

            if (SDL2.Mix_RegisterEffect(
                channel,
                (delegate* unmanaged[Cdecl]<int, void*, int, void*, void>)f1,
                (delegate* unmanaged[Cdecl]<int, void*, void>)f2,
                null) == 0)
                SdlException.ThrowLastError();
        }
    }

    public ApplyAudioEffect ApplyEffect { get; }

    public AudioEffectDone? EffectDone { get; }
}
