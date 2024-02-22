using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public unsafe partial struct DisplayMode
{
    public uint format;

    public int w;

    public int h;

    public int refresh_rate;

    public void* driverdata;
}

public partial struct Window
{
}

[Flags]
public enum WindowFlags
{
    FULLSCREEN = 0x00000001,
    OPENGL = 0x00000002,
    SHOWN = 0x00000004,
    HIDDEN = 0x00000008,
    BORDERLESS = 0x00000010,
    RESIZABLE = 0x00000020,
    MINIMIZED = 0x00000040,
    MAXIMIZED = 0x00000080,
    MOUSE_GRABBED = 0x00000100,
    INPUT_FOCUS = 0x00000200,
    MOUSE_FOCUS = 0x00000400,
    FULLSCREEN_DESKTOP = (FULLSCREEN | 0x00001000),
    FOREIGN = 0x00000800,
    ALLOW_HIGHDPI = 0x00002000,
    MOUSE_CAPTURE = 0x00004000,
    ALWAYS_ON_TOP = 0x00008000,
    SKIP_TASKBAR = 0x00010000,
    UTILITY = 0x00020000,
    TOOLTIP = 0x00040000,
    POPUP_MENU = 0x00080000,
    KEYBOARD_GRABBED = 0x00100000,
    VULKAN = 0x10000000,
    METAL = 0x20000000,
    INPUT_GRABBED = MOUSE_GRABBED,
}

public enum WindowEventID
{
    NONE,
    SHOWN,
    HIDDEN,
    EXPOSED,
    MOVED,
    RESIZED,
    SIZE_CHANGED,
    MINIMIZED,
    MAXIMIZED,
    RESTORED,
    ENTER,
    LEAVE,
    FOCUS_GAINED,
    FOCUS_LOST,
    CLOSE,
    TAKE_FOCUS,
    HIT_TEST,
    ICCPROF_CHANGED,
    DISPLAY_CHANGED,
}

public enum DisplayEventID
{
    NONE,
    ORIENTATION,
    CONNECTED,
    DISCONNECTED,
    MOVED,
}

public enum DisplayOrientation
{
    UNKNOWN,
    LANDSCAPE,
    LANDSCAPE_FLIPPED,
    PORTRAIT,
    PORTRAIT_FLIPPED,
}

public enum FlashOperation
{
    CANCEL,
    BRIEFLY,
    UNTIL_FOCUSED,
}

public enum GLattr
{
    RED_SIZE,
    GREEN_SIZE,
    BLUE_SIZE,
    ALPHA_SIZE,
    BUFFER_SIZE,
    DOUBLEBUFFER,
    DEPTH_SIZE,
    STENCIL_SIZE,
    ACCUM_RED_SIZE,
    ACCUM_GREEN_SIZE,
    ACCUM_BLUE_SIZE,
    ACCUM_ALPHA_SIZE,
    STEREO,
    MULTISAMPLEBUFFERS,
    MULTISAMPLESAMPLES,
    ACCELERATED_VISUAL,
    RETAINED_BACKING,
    CONTEXT_MAJOR_VERSION,
    CONTEXT_MINOR_VERSION,
    CONTEXT_EGL,
    CONTEXT_FLAGS,
    CONTEXT_PROFILE_MASK,
    SHARE_WITH_CURRENT_CONTEXT,
    FRAMEBUFFER_SRGB_CAPABLE,
    CONTEXT_RELEASE_BEHAVIOR,
    CONTEXT_RESET_NOTIFICATION,
    CONTEXT_NO_ERROR,
    FLOATBUFFERS,
}

public enum GLprofile
{
    CORE = 0x0001,
    COMPATIBILITY = 0x0002,
    ES = 0x0004,
}

public enum GLcontextFlag
{
    DEBUG_FLAG = 0x0001,
    FORWARD_COMPATIBLE_FLAG = 0x0002,
    ROBUST_ACCESS_FLAG = 0x0004,
    RESET_ISOLATION_FLAG = 0x0008,
}

public enum GLcontextReleaseFlag
{
    NONE = 0x0000,
    FLUSH = 0x0001,
}

public enum GLContextResetNotification
{
    NO_NOTIFICATION = 0x0000,
    LOSE_CONTEXT = 0x0001,
}

public enum HitTestResult
{
    NORMAL,
    DRAGGABLE,
    RESIZE_TOPLEFT,
    RESIZE_TOP,
    RESIZE_TOPRIGHT,
    RESIZE_RIGHT,
    RESIZE_BOTTOMRIGHT,
    RESIZE_BOTTOM,
    RESIZE_BOTTOMLEFT,
    RESIZE_LEFT,
}

public static unsafe partial class SDL
{
    [NativeTypeName("#define SDL_WINDOWPOS_UNDEFINED SDL_WINDOWPOS_UNDEFINED_DISPLAY(0)")]
    public const uint WINDOWPOS_UNDEFINED = (0x1FFF0000U | (0));

    [NativeTypeName("#define SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED_DISPLAY(0)")]
    public const uint WINDOWPOS_CENTERED = (0x2FFF0000U | (0));


    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDrivers", ExactSpelling = true)]
    public static extern int GetNumVideoDrivers();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVideoDriver", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern byte* GetVideoDriver(int index);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoInit", ExactSpelling = true)]
    public static extern int VideoInit([NativeTypeName("const char *")] byte* driver_name);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoQuit", ExactSpelling = true)]
    public static extern void VideoQuit();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentVideoDriver", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern byte* GetCurrentVideoDriver();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDisplays", ExactSpelling = true)]
    public static extern int GetNumVideoDisplays();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern byte* GetDisplayName(int displayIndex);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayBounds", ExactSpelling = true)]
    public static extern int GetDisplayBounds(int displayIndex, Rect* rect);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayUsableBounds", ExactSpelling = true)]
    public static extern int GetDisplayUsableBounds(int displayIndex, Rect* rect);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayDPI", ExactSpelling = true)]
    public static extern int GetDisplayDPI(int displayIndex, float* ddpi, float* hdpi, float* vdpi);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayOrientation", ExactSpelling = true)]
    public static extern DisplayOrientation GetDisplayOrientation(int displayIndex);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumDisplayModes", ExactSpelling = true)]
    public static extern int GetNumDisplayModes(int displayIndex);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayMode", ExactSpelling = true)]
    public static extern int GetDisplayMode(int displayIndex, int modeIndex, DisplayMode* mode);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDesktopDisplayMode", ExactSpelling = true)]
    public static extern int GetDesktopDisplayMode(int displayIndex, DisplayMode* mode);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentDisplayMode", ExactSpelling = true)]
    public static extern int GetCurrentDisplayMode(int displayIndex, DisplayMode* mode);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClosestDisplayMode", ExactSpelling = true)]
    public static extern DisplayMode* GetClosestDisplayMode(int displayIndex, [NativeTypeName("const DisplayMode *")] DisplayMode* mode, DisplayMode* closest);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPointDisplayIndex", ExactSpelling = true)]
    public static extern int GetPointDisplayIndex([NativeTypeName("const Point *")] Point* point);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRectDisplayIndex", ExactSpelling = true)]
    public static extern int GetRectDisplayIndex([NativeTypeName("const Rect *")] Rect* rect);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayIndex", ExactSpelling = true)]
    public static extern int GetWindowDisplayIndex(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowDisplayMode", ExactSpelling = true)]
    public static extern int SetWindowDisplayMode(Window* window, [NativeTypeName("const DisplayMode *")] DisplayMode* mode);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayMode", ExactSpelling = true)]
    public static extern int GetWindowDisplayMode(Window* window, DisplayMode* mode);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowICCProfile", ExactSpelling = true)]
    public static extern void* GetWindowICCProfile(Window* window, [NativeTypeName("size_t *")] nuint* size);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPixelFormat", ExactSpelling = true)]
    public static extern uint GetWindowPixelFormat(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindow", ExactSpelling = true)]
    public static extern Window* CreateWindow([NativeTypeName("const char *")] byte* title, int x, int y, int w, int h, WindowFlags flags);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowFrom", ExactSpelling = true)]
    public static extern Window* CreateWindowFrom([NativeTypeName("const void *")] void* data);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowID", ExactSpelling = true)]
    public static extern uint GetWindowID(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFromID", ExactSpelling = true)]
    public static extern Window* GetWindowFromID(uint id);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFlags", ExactSpelling = true)]
    public static extern uint GetWindowFlags(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowTitle", ExactSpelling = true)]
    public static extern void SetWindowTitle(Window* window, [NativeTypeName("const char *")] byte* title);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern byte* GetWindowTitle(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowIcon", ExactSpelling = true)]
    public static extern void SetWindowIcon(Window* window, Surface* icon);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowData", ExactSpelling = true)]
    public static extern void* SetWindowData(Window* window, [NativeTypeName("const char *")] byte* name, void* userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowData", ExactSpelling = true)]
    public static extern void* GetWindowData(Window* window, [NativeTypeName("const char *")] byte* name);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowPosition", ExactSpelling = true)]
    public static extern void SetWindowPosition(Window* window, int x, int y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPosition", ExactSpelling = true)]
    public static extern void GetWindowPosition(Window* window, int* x, int* y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowSize", ExactSpelling = true)]
    public static extern void SetWindowSize(Window* window, int w, int h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSize", ExactSpelling = true)]
    public static extern void GetWindowSize(Window* window, int* w, int* h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBordersSize", ExactSpelling = true)]
    public static extern int GetWindowBordersSize(Window* window, int* top, int* left, int* bottom, int* right);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSizeInPixels", ExactSpelling = true)]
    public static extern void GetWindowSizeInPixels(Window* window, int* w, int* h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMinimumSize", ExactSpelling = true)]
    public static extern void SetWindowMinimumSize(Window* window, int min_w, int min_h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMinimumSize", ExactSpelling = true)]
    public static extern void GetWindowMinimumSize(Window* window, int* w, int* h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMaximumSize", ExactSpelling = true)]
    public static extern void SetWindowMaximumSize(Window* window, int max_w, int max_h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMaximumSize", ExactSpelling = true)]
    public static extern void GetWindowMaximumSize(Window* window, int* w, int* h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBordered", ExactSpelling = true)]
    public static extern void SetWindowBordered(Window* window, CBool bordered);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowResizable", ExactSpelling = true)]
    public static extern void SetWindowResizable(Window* window, CBool resizable);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowAlwaysOnTop", ExactSpelling = true)]
    public static extern void SetWindowAlwaysOnTop(Window* window, CBool on_top);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowWindow", ExactSpelling = true)]
    public static extern void ShowWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HideWindow", ExactSpelling = true)]
    public static extern void HideWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RaiseWindow", ExactSpelling = true)]
    public static extern void RaiseWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MaximizeWindow", ExactSpelling = true)]
    public static extern void MaximizeWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MinimizeWindow", ExactSpelling = true)]
    public static extern void MinimizeWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RestoreWindow", ExactSpelling = true)]
    public static extern void RestoreWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowFullscreen", ExactSpelling = true)]
    public static extern int SetWindowFullscreen(Window* window, WindowFlags flags);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasWindowSurface", ExactSpelling = true)]
    public static extern CBool HasWindowSurface(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSurface", ExactSpelling = true)]
    public static extern Surface* GetWindowSurface(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurface", ExactSpelling = true)]
    public static extern int UpdateWindowSurface(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurfaceRects", ExactSpelling = true)]
    public static extern int UpdateWindowSurfaceRects(Window* window, [NativeTypeName("const Rect *")] Rect* rects, int numrects);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyWindowSurface", ExactSpelling = true)]
    public static extern int DestroyWindowSurface(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGrab", ExactSpelling = true)]
    public static extern void SetWindowGrab(Window* window, CBool grabbed);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowKeyboardGrab", ExactSpelling = true)]
    public static extern void SetWindowKeyboardGrab(Window* window, CBool grabbed);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMouseGrab", ExactSpelling = true)]
    public static extern void SetWindowMouseGrab(Window* window, CBool grabbed);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGrab", ExactSpelling = true)]
    public static extern CBool GetWindowGrab(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowKeyboardGrab", ExactSpelling = true)]
    public static extern CBool GetWindowKeyboardGrab(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMouseGrab", ExactSpelling = true)]
    public static extern CBool GetWindowMouseGrab(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGrabbedWindow", ExactSpelling = true)]
    public static extern Window* GetGrabbedWindow();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMouseRect", ExactSpelling = true)]
    public static extern int SetWindowMouseRect(Window* window, [NativeTypeName("const Rect *")] Rect* rect);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMouseRect", ExactSpelling = true)]
    [return: NativeTypeName("const Rect *")]
    public static extern Rect* GetWindowMouseRect(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBrightness", ExactSpelling = true)]
    public static extern int SetWindowBrightness(Window* window, float brightness);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBrightness", ExactSpelling = true)]
    public static extern float GetWindowBrightness(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowOpacity", ExactSpelling = true)]
    public static extern int SetWindowOpacity(Window* window, float opacity);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowOpacity", ExactSpelling = true)]
    public static extern int GetWindowOpacity(Window* window, float* out_opacity);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowModalFor", ExactSpelling = true)]
    public static extern int SetWindowModalFor(Window* modal_window, Window* parent_window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowInputFocus", ExactSpelling = true)]
    public static extern int SetWindowInputFocus(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGammaRamp", ExactSpelling = true)]
    public static extern int SetWindowGammaRamp(Window* window, [NativeTypeName("const  *")] ushort* red, [NativeTypeName("const  *")] ushort* green, [NativeTypeName("const  *")] ushort* blue);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGammaRamp", ExactSpelling = true)]
    public static extern int GetWindowGammaRamp(Window* window, [NativeTypeName(" *")] ushort* red, [NativeTypeName(" *")] ushort* green, [NativeTypeName(" *")] ushort* blue);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowHitTest", ExactSpelling = true)]
    public static extern int SetWindowHitTest(Window* window, [NativeTypeName("SDL_HitTest")] delegate* unmanaged[Cdecl]<Window*, Point*, void*, HitTestResult> callback, void* callback_data);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlashWindow", ExactSpelling = true)]
    public static extern int FlashWindow(Window* window, FlashOperation operation);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyWindow", ExactSpelling = true)]
    public static extern void DestroyWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenSaverEnabled", ExactSpelling = true)]
    public static extern CBool IsScreenSaverEnabled();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnableScreenSaver", ExactSpelling = true)]
    public static extern void EnableScreenSaver();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DisableScreenSaver", ExactSpelling = true)]
    public static extern void DisableScreenSaver();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_LoadLibrary", ExactSpelling = true)]
    public static extern int GL_LoadLibrary([NativeTypeName("const char *")] byte* path);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetProcAddress", ExactSpelling = true)]
    public static extern void* GL_GetProcAddress([NativeTypeName("const char *")] byte* proc);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnloadLibrary", ExactSpelling = true)]
    public static extern void GL_UnloadLibrary();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_ExtensionSupported", ExactSpelling = true)]
    public static extern CBool GL_ExtensionSupported([NativeTypeName("const char *")] byte* extension);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_ResetAttributes", ExactSpelling = true)]
    public static extern void GL_ResetAttributes();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetAttribute", ExactSpelling = true)]
    public static extern int GL_SetAttribute(GLattr attr, int value);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetAttribute", ExactSpelling = true)]
    public static extern int GL_GetAttribute(GLattr attr, int* value);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_CreateContext", ExactSpelling = true)]
    [return: NativeTypeName("SDL_GLContext")]
    public static extern void* GL_CreateContext(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_MakeCurrent", ExactSpelling = true)]
    public static extern int GL_MakeCurrent(Window* window, [NativeTypeName("SDL_GLContext")] void* context);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentWindow", ExactSpelling = true)]
    public static extern Window* GL_GetCurrentWindow();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentContext", ExactSpelling = true)]
    [return: NativeTypeName("SDL_GLContext")]
    public static extern void* GL_GetCurrentContext();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetDrawableSize", ExactSpelling = true)]
    public static extern void GL_GetDrawableSize(Window* window, int* w, int* h);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetSwapInterval", ExactSpelling = true)]
    public static extern int GL_SetSwapInterval(int interval);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetSwapInterval", ExactSpelling = true)]
    public static extern int GL_GetSwapInterval();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SwapWindow", ExactSpelling = true)]
    public static extern void GL_SwapWindow(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_DeleteContext", ExactSpelling = true)]
    public static extern void GL_DeleteContext([NativeTypeName("SDL_GLContext")] void* context);
}
