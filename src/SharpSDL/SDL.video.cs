using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    public enum SDL_GLattr
    {
        SDL_GL_RED_SIZE,
        SDL_GL_GREEN_SIZE,
        SDL_GL_BLUE_SIZE,
        SDL_GL_ALPHA_SIZE,
        SDL_GL_BUFFER_SIZE,
        SDL_GL_DOUBLEBUFFER,
        SDL_GL_DEPTH_SIZE,
        SDL_GL_STENCIL_SIZE,
        SDL_GL_ACCUM_RED_SIZE,
        SDL_GL_ACCUM_GREEN_SIZE,
        SDL_GL_ACCUM_BLUE_SIZE,
        SDL_GL_ACCUM_ALPHA_SIZE,
        SDL_GL_STEREO,
        SDL_GL_MULTISAMPLEBUFFERS,
        SDL_GL_MULTISAMPLESAMPLES,
        SDL_GL_ACCELERATED_VISUAL,
        SDL_GL_RETAINED_BACKING,
        SDL_GL_CONTEXT_MAJOR_VERSION,
        SDL_GL_CONTEXT_MINOR_VERSION,
        SDL_GL_CONTEXT_EGL,
        SDL_GL_CONTEXT_FLAGS,
        SDL_GL_CONTEXT_PROFILE_MASK,
        SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
        SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
        SDL_GL_CONTEXT_RELEASE_BEHAVIOR,
        SDL_GL_CONTEXT_RESET_NOTIFICATION,  /* Requires >= 2.0.6 */
        SDL_GL_CONTEXT_NO_ERROR,        /* Requires >= 2.0.6 */
    }

    [Flags]
    public enum SDL_GLprofile
    {
        SDL_GL_CONTEXT_PROFILE_CORE = 0x0001,
        SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 0x0002,
        SDL_GL_CONTEXT_PROFILE_ES = 0x0004
    }

    [Flags]
    public enum SDL_GLcontext
    {
        SDL_GL_CONTEXT_DEBUG_FLAG = 0x0001,
        SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x0002,
        SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 0x0004,
        SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 0x0008
    }

    public enum SDL_WindowEventID : byte
    {
        SDL_WINDOWEVENT_NONE,
        SDL_WINDOWEVENT_SHOWN,
        SDL_WINDOWEVENT_HIDDEN,
        SDL_WINDOWEVENT_EXPOSED,
        SDL_WINDOWEVENT_MOVED,
        SDL_WINDOWEVENT_RESIZED,
        SDL_WINDOWEVENT_SIZE_CHANGED,
        SDL_WINDOWEVENT_MINIMIZED,
        SDL_WINDOWEVENT_MAXIMIZED,
        SDL_WINDOWEVENT_RESTORED,
        SDL_WINDOWEVENT_ENTER,
        SDL_WINDOWEVENT_LEAVE,
        SDL_WINDOWEVENT_FOCUS_GAINED,
        SDL_WINDOWEVENT_FOCUS_LOST,
        SDL_WINDOWEVENT_CLOSE,
        // 2.0.5 and above.
        SDL_WINDOWEVENT_TAKE_FOCUS,
        SDL_WINDOWEVENT_HIT_TEST,
        // 2.0.18 and above.
        SDL_WINDOWEVENT_ICCPROF_CHANGED,
        SDL_WINDOWEVENT_DISPLAY_CHANGED
    }

    public enum SDL_DisplayEventID : byte
    {
        SDL_DISPLAYEVENT_NONE,
        SDL_DISPLAYEVENT_ORIENTATION,
        // 2.0.14 and above.
        SDL_DISPLAYEVENT_CONNECTED,
        // 2.0.14 and above.
        SDL_DISPLAYEVENT_DISCONNECTED
    }

    public enum SDL_DisplayOrientation
    {
        SDL_ORIENTATION_UNKNOWN,
        SDL_ORIENTATION_LANDSCAPE,
        SDL_ORIENTATION_LANDSCAPE_FLIPPED,
        SDL_ORIENTATION_PORTRAIT,
        SDL_ORIENTATION_PORTRAIT_FLIPPED
    }

    // 2.0.16 and above.
    public enum SDL_FlashOperation
    {
        SDL_FLASH_CANCEL,
        SDL_FLASH_BRIEFLY,
        SDL_FLASH_UNTIL_FOCUSED
    }

    [Flags]
    public enum SDL_WindowFlags : uint
    {
        SDL_WINDOW_FULLSCREEN = 0x00000001,
        SDL_WINDOW_OPENGL = 0x00000002,
        SDL_WINDOW_SHOWN = 0x00000004,
        SDL_WINDOW_HIDDEN = 0x00000008,
        SDL_WINDOW_BORDERLESS = 0x00000010,
        SDL_WINDOW_RESIZABLE = 0x00000020,
        SDL_WINDOW_MINIMIZED = 0x00000040,
        SDL_WINDOW_MAXIMIZED = 0x00000080,
        SDL_WINDOW_MOUSE_GRABBED = 0x00000100,
        SDL_WINDOW_INPUT_FOCUS = 0x00000200,
        SDL_WINDOW_MOUSE_FOCUS = 0x00000400,
        SDL_WINDOW_FULLSCREEN_DESKTOP =
            SDL_WINDOW_FULLSCREEN | 0x00001000,
        SDL_WINDOW_FOREIGN = 0x00000800,
        // 2.0.1 and above.
        SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000,
        // 2.0.4 and above.
        SDL_WINDOW_MOUSE_CAPTURE = 0x00004000,
        // 2.0.5 and above.
        SDL_WINDOW_ALWAYS_ON_TOP = 0x00008000,
        SDL_WINDOW_SKIP_TASKBAR = 0x00010000,
        SDL_WINDOW_UTILITY = 0x00020000,
        SDL_WINDOW_TOOLTIP = 0x00040000,
        SDL_WINDOW_POPUP_MENU = 0x00080000,
        // 2.0.16 and above.
        SDL_WINDOW_KEYBOARD_GRABBED = 0x00100000,
        // 2.0.6 and above.
        SDL_WINDOW_VULKAN = 0x10000000,
        // 2.0.14 and above.
        SDL_WINDOW_METAL = 0x2000000,

        SDL_WINDOW_INPUT_GRABBED =
            SDL_WINDOW_MOUSE_GRABBED,
    }

    // 2.0.4 and above.
    public enum SDL_HitTestResult
    {
        SDL_HITTEST_NORMAL,
        SDL_HITTEST_DRAGGABLE,
        SDL_HITTEST_RESIZE_TOPLEFT,
        SDL_HITTEST_RESIZE_TOP,
        SDL_HITTEST_RESIZE_TOPRIGHT,
        SDL_HITTEST_RESIZE_RIGHT,
        SDL_HITTEST_RESIZE_BOTTOMRIGHT,
        SDL_HITTEST_RESIZE_BOTTOM,
        SDL_HITTEST_RESIZE_BOTTOMLEFT,
        SDL_HITTEST_RESIZE_LEFT
    }

    public const int SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000;
    public const int SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000;
    public const int SDL_WINDOWPOS_UNDEFINED = 0x1FFF0000;
    public const int SDL_WINDOWPOS_CENTERED = 0x2FFF0000;

    public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int X)
    {
        return SDL_WINDOWPOS_UNDEFINED_MASK | X;
    }

    public static bool SDL_WINDOWPOS_ISUNDEFINED(int X)
    {
        return (X & 0xFFFF0000) == SDL_WINDOWPOS_UNDEFINED_MASK;
    }

    public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int X)
    {
        return SDL_WINDOWPOS_CENTERED_MASK | X;
    }

    public static bool SDL_WINDOWPOS_ISCENTERED(int X)
    {
        return (X & 0xFFFF0000) == SDL_WINDOWPOS_CENTERED_MASK;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DisplayMode
    {
        public uint format;
        public int w;
        public int h;
        public int refresh_rate;
        public nint driverdata; // nint
    }

    [InlineArray(256)]
    public struct GammaRampChannel
    {
#pragma warning disable IDE0051 // Remove unused private members
        private ushort _element0;
#pragma warning restore IDE0051 // Remove unused private members
    }

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial /*SDL_Window*/ nint SDL_CreateWindow(byte* title, int x, int y, int w, int h, SDL_WindowFlags flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_CreateWindowAndRenderer(int width, int height, SDL_WindowFlags window_flags, out /*SDL_Window*/ nint window, out /*SDL_Renderer*/ nint renderer);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Window*/ nint SDL_CreateWindowFrom(nint data);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_DestroyWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_DisableScreenSaver();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_EnableScreenSaver();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetClosestDisplayMode(int displayIndex, ref SDL_DisplayMode mode, out SDL_DisplayMode closest);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetCurrentDisplayMode(int displayIndex, out SDL_DisplayMode mode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* SDL_GetCurrentVideoDriver();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetDesktopDisplayMode(int displayIndex, out SDL_DisplayMode mode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* SDL_GetDisplayName(int index);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetDisplayBounds(int displayIndex, out SDL_Rect rect);

    // 2.0.4 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetDisplayDPI(int displayIndex, out float ddpi, out float hdpi, out float vdpi);

    // 2.0.9 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_DisplayOrientation SDL_GetDisplayOrientation(int displayIndex);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetDisplayMode(int displayIndex, int modeIndex, out SDL_DisplayMode mode);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetDisplayUsableBounds(int displayIndex, out SDL_Rect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetNumDisplayModes(int displayIndex);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetNumVideoDisplays();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetNumVideoDrivers();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* SDL_GetVideoDriver(int index);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float SDL_GetWindowBrightness(/*SDL_Window*/ nint window);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowOpacity(/*SDL_Window*/ nint window, float opacity);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetWindowOpacity(/*SDL_Window*/ nint window, out float out_opacity);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowModalFor(/*SDL_Window*/ nint modal_window, /*SDL_Window*/ nint parent_window);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowInputFocus(nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial nint SDL_GetWindowData(/*SDL_Window*/ nint window, byte* name);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetWindowDisplayIndex(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetWindowDisplayMode(/*SDL_Window*/ nint window, out SDL_DisplayMode mode);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetWindowICCProfile(/*SDL_Window*/ nint window, out nuint mode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_GetWindowFlags(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Window*/ nint SDL_GetWindowFromID(uint id);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetWindowGammaRamp(/*SDL_Window*/ nint window, out GammaRampChannel red, out GammaRampChannel green, out GammaRampChannel blue);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_GetWindowGrab(/*SDL_Window*/ nint window);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_GetWindowKeyboardGrab(/*SDL_Window*/ nint window);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_GetWindowMouseGrab(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_GetWindowID(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_GetWindowPixelFormat(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetWindowMaximumSize(/*SDL_Window*/ nint window, out int max_w, out int max_h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetWindowMinimumSize(/*SDL_Window*/ nint window, out int min_w, out int min_h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetWindowPosition(/*SDL_Window*/ nint window, out int x, out int y);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetWindowSize(/*SDL_Window*/ nint window, out int w, out int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetWindowSizeInPixels(/*SDL_Window*/ nint window, out int w, out int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_GetWindowSurface(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetWindowTitle(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_BindTexture(/*SDL_Texture*/ nint texture, out float texw, out float texh);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_GLContext*/ nint SDL_GL_CreateContext(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GL_DeleteContext(/*SDL_GLContext*/ nint context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_GL_LoadLibrary(byte* path);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial /*void* func*/ nint SDL_GL_GetProcAddress(byte* proc);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GL_UnloadLibrary();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SDL_bool SDL_GL_ExtensionSupported(byte* extension);

    // 2.0.2 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GL_ResetAttributes();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_GetAttribute(SDL_GLattr attr, out int value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_GetSwapInterval();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_MakeCurrent(/*SDL_Window*/ nint window, /*SDL_GLContext*/ nint context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Window*/ nint SDL_GL_GetCurrentWindow();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Context*/ nint SDL_GL_GetCurrentContext();

    // 2.0.1 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GL_GetDrawableSize(/*SDL_Window*/ nint window, out int w, out int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_SetAttribute(SDL_GLattr attr, SDL_GLprofile profile);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_SetSwapInterval(int interval);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GL_SwapWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GL_UnbindTexture(/*SDL_Texture*/ nint texture);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_HideWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_IsScreenSaverEnabled();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_MaximizeWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_MinimizeWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RaiseWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RestoreWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowBrightness(/*SDL_Window*/ nint window, float brightness);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial nint SDL_SetWindowData(/*SDL_Window*/ nint window, byte* name, nint userdata);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowDisplayMode(/*SDL_Window*/ nint window, ref SDL_DisplayMode mode);

    // NULL overload - use the window's dimensions and the desktop's format and refresh rate.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowDisplayMode(/*SDL_Window*/ nint window, nint mode = 0);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowFullscreen(/*SDL_Window*/ nint window, uint flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowGammaRamp(/*SDL_Window*/ nint window, in GammaRampChannel red, in GammaRampChannel green, in GammaRampChannel blue);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowGrab(/*SDL_Window*/ nint window, SDL_bool grabbed);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowKeyboardGrab(/*SDL_Window*/ nint window, SDL_bool grabbed);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowMouseGrab(/*SDL_Window*/ nint window, SDL_bool grabbed);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowIcon(/*SDL_Window*/ nint window, /*SDL_Surface*/ nint icon);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowMaximumSize(/*SDL_Window*/ nint window, int max_w, int max_h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowMinimumSize(/*SDL_Window*/ nint window, int min_w, int min_h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowPosition(/*SDL_Window*/ nint window, int x, int y);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowSize(/*SDL_Window*/ nint window, int w, int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowBordered(/*SDL_Window*/ nint window, SDL_bool bordered);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetWindowBordersSize(/*SDL_Window*/ nint window, out int top, out int left, out int bottom, out int right);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowResizable(/*SDL_Window*/ nint window, SDL_bool resizable);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetWindowAlwaysOnTop(/*SDL_Window*/ nint window, SDL_bool on_top);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_SetWindowTitle(/*SDL_Window*/ nint window, byte* title);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_ShowWindow(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_UpdateWindowSurface(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_UpdateWindowSurfaceRects(/*SDL_Window*/ nint window, in SDL_Rect* rects, int numrects);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_VideoInit(byte* driver_name);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_VideoQuit();

    // 2.0.4 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_SetWindowHitTest(
        /*SDL_Window*/ nint window,
        delegate*</*SDL_Window*/ nint, /*SDL_HitTest*/ nint, /*callback_data*/ nint, SDL_HitTestResult> callback,
        nint callback_data);

    // 2.0.4 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetGrabbedWindow();

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowMouseRect(/*SDL_Window*/ nint window, ref SDL_Rect rect);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowMouseRect(/*SDL_Window*/ nint window, /*SDL_Rect*/ nint rect);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Rect*/ nint SDL_GetWindowMouseRect(/*SDL_Window*/ nint window);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_FlashWindow(/*SDL_Window*/ nint window, SDL_FlashOperation operation);
}
