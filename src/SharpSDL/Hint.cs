using System.Collections.Concurrent;

namespace SharpSDL;
public static class Hint
{
    public static ReadOnlySpan<byte> Get(ReadOnlySpan<byte> name)
    {
        unsafe
        {
            fixed (byte* namePtr = name)
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.GetHint(namePtr));
        }
    }

    public static bool Get(ReadOnlySpan<byte> name, bool defaultValue)
    {
        unsafe
        {
            fixed (byte* namePtr = name)
                return SDL2.GetHintBoolean(namePtr, defaultValue);
        }
    }

    public static bool Set(ReadOnlySpan<byte> name, ReadOnlySpan<byte> value)
    {
        unsafe
        {
            fixed (byte* namePtr = name, valuePtr = value)
                return SDL2.SetHint(namePtr, valuePtr);
        }
    }

    public static bool Set(ReadOnlySpan<byte> name, ReadOnlySpan<byte> value, HintPriority priority)
    {
        unsafe
        {
            fixed (byte* namePtr = name, valuePtr = value)
                return SDL2.SetHintWithPriority(namePtr, valuePtr, (SDL_HintPriority)priority);
        }
    }

    public static bool Reset(ReadOnlySpan<byte> name)
    {
        unsafe
        {
            fixed (byte* namePtr = name)
                return SDL2.ResetHint(namePtr);
        }
    }

    public static void ResetAll() => SDL2.ResetHints();

    public static void AddHintChangedHandler(ReadOnlySpan<byte> name, HintChanged hintChanged, object? userData)
    {
        unsafe
        {
            var ptr = Marshal.GetFunctionPointerForDelegate(
                new HintChangedNative((_, name, oldValue, newValue) => hintChanged.Invoke(
                    userData: userData,
                    name: MemoryMarshal.CreateReadOnlySpanFromNullTerminated(name),
                    oldValue: MemoryMarshal.CreateReadOnlySpanFromNullTerminated(newValue),
                    newValue: MemoryMarshal.CreateReadOnlySpanFromNullTerminated(oldValue))));

            if (!HintChangedCache.Pointers.TryAdd(hintChanged, ptr))
                throw new SdlException("Invalid function pointer");

            fixed (byte* namePtr = name)
                SDL2.AddHintCallback(namePtr, (delegate* unmanaged[Cdecl]<void*, byte*, byte*, byte*, void>)ptr, null);
        }
    }

    public static void RemoveHintChangedHandler(ReadOnlySpan<byte> name, HintChanged hintChanged)
    {
        unsafe
        {
            if (HintChangedCache.Pointers.TryGetValue(hintChanged, out var ptr))
            {
                fixed (byte* namePtr = name)
                    SDL2.DelHintCallback(namePtr, (delegate* unmanaged[Cdecl]<void*, byte*, byte*, byte*, void>)ptr, null);
            }
        }
    }
}

internal static class HintChangedCache
{
    public static readonly ConcurrentDictionary<HintChanged, nint> Pointers = [];
}

public delegate void HintChanged(object? userData, ReadOnlySpan<byte> name, ReadOnlySpan<byte> oldValue, ReadOnlySpan<byte> newValue);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void HintChangedNative(void* userData, byte* name, byte* oldValue, byte* newValue);

public enum HintPriority
{
    Default = SDL_HintPriority.SDL_HINT_DEFAULT,
    Normal = SDL_HintPriority.SDL_HINT_NORMAL,
    Override = SDL_HintPriority.SDL_HINT_OVERRIDE,
}

public static class Hints
{
    public static ReadOnlySpan<byte> ACCELEROMETER_AS_JOYSTICK => SDL2.SDL_HINT_ACCELEROMETER_AS_JOYSTICK;
    public static ReadOnlySpan<byte> ALLOW_ALT_TAB_WHILE_GRABBED => SDL2.SDL_HINT_ALLOW_ALT_TAB_WHILE_GRABBED;
    public static ReadOnlySpan<byte> ALLOW_TOPMOST => SDL2.SDL_HINT_ALLOW_TOPMOST;
    public static ReadOnlySpan<byte> ANDROID_APK_EXPANSION_MAIN_FILE_VERSION => SDL2.SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION;
    public static ReadOnlySpan<byte> ANDROID_APK_EXPANSION_PATCH_FILE_VERSION => SDL2.SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION;
    public static ReadOnlySpan<byte> ANDROID_BLOCK_ON_PAUSE => SDL2.SDL_HINT_ANDROID_BLOCK_ON_PAUSE;
    public static ReadOnlySpan<byte> ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO => SDL2.SDL_HINT_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO;
    public static ReadOnlySpan<byte> ANDROID_TRAP_BACK_BUTTON => SDL2.SDL_HINT_ANDROID_TRAP_BACK_BUTTON;
    public static ReadOnlySpan<byte> APP_NAME => SDL2.SDL_HINT_APP_NAME;
    public static ReadOnlySpan<byte> APPLE_TV_CONTROLLER_UI_EVENTS => SDL2.SDL_HINT_APPLE_TV_CONTROLLER_UI_EVENTS;
    public static ReadOnlySpan<byte> APPLE_TV_REMOTE_ALLOW_ROTATION => SDL2.SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION;
    public static ReadOnlySpan<byte> AUDIO_CATEGORY => SDL2.SDL_HINT_AUDIO_CATEGORY;
    public static ReadOnlySpan<byte> AUDIO_DEVICE_APP_NAME => SDL2.SDL_HINT_AUDIO_DEVICE_APP_NAME;
    public static ReadOnlySpan<byte> AUDIO_DEVICE_STREAM_NAME => SDL2.SDL_HINT_AUDIO_DEVICE_STREAM_NAME;
    public static ReadOnlySpan<byte> AUDIO_DEVICE_STREAM_ROLE => SDL2.SDL_HINT_AUDIO_DEVICE_STREAM_ROLE;
    public static ReadOnlySpan<byte> AUDIO_RESAMPLING_MODE => SDL2.SDL_HINT_AUDIO_RESAMPLING_MODE;
    public static ReadOnlySpan<byte> AUTO_UPDATE_JOYSTICKS => SDL2.SDL_HINT_AUTO_UPDATE_JOYSTICKS;
    public static ReadOnlySpan<byte> AUTO_UPDATE_SENSORS => SDL2.SDL_HINT_AUTO_UPDATE_SENSORS;
    public static ReadOnlySpan<byte> BMP_SAVE_LEGACY_FORMAT => SDL2.SDL_HINT_BMP_SAVE_LEGACY_FORMAT;
    public static ReadOnlySpan<byte> DISPLAY_USABLE_BOUNDS => SDL2.SDL_HINT_DISPLAY_USABLE_BOUNDS;
    public static ReadOnlySpan<byte> EMSCRIPTEN_ASYNCIFY => SDL2.SDL_HINT_EMSCRIPTEN_ASYNCIFY;
    public static ReadOnlySpan<byte> EMSCRIPTEN_KEYBOARD_ELEMENT => SDL2.SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT;
    public static ReadOnlySpan<byte> ENABLE_SCREEN_KEYBOARD => SDL2.SDL_HINT_ENABLE_SCREEN_KEYBOARD;
    public static ReadOnlySpan<byte> ENABLE_STEAM_CONTROLLERS => SDL2.SDL_HINT_ENABLE_STEAM_CONTROLLERS;
    public static ReadOnlySpan<byte> EVENT_LOGGING => SDL2.SDL_HINT_EVENT_LOGGING;
    public static ReadOnlySpan<byte> FORCE_RAISEWINDOW => SDL2.SDL_HINT_FORCE_RAISEWINDOW;
    public static ReadOnlySpan<byte> FRAMEBUFFER_ACCELERATION => SDL2.SDL_HINT_FRAMEBUFFER_ACCELERATION;
    public static ReadOnlySpan<byte> GAMECONTROLLERCONFIG => SDL2.SDL_HINT_GAMECONTROLLERCONFIG;
    public static ReadOnlySpan<byte> GAMECONTROLLERCONFIG_FILE => SDL2.SDL_HINT_GAMECONTROLLERCONFIG_FILE;
    public static ReadOnlySpan<byte> GAMECONTROLLERTYPE => SDL2.SDL_HINT_GAMECONTROLLERTYPE;
    public static ReadOnlySpan<byte> GAMECONTROLLER_IGNORE_DEVICES => SDL2.SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES;
    public static ReadOnlySpan<byte> GAMECONTROLLER_IGNORE_DEVICES_EXCEPT => SDL2.SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES_EXCEPT;
    public static ReadOnlySpan<byte> GAMECONTROLLER_USE_BUTTON_LABELS => SDL2.SDL_HINT_GAMECONTROLLER_USE_BUTTON_LABELS;
    public static ReadOnlySpan<byte> GRAB_KEYBOARD => SDL2.SDL_HINT_GRAB_KEYBOARD;
    public static ReadOnlySpan<byte> HIDAPI_IGNORE_DEVICES => SDL2.SDL_HINT_HIDAPI_IGNORE_DEVICES;
    public static ReadOnlySpan<byte> IDLE_TIMER_DISABLED => SDL2.SDL_HINT_IDLE_TIMER_DISABLED;
    public static ReadOnlySpan<byte> IME_INTERNAL_EDITING => SDL2.SDL_HINT_IME_INTERNAL_EDITING;
    public static ReadOnlySpan<byte> IME_SHOW_UI => SDL2.SDL_HINT_IME_SHOW_UI;
    public static ReadOnlySpan<byte> IME_SUPPORT_EXTENDED_TEXT => SDL2.SDL_HINT_IME_SUPPORT_EXTENDED_TEXT;
    public static ReadOnlySpan<byte> IOS_HIDE_HOME_INDICATOR => SDL2.SDL_HINT_IOS_HIDE_HOME_INDICATOR;
    public static ReadOnlySpan<byte> JOYSTICK_ALLOW_BACKGROUND_EVENTS => SDL2.SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS;
    public static ReadOnlySpan<byte> JOYSTICK_ARCADESTICK_DEVICES => SDL2.SDL_HINT_JOYSTICK_ARCADESTICK_DEVICES;
    public static ReadOnlySpan<byte> JOYSTICK_ARCADESTICK_DEVICES_EXCLUDED => SDL2.SDL_HINT_JOYSTICK_ARCADESTICK_DEVICES_EXCLUDED;
    public static ReadOnlySpan<byte> JOYSTICK_BLACKLIST_DEVICES => SDL2.SDL_HINT_JOYSTICK_BLACKLIST_DEVICES;
    public static ReadOnlySpan<byte> JOYSTICK_BLACKLIST_DEVICES_EXCLUDED => SDL2.SDL_HINT_JOYSTICK_BLACKLIST_DEVICES_EXCLUDED;
    public static ReadOnlySpan<byte> JOYSTICK_FLIGHTSTICK_DEVICES => SDL2.SDL_HINT_JOYSTICK_FLIGHTSTICK_DEVICES;
    public static ReadOnlySpan<byte> JOYSTICK_FLIGHTSTICK_DEVICES_EXCLUDED => SDL2.SDL_HINT_JOYSTICK_FLIGHTSTICK_DEVICES_EXCLUDED;
    public static ReadOnlySpan<byte> JOYSTICK_GAMECUBE_DEVICES => SDL2.SDL_HINT_JOYSTICK_GAMECUBE_DEVICES;
    public static ReadOnlySpan<byte> JOYSTICK_GAMECUBE_DEVICES_EXCLUDED => SDL2.SDL_HINT_JOYSTICK_GAMECUBE_DEVICES_EXCLUDED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI => SDL2.SDL_HINT_JOYSTICK_HIDAPI;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_GAMECUBE => SDL2.SDL_HINT_JOYSTICK_HIDAPI_GAMECUBE;
    public static ReadOnlySpan<byte> JOYSTICK_GAMECUBE_RUMBLE_BRAKE => SDL2.SDL_HINT_JOYSTICK_GAMECUBE_RUMBLE_BRAKE;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_JOY_CONS => SDL2.SDL_HINT_JOYSTICK_HIDAPI_JOY_CONS;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_COMBINE_JOY_CONS => SDL2.SDL_HINT_JOYSTICK_HIDAPI_COMBINE_JOY_CONS;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_VERTICAL_JOY_CONS => SDL2.SDL_HINT_JOYSTICK_HIDAPI_VERTICAL_JOY_CONS;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_LUNA => SDL2.SDL_HINT_JOYSTICK_HIDAPI_LUNA;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_NINTENDO_CLASSIC => SDL2.SDL_HINT_JOYSTICK_HIDAPI_NINTENDO_CLASSIC;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_SHIELD => SDL2.SDL_HINT_JOYSTICK_HIDAPI_SHIELD;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_PS3 => SDL2.SDL_HINT_JOYSTICK_HIDAPI_PS3;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_PS4 => SDL2.SDL_HINT_JOYSTICK_HIDAPI_PS4;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_PS4_RUMBLE => SDL2.SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_PS5 => SDL2.SDL_HINT_JOYSTICK_HIDAPI_PS5;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_PS5_PLAYER_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_PS5_PLAYER_LED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_PS5_RUMBLE => SDL2.SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_STADIA => SDL2.SDL_HINT_JOYSTICK_HIDAPI_STADIA;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_STEAM => SDL2.SDL_HINT_JOYSTICK_HIDAPI_STEAM;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_STEAMDECK => SDL2.SDL_HINT_JOYSTICK_HIDAPI_STEAMDECK;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_SWITCH => SDL2.SDL_HINT_JOYSTICK_HIDAPI_SWITCH;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_SWITCH_HOME_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_SWITCH_HOME_LED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_JOYCON_HOME_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_JOYCON_HOME_LED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_SWITCH_PLAYER_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_SWITCH_PLAYER_LED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_WII => SDL2.SDL_HINT_JOYSTICK_HIDAPI_WII;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_WII_PLAYER_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_WII_PLAYER_LED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_XBOX => SDL2.SDL_HINT_JOYSTICK_HIDAPI_XBOX;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_XBOX_360 => SDL2.SDL_HINT_JOYSTICK_HIDAPI_XBOX_360;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_XBOX_360_PLAYER_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_XBOX_360_PLAYER_LED;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_XBOX_360_WIRELESS => SDL2.SDL_HINT_JOYSTICK_HIDAPI_XBOX_360_WIRELESS;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_XBOX_ONE => SDL2.SDL_HINT_JOYSTICK_HIDAPI_XBOX_ONE;
    public static ReadOnlySpan<byte> JOYSTICK_HIDAPI_XBOX_ONE_HOME_LED => SDL2.SDL_HINT_JOYSTICK_HIDAPI_XBOX_ONE_HOME_LED;
    public static ReadOnlySpan<byte> JOYSTICK_IOKIT => SDL2.SDL_HINT_JOYSTICK_IOKIT;
    public static ReadOnlySpan<byte> JOYSTICK_MFI => SDL2.SDL_HINT_JOYSTICK_MFI;
    public static ReadOnlySpan<byte> JOYSTICK_RAWINPUT => SDL2.SDL_HINT_JOYSTICK_RAWINPUT;
    public static ReadOnlySpan<byte> JOYSTICK_RAWINPUT_CORRELATE_XINPUT => SDL2.SDL_HINT_JOYSTICK_RAWINPUT_CORRELATE_XINPUT;
    public static ReadOnlySpan<byte> JOYSTICK_ROG_CHAKRAM => SDL2.SDL_HINT_JOYSTICK_ROG_CHAKRAM;
    public static ReadOnlySpan<byte> JOYSTICK_THREAD => SDL2.SDL_HINT_JOYSTICK_THREAD;
    public static ReadOnlySpan<byte> JOYSTICK_THROTTLE_DEVICES => SDL2.SDL_HINT_JOYSTICK_THROTTLE_DEVICES;
    public static ReadOnlySpan<byte> JOYSTICK_THROTTLE_DEVICES_EXCLUDED => SDL2.SDL_HINT_JOYSTICK_THROTTLE_DEVICES_EXCLUDED;
    public static ReadOnlySpan<byte> JOYSTICK_WGI => SDL2.SDL_HINT_JOYSTICK_WGI;
    public static ReadOnlySpan<byte> JOYSTICK_WHEEL_DEVICES => SDL2.SDL_HINT_JOYSTICK_WHEEL_DEVICES;
    public static ReadOnlySpan<byte> JOYSTICK_WHEEL_DEVICES_EXCLUDED => SDL2.SDL_HINT_JOYSTICK_WHEEL_DEVICES_EXCLUDED;
    public static ReadOnlySpan<byte> JOYSTICK_ZERO_CENTERED_DEVICES => SDL2.SDL_HINT_JOYSTICK_ZERO_CENTERED_DEVICES;
    public static ReadOnlySpan<byte> KMSDRM_REQUIRE_DRM_MASTER => SDL2.SDL_HINT_KMSDRM_REQUIRE_DRM_MASTER;
    public static ReadOnlySpan<byte> JOYSTICK_DEVICE => SDL2.SDL_HINT_JOYSTICK_DEVICE;
    public static ReadOnlySpan<byte> LINUX_DIGITAL_HATS => SDL2.SDL_HINT_LINUX_DIGITAL_HATS;
    public static ReadOnlySpan<byte> LINUX_HAT_DEADZONES => SDL2.SDL_HINT_LINUX_HAT_DEADZONES;
    public static ReadOnlySpan<byte> LINUX_JOYSTICK_CLASSIC => SDL2.SDL_HINT_LINUX_JOYSTICK_CLASSIC;
    public static ReadOnlySpan<byte> LINUX_JOYSTICK_DEADZONES => SDL2.SDL_HINT_LINUX_JOYSTICK_DEADZONES;
    public static ReadOnlySpan<byte> LOGGING => SDL2.SDL_HINT_LOGGING;
    public static ReadOnlySpan<byte> MAC_BACKGROUND_APP => SDL2.SDL_HINT_MAC_BACKGROUND_APP;
    public static ReadOnlySpan<byte> MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK => SDL2.SDL_HINT_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK;
    public static ReadOnlySpan<byte> MAC_OPENGL_ASYNC_DISPATCH => SDL2.SDL_HINT_MAC_OPENGL_ASYNC_DISPATCH;
    public static ReadOnlySpan<byte> MOUSE_DOUBLE_CLICK_RADIUS => SDL2.SDL_HINT_MOUSE_DOUBLE_CLICK_RADIUS;
    public static ReadOnlySpan<byte> MOUSE_DOUBLE_CLICK_TIME => SDL2.SDL_HINT_MOUSE_DOUBLE_CLICK_TIME;
    public static ReadOnlySpan<byte> MOUSE_FOCUS_CLICKTHROUGH => SDL2.SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH;
    public static ReadOnlySpan<byte> MOUSE_NORMAL_SPEED_SCALE => SDL2.SDL_HINT_MOUSE_NORMAL_SPEED_SCALE;
    public static ReadOnlySpan<byte> MOUSE_RELATIVE_MODE_CENTER => SDL2.SDL_HINT_MOUSE_RELATIVE_MODE_CENTER;
    public static ReadOnlySpan<byte> MOUSE_RELATIVE_MODE_WARP => SDL2.SDL_HINT_MOUSE_RELATIVE_MODE_WARP;
    public static ReadOnlySpan<byte> MOUSE_RELATIVE_SCALING => SDL2.SDL_HINT_MOUSE_RELATIVE_SCALING;
    public static ReadOnlySpan<byte> MOUSE_RELATIVE_SPEED_SCALE => SDL2.SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE;
    public static ReadOnlySpan<byte> MOUSE_RELATIVE_SYSTEM_SCALE => SDL2.SDL_HINT_MOUSE_RELATIVE_SYSTEM_SCALE;
    public static ReadOnlySpan<byte> MOUSE_RELATIVE_WARP_MOTION => SDL2.SDL_HINT_MOUSE_RELATIVE_WARP_MOTION;
    public static ReadOnlySpan<byte> MOUSE_TOUCH_EVENTS => SDL2.SDL_HINT_MOUSE_TOUCH_EVENTS;
    public static ReadOnlySpan<byte> MOUSE_AUTO_CAPTURE => SDL2.SDL_HINT_MOUSE_AUTO_CAPTURE;
    public static ReadOnlySpan<byte> NO_SIGNAL_HANDLERS => SDL2.SDL_HINT_NO_SIGNAL_HANDLERS;
    public static ReadOnlySpan<byte> OPENGL_ES_DRIVER => SDL2.SDL_HINT_OPENGL_ES_DRIVER;
    public static ReadOnlySpan<byte> ORIENTATIONS => SDL2.SDL_HINT_ORIENTATIONS;
    public static ReadOnlySpan<byte> POLL_SENTINEL => SDL2.SDL_HINT_POLL_SENTINEL;
    public static ReadOnlySpan<byte> PREFERRED_LOCALES => SDL2.SDL_HINT_PREFERRED_LOCALES;
    public static ReadOnlySpan<byte> QTWAYLAND_CONTENT_ORIENTATION => SDL2.SDL_HINT_QTWAYLAND_CONTENT_ORIENTATION;
    public static ReadOnlySpan<byte> QTWAYLAND_WINDOW_FLAGS => SDL2.SDL_HINT_QTWAYLAND_WINDOW_FLAGS;
    public static ReadOnlySpan<byte> RENDER_BATCHING => SDL2.SDL_HINT_RENDER_BATCHING;
    public static ReadOnlySpan<byte> RENDER_LINE_METHOD => SDL2.SDL_HINT_RENDER_LINE_METHOD;
    public static ReadOnlySpan<byte> RENDER_DIRECT3D11_DEBUG => SDL2.SDL_HINT_RENDER_DIRECT3D11_DEBUG;
    public static ReadOnlySpan<byte> RENDER_DIRECT3D_THREADSAFE => SDL2.SDL_HINT_RENDER_DIRECT3D_THREADSAFE;
    public static ReadOnlySpan<byte> RENDER_DRIVER => SDL2.SDL_HINT_RENDER_DRIVER;
    public static ReadOnlySpan<byte> RENDER_LOGICAL_SIZE_MODE => SDL2.SDL_HINT_RENDER_LOGICAL_SIZE_MODE;
    public static ReadOnlySpan<byte> RENDER_OPENGL_SHADERS => SDL2.SDL_HINT_RENDER_OPENGL_SHADERS;
    public static ReadOnlySpan<byte> RENDER_SCALE_QUALITY => SDL2.SDL_HINT_RENDER_SCALE_QUALITY;
    public static ReadOnlySpan<byte> RENDER_VSYNC => SDL2.SDL_HINT_RENDER_VSYNC;
    public static ReadOnlySpan<byte> RENDER_METAL_PREFER_LOW_POWER_DEVICE => SDL2.SDL_HINT_RENDER_METAL_PREFER_LOW_POWER_DEVICE;
    public static ReadOnlySpan<byte> ROG_GAMEPAD_MICE => SDL2.SDL_HINT_ROG_GAMEPAD_MICE;
    public static ReadOnlySpan<byte> ROG_GAMEPAD_MICE_EXCLUDED => SDL2.SDL_HINT_ROG_GAMEPAD_MICE_EXCLUDED;
    public static ReadOnlySpan<byte> PS2_DYNAMIC_VSYNC => SDL2.SDL_HINT_PS2_DYNAMIC_VSYNC;
    public static ReadOnlySpan<byte> RETURN_KEY_HIDES_IME => SDL2.SDL_HINT_RETURN_KEY_HIDES_IME;
    public static ReadOnlySpan<byte> RPI_VIDEO_LAYER => SDL2.SDL_HINT_RPI_VIDEO_LAYER;
    public static ReadOnlySpan<byte> SCREENSAVER_INHIBIT_ACTIVITY_NAME => SDL2.SDL_HINT_SCREENSAVER_INHIBIT_ACTIVITY_NAME;
    public static ReadOnlySpan<byte> THREAD_FORCE_REALTIME_TIME_CRITICAL => SDL2.SDL_HINT_THREAD_FORCE_REALTIME_TIME_CRITICAL;
    public static ReadOnlySpan<byte> THREAD_PRIORITY_POLICY => SDL2.SDL_HINT_THREAD_PRIORITY_POLICY;
    public static ReadOnlySpan<byte> THREAD_STACK_SIZE => SDL2.SDL_HINT_THREAD_STACK_SIZE;
    public static ReadOnlySpan<byte> TIMER_RESOLUTION => SDL2.SDL_HINT_TIMER_RESOLUTION;
    public static ReadOnlySpan<byte> TOUCH_MOUSE_EVENTS => SDL2.SDL_HINT_TOUCH_MOUSE_EVENTS;
    public static ReadOnlySpan<byte> VITA_TOUCH_MOUSE_DEVICE => SDL2.SDL_HINT_VITA_TOUCH_MOUSE_DEVICE;
    public static ReadOnlySpan<byte> TV_REMOTE_AS_JOYSTICK => SDL2.SDL_HINT_TV_REMOTE_AS_JOYSTICK;
    public static ReadOnlySpan<byte> VIDEO_ALLOW_SCREENSAVER => SDL2.SDL_HINT_VIDEO_ALLOW_SCREENSAVER;
    public static ReadOnlySpan<byte> VIDEO_DOUBLE_BUFFER => SDL2.SDL_HINT_VIDEO_DOUBLE_BUFFER;
    public static ReadOnlySpan<byte> VIDEO_EGL_ALLOW_TRANSPARENCY => SDL2.SDL_HINT_VIDEO_EGL_ALLOW_TRANSPARENCY;
    public static ReadOnlySpan<byte> VIDEO_EXTERNAL_CONTEXT => SDL2.SDL_HINT_VIDEO_EXTERNAL_CONTEXT;
    public static ReadOnlySpan<byte> VIDEO_HIGHDPI_DISABLED => SDL2.SDL_HINT_VIDEO_HIGHDPI_DISABLED;
    public static ReadOnlySpan<byte> VIDEO_MAC_FULLSCREEN_SPACES => SDL2.SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES;
    public static ReadOnlySpan<byte> VIDEO_MINIMIZE_ON_FOCUS_LOSS => SDL2.SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS;
    public static ReadOnlySpan<byte> VIDEO_WAYLAND_ALLOW_LIBDECOR => SDL2.SDL_HINT_VIDEO_WAYLAND_ALLOW_LIBDECOR;
    public static ReadOnlySpan<byte> VIDEO_WAYLAND_PREFER_LIBDECOR => SDL2.SDL_HINT_VIDEO_WAYLAND_PREFER_LIBDECOR;
    public static ReadOnlySpan<byte> VIDEO_WAYLAND_MODE_EMULATION => SDL2.SDL_HINT_VIDEO_WAYLAND_MODE_EMULATION;
    public static ReadOnlySpan<byte> VIDEO_WAYLAND_EMULATE_MOUSE_WARP => SDL2.SDL_HINT_VIDEO_WAYLAND_EMULATE_MOUSE_WARP;
    public static ReadOnlySpan<byte> VIDEO_WINDOW_SHARE_PIXEL_FORMAT => SDL2.SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT;
    public static ReadOnlySpan<byte> VIDEO_FOREIGN_WINDOW_OPENGL => SDL2.SDL_HINT_VIDEO_FOREIGN_WINDOW_OPENGL;
    public static ReadOnlySpan<byte> VIDEO_FOREIGN_WINDOW_VULKAN => SDL2.SDL_HINT_VIDEO_FOREIGN_WINDOW_VULKAN;
    public static ReadOnlySpan<byte> VIDEO_WIN_D3DCOMPILER => SDL2.SDL_HINT_VIDEO_WIN_D3DCOMPILER;
    public static ReadOnlySpan<byte> VIDEO_X11_FORCE_EGL => SDL2.SDL_HINT_VIDEO_X11_FORCE_EGL;
    public static ReadOnlySpan<byte> VIDEO_X11_NET_WM_BYPASS_COMPOSITOR => SDL2.SDL_HINT_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR;
    public static ReadOnlySpan<byte> VIDEO_X11_NET_WM_PING => SDL2.SDL_HINT_VIDEO_X11_NET_WM_PING;
    public static ReadOnlySpan<byte> VIDEO_X11_WINDOW_VISUALID => SDL2.SDL_HINT_VIDEO_X11_WINDOW_VISUALID;
    public static ReadOnlySpan<byte> VIDEO_X11_XINERAMA => SDL2.SDL_HINT_VIDEO_X11_XINERAMA;
    public static ReadOnlySpan<byte> VIDEO_X11_XRANDR => SDL2.SDL_HINT_VIDEO_X11_XRANDR;
    public static ReadOnlySpan<byte> VIDEO_X11_XVIDMODE => SDL2.SDL_HINT_VIDEO_X11_XVIDMODE;
    public static ReadOnlySpan<byte> WAVE_FACT_CHUNK => SDL2.SDL_HINT_WAVE_FACT_CHUNK;
    public static ReadOnlySpan<byte> WAVE_RIFF_CHUNK_SIZE => SDL2.SDL_HINT_WAVE_RIFF_CHUNK_SIZE;
    public static ReadOnlySpan<byte> WAVE_TRUNCATION => SDL2.SDL_HINT_WAVE_TRUNCATION;
    public static ReadOnlySpan<byte> WINDOWS_DISABLE_THREAD_NAMING => SDL2.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING;
    public static ReadOnlySpan<byte> WINDOWS_ENABLE_MENU_MNEMONICS => SDL2.SDL_HINT_WINDOWS_ENABLE_MENU_MNEMONICS;
    public static ReadOnlySpan<byte> WINDOWS_ENABLE_MESSAGELOOP => SDL2.SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP;
    public static ReadOnlySpan<byte> WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS => SDL2.SDL_HINT_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS;
    public static ReadOnlySpan<byte> WINDOWS_FORCE_SEMAPHORE_KERNEL => SDL2.SDL_HINT_WINDOWS_FORCE_SEMAPHORE_KERNEL;
    public static ReadOnlySpan<byte> WINDOWS_INTRESOURCE_ICON => SDL2.SDL_HINT_WINDOWS_INTRESOURCE_ICON;
    public static ReadOnlySpan<byte> WINDOWS_INTRESOURCE_ICON_SMALL => SDL2.SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL;
    public static ReadOnlySpan<byte> WINDOWS_NO_CLOSE_ON_ALT_F4 => SDL2.SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4;
    public static ReadOnlySpan<byte> WINDOWS_USE_D3D9EX => SDL2.SDL_HINT_WINDOWS_USE_D3D9EX;
    public static ReadOnlySpan<byte> WINDOWS_DPI_AWARENESS => SDL2.SDL_HINT_WINDOWS_DPI_AWARENESS;
    public static ReadOnlySpan<byte> WINDOWS_DPI_SCALING => SDL2.SDL_HINT_WINDOWS_DPI_SCALING;
    public static ReadOnlySpan<byte> WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN => SDL2.SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN;
    public static ReadOnlySpan<byte> WINDOW_NO_ACTIVATION_WHEN_SHOWN => SDL2.SDL_HINT_WINDOW_NO_ACTIVATION_WHEN_SHOWN;
    public static ReadOnlySpan<byte> WINRT_HANDLE_BACK_BUTTON => SDL2.SDL_HINT_WINRT_HANDLE_BACK_BUTTON;
    public static ReadOnlySpan<byte> WINRT_PRIVACY_POLICY_LABEL => SDL2.SDL_HINT_WINRT_PRIVACY_POLICY_LABEL;
    public static ReadOnlySpan<byte> WINRT_PRIVACY_POLICY_URL => SDL2.SDL_HINT_WINRT_PRIVACY_POLICY_URL;
    public static ReadOnlySpan<byte> X11_FORCE_OVERRIDE_REDIRECT => SDL2.SDL_HINT_X11_FORCE_OVERRIDE_REDIRECT;
    public static ReadOnlySpan<byte> XINPUT_ENABLED => SDL2.SDL_HINT_XINPUT_ENABLED;
    public static ReadOnlySpan<byte> DIRECTINPUT_ENABLED => SDL2.SDL_HINT_DIRECTINPUT_ENABLED;
    public static ReadOnlySpan<byte> XINPUT_USE_OLD_JOYSTICK_MAPPING => SDL2.SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING;
    public static ReadOnlySpan<byte> AUDIO_INCLUDE_MONITORS => SDL2.SDL_HINT_AUDIO_INCLUDE_MONITORS;
    public static ReadOnlySpan<byte> X11_WINDOW_TYPE => SDL2.SDL_HINT_X11_WINDOW_TYPE;
    public static ReadOnlySpan<byte> QUIT_ON_LAST_WINDOW_CLOSE => SDL2.SDL_HINT_QUIT_ON_LAST_WINDOW_CLOSE;
    public static ReadOnlySpan<byte> VIDEODRIVER => SDL2.SDL_HINT_VIDEODRIVER;
    public static ReadOnlySpan<byte> AUDIODRIVER => SDL2.SDL_HINT_AUDIODRIVER;
    public static ReadOnlySpan<byte> KMSDRM_DEVICE_INDEX => SDL2.SDL_HINT_KMSDRM_DEVICE_INDEX;
    public static ReadOnlySpan<byte> TRACKPAD_IS_TOUCH_ONLY => SDL2.SDL_HINT_TRACKPAD_IS_TOUCH_ONLY;
    public static ReadOnlySpan<byte> SHUTDOWN_DBUS_ON_QUIT => SDL2.SDL_HINT_SHUTDOWN_DBUS_ON_QUIT;
}