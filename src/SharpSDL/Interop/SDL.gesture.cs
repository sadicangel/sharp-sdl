namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_RecordGesture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RecordGesture([NativeTypeName("SDL_TouchID")] long touchId);

    [LibraryImport("SDL2", EntryPoint = "SDL_SaveAllDollarTemplates")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SaveAllDollarTemplates(SDL_RWops* dst);

    [LibraryImport("SDL2", EntryPoint = "SDL_SaveDollarTemplate")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SaveDollarTemplate([NativeTypeName("SDL_GestureID")] long gestureId, SDL_RWops* dst);

    [LibraryImport("SDL2", EntryPoint = "SDL_LoadDollarTemplates")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int LoadDollarTemplates([NativeTypeName("SDL_TouchID")] long touchId, SDL_RWops* src);
}
