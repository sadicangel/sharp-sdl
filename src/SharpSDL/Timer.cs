namespace SharpSDL;

public sealed class Timer : IDisposable
{
    private readonly uint _interval;
    private readonly TimerCallbackUnmanaged _nativeCallback;
    private readonly int _nativeCallbackId;

    private readonly Func<uint, object?, uint> _callback;
    private readonly object? _callbackState;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate uint TimerCallbackUnmanaged(uint interval, void* state);

    public Timer(uint interval, Func<uint, object?, uint> callback, object? callbackState)
    {
        _interval = interval;
        _callback = callback;
        _callbackState = callbackState;
        unsafe
        {
            _nativeCallback = new TimerCallbackUnmanaged((interval, _) => _callback.Invoke(interval, _callbackState));
            _nativeCallbackId = SDL.AddTimer(interval, (delegate* unmanaged[Cdecl]<uint, void*, uint>)Marshal.GetFunctionPointerForDelegate(_nativeCallback).ToPointer(), null);
        }
    }

    public void Dispose()
    {
        if (_nativeCallbackId != 0)
        {
            SDL.RemoveTimer(_nativeCallbackId);
            ref var id = ref Unsafe.AsRef(in _nativeCallbackId);
            id = 0;
        }
    }

    public static ulong GetTicks() => SDL.GetTicks64();

    public static ulong GetPerformanceCounter() => SDL.GetPerformanceCounter();

    public static ulong GetPerformanceFrequency() => SDL.GetPerformanceFrequency();

    public static void Delay(uint milliseconds) => SDL.Delay(milliseconds);
}
