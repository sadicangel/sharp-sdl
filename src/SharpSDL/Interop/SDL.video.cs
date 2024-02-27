namespace SharpSDL.Interop;

internal unsafe partial struct SDL_DisplayMode
{
    public uint format;

    public int w;

    public int h;

    public int refresh_rate;

    public void* driverdata;
}

internal enum SDL_WindowFlags
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
    SDL_WINDOW_FULLSCREEN_DESKTOP = (SDL_WINDOW_FULLSCREEN | 0x00001000),
    SDL_WINDOW_FOREIGN = 0x00000800,
    SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000,
    SDL_WINDOW_MOUSE_CAPTURE = 0x00004000,
    SDL_WINDOW_ALWAYS_ON_TOP = 0x00008000,
    SDL_WINDOW_SKIP_TASKBAR = 0x00010000,
    SDL_WINDOW_UTILITY = 0x00020000,
    SDL_WINDOW_TOOLTIP = 0x00040000,
    SDL_WINDOW_POPUP_MENU = 0x00080000,
    SDL_WINDOW_KEYBOARD_GRABBED = 0x00100000,
    SDL_WINDOW_VULKAN = 0x10000000,
    SDL_WINDOW_METAL = 0x20000000,
    SDL_WINDOW_INPUT_GRABBED = SDL_WINDOW_MOUSE_GRABBED,
}

internal enum SDL_WindowEventID
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
    SDL_WINDOWEVENT_TAKE_FOCUS,
    SDL_WINDOWEVENT_HIT_TEST,
    SDL_WINDOWEVENT_ICCPROF_CHANGED,
    SDL_WINDOWEVENT_DISPLAY_CHANGED,
}

internal enum SDL_DisplayEventID
{
    SDL_DISPLAYEVENT_NONE,
    SDL_DISPLAYEVENT_ORIENTATION,
    SDL_DISPLAYEVENT_CONNECTED,
    SDL_DISPLAYEVENT_DISCONNECTED,
    SDL_DISPLAYEVENT_MOVED,
}

internal enum SDL_DisplayOrientation
{
    SDL_ORIENTATION_UNKNOWN,
    SDL_ORIENTATION_LANDSCAPE,
    SDL_ORIENTATION_LANDSCAPE_FLIPPED,
    SDL_ORIENTATION_PORTRAIT,
    SDL_ORIENTATION_PORTRAIT_FLIPPED,
}

internal enum SDL_FlashOperation
{
    SDL_FLASH_CANCEL,
    SDL_FLASH_BRIEFLY,
    SDL_FLASH_UNTIL_FOCUSED,
}

internal enum SDL_GLattr
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
    SDL_GL_CONTEXT_RESET_NOTIFICATION,
    SDL_GL_CONTEXT_NO_ERROR,
    SDL_GL_FLOATBUFFERS,
}

internal enum SDL_GLprofile
{
    SDL_GL_CONTEXT_PROFILE_CORE = 0x0001,
    SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 0x0002,
    SDL_GL_CONTEXT_PROFILE_ES = 0x0004,
}

internal enum SDL_GLcontextFlag
{
    SDL_GL_CONTEXT_DEBUG_FLAG = 0x0001,
    SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x0002,
    SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 0x0004,
    SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 0x0008,
}

internal enum SDL_GLcontextReleaseFlag
{
    SDL_GL_CONTEXT_RELEASE_BEHAVIOR_NONE = 0x0000,
    SDL_GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH = 0x0001,
}

internal enum SDL_GLContextResetNotification
{
    SDL_GL_CONTEXT_RESET_NO_NOTIFICATION = 0x0000,
    SDL_GL_CONTEXT_RESET_LOSE_CONTEXT = 0x0001,
}

internal enum SDL_HitTestResult
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
    SDL_HITTEST_RESIZE_LEFT,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumVideoDrivers")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumVideoDrivers();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetVideoDriver")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetVideoDriver(int index);

    [LibraryImport("SDL2", EntryPoint = "SDL_VideoInit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int VideoInit([NativeTypeName("const char *")] byte* driver_name);

    [LibraryImport("SDL2", EntryPoint = "SDL_VideoQuit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void VideoQuit();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetCurrentVideoDriver")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetCurrentVideoDriver();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumVideoDisplays")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumVideoDisplays();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDisplayName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetDisplayName(int displayIndex);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDisplayBounds")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetDisplayBounds(int displayIndex, SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDisplayUsableBounds")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetDisplayUsableBounds(int displayIndex, SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDisplayDPI")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetDisplayDPI(int displayIndex, float* ddpi, float* hdpi, float* vdpi);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDisplayOrientation")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_DisplayOrientation GetDisplayOrientation(int displayIndex);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumDisplayModes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumDisplayModes(int displayIndex);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDisplayMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetDisplayMode(int displayIndex, int modeIndex, SDL_DisplayMode* mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDesktopDisplayMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetDesktopDisplayMode(int displayIndex, SDL_DisplayMode* mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetCurrentDisplayMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetCurrentDisplayMode(int displayIndex, SDL_DisplayMode* mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetClosestDisplayMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_DisplayMode* GetClosestDisplayMode(int displayIndex, [NativeTypeName("const SDL_DisplayMode *")] SDL_DisplayMode* mode, SDL_DisplayMode* closest);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetPointDisplayIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetPointDisplayIndex([NativeTypeName("const SDL_Point *")] SDL_Point* point);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRectDisplayIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetRectDisplayIndex([NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowDisplayIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetWindowDisplayIndex([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowDisplayMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowDisplayMode([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("const SDL_DisplayMode *")] SDL_DisplayMode* mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowDisplayMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetWindowDisplayMode([NativeTypeName("SDL_Window*")] nint window, SDL_DisplayMode* mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowICCProfile")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* GetWindowICCProfile([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("size_t *")] nuint* size);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowPixelFormat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint GetWindowPixelFormat([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint CreateWindow([NativeTypeName("const char *")] byte* title, int x, int y, int w, int h, uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateWindowFrom")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint CreateWindowFrom([NativeTypeName("const void *")] void* data);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint GetWindowID([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowFromID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint GetWindowFromID(uint id);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowFlags")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint GetWindowFlags([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowTitle")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowTitle([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("const char *")] byte* title);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowTitle")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetWindowTitle([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowIcon")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowIcon([NativeTypeName("SDL_Window*")] nint window, SDL_Surface* icon);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowData")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* SetWindowData([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("const char *")] byte* name, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowData")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* GetWindowData([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("const char *")] byte* name);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowPosition")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowPosition([NativeTypeName("SDL_Window*")] nint window, int x, int y);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowPosition")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetWindowPosition([NativeTypeName("SDL_Window*")] nint window, int* x, int* y);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowSize([NativeTypeName("SDL_Window*")] nint window, int w, int h);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetWindowSize([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowBordersSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetWindowBordersSize([NativeTypeName("SDL_Window*")] nint window, int* top, int* left, int* bottom, int* right);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowSizeInPixels")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetWindowSizeInPixels([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowMinimumSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowMinimumSize([NativeTypeName("SDL_Window*")] nint window, int min_w, int min_h);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowMinimumSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetWindowMinimumSize([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowMaximumSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowMaximumSize([NativeTypeName("SDL_Window*")] nint window, int max_w, int max_h);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowMaximumSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetWindowMaximumSize([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowBordered")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowBordered([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_bool")] CBool bordered);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowResizable")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowResizable([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_bool")] CBool resizable);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowAlwaysOnTop")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowAlwaysOnTop([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_bool")] CBool on_top);

    [LibraryImport("SDL2", EntryPoint = "SDL_ShowWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void ShowWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_HideWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void HideWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_RaiseWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RaiseWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_MaximizeWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void MaximizeWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_MinimizeWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void MinimizeWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_RestoreWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RestoreWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowFullscreen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowFullscreen([NativeTypeName("SDL_Window*")] nint window, uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_HasWindowSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasWindowSurface([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_Surface* GetWindowSurface([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpdateWindowSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int UpdateWindowSurface([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpdateWindowSurfaceRects")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int UpdateWindowSurfaceRects([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int numrects);

    [LibraryImport("SDL2", EntryPoint = "SDL_DestroyWindowSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int DestroyWindowSurface([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowGrab")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowGrab([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_bool")] CBool grabbed);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowKeyboardGrab")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowKeyboardGrab([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_bool")] CBool grabbed);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowMouseGrab")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetWindowMouseGrab([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_bool")] CBool grabbed);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowGrab")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GetWindowGrab([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowKeyboardGrab")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GetWindowKeyboardGrab([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowMouseGrab")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GetWindowMouseGrab([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetGrabbedWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint GetGrabbedWindow();

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowMouseRect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowMouseRect([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowMouseRect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const SDL_Rect *")]
    public static partial SDL_Rect* GetWindowMouseRect([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowBrightness")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowBrightness([NativeTypeName("SDL_Window*")] nint window, float brightness);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowBrightness")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float GetWindowBrightness([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowOpacity")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowOpacity([NativeTypeName("SDL_Window*")] nint window, float opacity);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowOpacity")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetWindowOpacity([NativeTypeName("SDL_Window*")] nint window, float* out_opacity);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowModalFor")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowModalFor([NativeTypeName("SDL_Window*")] nint modal_window, [NativeTypeName("SDL_Window*")] nint parent_window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowInputFocus")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowInputFocus([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowGammaRamp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowGammaRamp([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName(" *")] ushort* red, [NativeTypeName(" *")] ushort* green, [NativeTypeName(" *")] ushort* blue);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowGammaRamp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetWindowGammaRamp([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName(" *")] ushort* red, [NativeTypeName(" *")] ushort* green, [NativeTypeName(" *")] ushort* blue);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowHitTest")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetWindowHitTest([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_HitTest")] delegate* unmanaged[Cdecl]<nint, SDL_Point*, void*, SDL_HitTestResult> callback, void* callback_data);

    [LibraryImport("SDL2", EntryPoint = "SDL_FlashWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int FlashWindow([NativeTypeName("SDL_Window*")] nint window, SDL_FlashOperation operation);

    [LibraryImport("SDL2", EntryPoint = "SDL_DestroyWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void DestroyWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_IsScreenSaverEnabled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsScreenSaverEnabled();

    [LibraryImport("SDL2", EntryPoint = "SDL_EnableScreenSaver")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void EnableScreenSaver();

    [LibraryImport("SDL2", EntryPoint = "SDL_DisableScreenSaver")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void DisableScreenSaver();

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_LoadLibrary")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_LoadLibrary([NativeTypeName("const char *")] byte* path);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_GetProcAddress")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* GL_GetProcAddress([NativeTypeName("const char *")] byte* proc);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_UnloadLibrary")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GL_UnloadLibrary();

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_ExtensionSupported")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GL_ExtensionSupported([NativeTypeName("const char *")] byte* extension);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_ResetAttributes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GL_ResetAttributes();

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_SetAttribute")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_SetAttribute(SDL_GLattr attr, int value);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_GetAttribute")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_GetAttribute(SDL_GLattr attr, int* value);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_CreateContext")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_GLContext")]
    public static partial void* GL_CreateContext([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_MakeCurrent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_MakeCurrent([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("SDL_GLContext")] void* context);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_GetCurrentWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint GL_GetCurrentWindow();

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_GetCurrentContext")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_GLContext")]
    public static partial void* GL_GetCurrentContext();

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_GetDrawableSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GL_GetDrawableSize([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_SetSwapInterval")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_SetSwapInterval(int interval);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_GetSwapInterval")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_GetSwapInterval();

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_SwapWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GL_SwapWindow([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_DeleteContext")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GL_DeleteContext([NativeTypeName("SDL_GLContext")] void* context);

    [NativeTypeName("#define SDL_WINDOWPOS_UNDEFINED_MASK 0x1FFF0000u")]
    public const uint SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000U;

    [NativeTypeName("#define SDL_WINDOWPOS_UNDEFINED SDL_WINDOWPOS_UNDEFINED_DISPLAY(0)")]
    public const uint SDL_WINDOWPOS_UNDEFINED = (0x1FFF0000U | (0));

    [NativeTypeName("#define SDL_WINDOWPOS_CENTERED_MASK 0x2FFF0000u")]
    public const uint SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000U;

    [NativeTypeName("#define SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED_DISPLAY(0)")]
    public const uint SDL_WINDOWPOS_CENTERED = (0x2FFF0000U | (0));
}
