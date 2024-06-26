﻿namespace SharpSDL;

public sealed class SdlTimer : IDisposable
{
    private readonly uint _interval;
    private readonly TimerCallbackUnmanaged _nativeCallback;
    private readonly int _nativeCallbackId;

    private readonly Func<uint, object?, uint> _callback;
    private readonly object? _callbackState;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate uint TimerCallbackUnmanaged(uint interval, void* state);

    public SdlTimer(uint interval, Func<uint, object?, uint> callback, object? callbackState)
    {
        _interval = interval;
        _callback = callback;
        _callbackState = callbackState;
        unsafe
        {
            _nativeCallback = new TimerCallbackUnmanaged((interval, _) => _callback.Invoke(interval, _callbackState));
            var fPtr = (delegate* unmanaged[Cdecl]<uint, void*, uint>)Marshal.GetFunctionPointerForDelegate(_nativeCallback).ToPointer();
            _nativeCallbackId = SDL2.AddTimer(interval, fPtr, null);
        }
    }

    public void Dispose()
    {
        if (_nativeCallbackId != 0)
        {
            SDL2.RemoveTimer(_nativeCallbackId);
            ref var id = ref Unsafe.AsRef(in _nativeCallbackId);
            id = 0;
        }
    }

    public static ulong GetTicks() => SDL2.GetTicks64();

    public static ulong GetPerformanceCounter() => SDL2.GetPerformanceCounter();

    public static ulong GetPerformanceFrequency() => SDL2.GetPerformanceFrequency();

    public static void Delay(TimeSpan delay) => SDL2.Delay((uint)delay.TotalMilliseconds);
}
