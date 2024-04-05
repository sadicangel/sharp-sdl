using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace SharpSDL;

public static class EventQueue
{
    public static bool HasEvents(EventType type) => SDL.HasEvent((uint)type);

    public static bool HasEvents(EventType minType, EventType maxType) => SDL.HasEvents((uint)minType, (uint)maxType);

    public static void FlushEvents(EventType type) => SDL.FlushEvent((uint)type);

    public static void FlushEvents(EventType minType, EventType maxType) => SDL.FlushEvents((uint)minType, (uint)maxType);

    public static bool PeekEvent(out Event @event)
    {
        unsafe
        {
            fixed (Event* e = &@event)
            {
                var result = SDL.PeepEvents(
                    (SDL_Event*)e,
                    numevents: 1,
                    SDL_eventaction.SDL_PEEKEVENT,
                    (uint)SDL_EventType.SDL_FIRSTEVENT,
                    (uint)SDL_EventType.SDL_LASTEVENT);

                return result switch
                {
                    0 => false,
                    1 => true,
                    _ => SdlException.ThrowLastError<bool>()
                };
            }
        }
    }

    public static int PeekEvents(Span<Event> events, EventType minType = EventType.FirstEvent, EventType maxType = EventType.LastEvent)
    {
        unsafe
        {
            fixed (Event* e = events)
            {
                var result = SDL.PeepEvents(
                    (SDL_Event*)e,
                    events.Length,
                    SDL_eventaction.SDL_PEEKEVENT,
                    (uint)minType,
                    (uint)maxType);

                return result >= 0 ? result : SdlException.ThrowLastError<int>();
            }
        }
    }

    public static bool PollEvent(out Event @event)
    {
        unsafe
        {
            fixed (Event* ptr = &@event)
            {
                return SDL.PollEvent((SDL_Event*)ptr) != 0;
            }
        }
    }

    public static int PollEvents(Span<Event> events, EventType minType = EventType.FirstEvent, EventType maxType = EventType.LastEvent)
    {
        unsafe
        {
            fixed (Event* e = events)
            {
                var result = SDL.PeepEvents(
                    (SDL_Event*)e,
                    events.Length,
                    SDL_eventaction.SDL_GETEVENT,
                    (uint)minType,
                    (uint)maxType);

                return result >= 0 ? result : SdlException.ThrowLastError<int>();
            }
        }
    }

    public static void WaitEvent(out Event @event)
    {
        unsafe
        {
            fixed (Event* ptr = &@event)
            {
                if (SDL.WaitEvent((SDL_Event*)ptr) == 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public static bool WaitEvent(TimeSpan timeout, out Event @event)
    {
        unsafe
        {
            Event* e = null;
            var hasEvent = SdlException.WatchError(() =>
                SDL.WaitEventTimeout((SDL_Event*)e, (int)timeout.TotalMilliseconds) == 1);
            @event = hasEvent ? *e : default;
            return hasEvent;
        }
    }

    public static bool PushEvent(ref readonly Event @event)
    {
        unsafe
        {
            fixed (Event* ptr = &@event)
            {
                return SDL.PushEvent((SDL_Event*)ptr) switch
                {
                    0 => false,
                    1 => true,
                    _ => SdlException.ThrowLastError<bool>()
                };
            }
        }
    }

    public static int PushEvents(ReadOnlySpan<Event> events)
    {
        unsafe
        {
            fixed (Event* e = events)
            {
                var result = SDL.PeepEvents(
                    (SDL_Event*)e,
                    events.Length,
                    SDL_eventaction.SDL_ADDEVENT,
                    (uint)SDL_EventType.SDL_FIRSTEVENT,
                    (uint)SDL_EventType.SDL_LASTEVENT);

                return result >= 0 ? result : SdlException.ThrowLastError<int>();
            }
        }
    }

    public static bool IsEventTypeEnabled(EventType type) =>
        SDL.EventState((uint)type, SDL.SDL_QUERY) == SDL.SDL_ENABLE;

    public static void EnableEventType(EventType type) =>
        SDL.EventState((uint)type, SDL.SDL_ENABLE);

    public static void DisableEventType(EventType type) =>
        SDL.EventState((uint)type, SDL.SDL_DISABLE);

    public static EventType RegisterEvents(int count)
    {
        var result = SDL.RegisterEvents(count);
        return result is uint.MaxValue
            ? throw new SdlException("Unable to register new user-defined events")
            : (EventType)result;
    }

    public static void FilterEvents(EventFilter filter, object? userData)
    {
        unsafe
        {
            var native = new EventWatcherUnmanaged((e, _) =>
                filter.Invoke(ref Unsafe.AsRef<Event>(e), userData) ? 1 : 0);
            var fPtr = Marshal.GetFunctionPointerForDelegate(native);
            SDL.FilterEvents((delegate* unmanaged[Cdecl]<void*, SDL_Event*, int>)fPtr, null);
        }
    }

    public static void AddEventFilter(EventFilter filter, object? userData)
    {
        EventFilterWrapper.Instance.Callback = filter;
        EventFilterWrapper.Instance.CallbackState = userData;
    }

    public static void RemoveEventFilter()
    {
        unsafe
        {
            EventFilterWrapper.Instance.Callback = null;
            EventFilterWrapper.Instance.CallbackState = null;
        }
    }

    public static bool TryGetEventFilter([MaybeNullWhen(false)] out EventFilter filter, out object? userData)
    {
        filter = EventFilterWrapper.Instance?.Callback;
        userData = EventFilterWrapper.Instance?.CallbackState;
        return filter is not null;
    }

    public static void AddEventWatcher(EventWatcher watcher, object? userData) =>
        EventWatcherCache.Watchers.AddOrUpdate(watcher, w => new EventWatcherWrapper(w, userData), (w, p) => p);

    public static void RemoveEventWatcher(EventWatcher watcher)
    {
        if (EventWatcherCache.Watchers.Remove(watcher, out var wrapper))
            wrapper.Dispose();
    }

}

public delegate bool EventFilter(scoped ref readonly Event @event, object? userData);
public delegate void EventWatcher(scoped ref readonly Event @event, object? userData);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate int EventFilterUnmanaged(void* userData, Event* @event);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate int EventWatcherUnmanaged(void* userData, Event* @event);

internal sealed class EventFilterWrapper
{
    private EventFilterUnmanaged? _nativeCallback;
    private EventFilter? _callback;

    public static EventFilterWrapper Instance { get; } = new();

    private EventFilterWrapper() { }

    public EventFilter? Callback
    {
        get => _callback;
        set
        {
            _callback = value;
            unsafe
            {
                if (_callback is not null)
                {
                    _nativeCallback = new EventFilterUnmanaged((_, e) =>
                    {
                        return _callback.Invoke(ref Unsafe.AsRef<Event>(e), CallbackState) ? 1 : 0;
                    });
                    var fPtr = Marshal.GetFunctionPointerForDelegate(_nativeCallback);
                    SDL.SetEventFilter((delegate* unmanaged[Cdecl]<void*, SDL_Event*, int>)fPtr, null);
                }
                else
                {
                    _nativeCallback = null;
                    SDL.SetEventFilter(null, null);
                }
            }
        }
    }
    public object? CallbackState { get; set; }
}

internal sealed class EventWatcherCache
{
    public static readonly ConcurrentDictionary<EventWatcher, EventWatcherWrapper> Watchers = [];
}

internal sealed class EventWatcherWrapper : IDisposable
{
    private readonly EventWatcherUnmanaged _nativeCallback;
    private readonly nint _nativeCallbackPointer;

    public static EventWatcherWrapper? Current { get; set; }

    public EventWatcherWrapper(EventWatcher filter, object? userData)
    {
        Callback = filter;
        CallbackState = userData;
        unsafe
        {
            _nativeCallback = new EventWatcherUnmanaged((_, e) =>
            {
                Callback.Invoke(ref Unsafe.AsRef<Event>(e), CallbackState);
                return 0;
            });
            _nativeCallbackPointer = Marshal.GetFunctionPointerForDelegate(_nativeCallback);
            SDL.AddEventWatch((delegate* unmanaged[Cdecl]<void*, SDL_Event*, int>)_nativeCallbackPointer, null);
        }
    }

    public EventWatcher Callback { get; }
    public object? CallbackState { get; }

    public void Dispose()
    {
        unsafe
        {
            SDL.DelEventWatch((delegate* unmanaged[Cdecl]<void*, SDL_Event*, int>)_nativeCallbackPointer, null);
        }
    }
}