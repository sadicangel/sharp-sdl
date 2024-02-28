namespace SharpSDL;
public static class SdlExtensions
{
    public static bool OverlapsWith(this Rect rect, Rect target)
    {
        unsafe
        {
            return SDL.HasIntersection((SDL_Rect*)Unsafe.AsPointer(ref rect), (SDL_Rect*)Unsafe.AsPointer(ref target));
        }
    }
}
