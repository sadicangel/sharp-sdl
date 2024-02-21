using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct Point
    {
        public int x;

        public int y;
    }

    public partial struct FPoint
    {
        public float x;

        public float y;
    }

    public partial struct Rect
    {
        public int x;

        public int y;

        public int w;

        public int h;
    }

    public partial struct FRect
    {
        public float x;

        public float y;

        public float w;

        public float h;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasIntersection", ExactSpelling = true)]
        public static extern CBool HasIntersection([NativeTypeName("const Rect *")] Rect* A, [NativeTypeName("const Rect *")] Rect* B);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRect", ExactSpelling = true)]
        public static extern CBool IntersectRect([NativeTypeName("const Rect *")] Rect* A, [NativeTypeName("const Rect *")] Rect* B, Rect* result);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnionRect", ExactSpelling = true)]
        public static extern void UnionRect([NativeTypeName("const Rect *")] Rect* A, [NativeTypeName("const Rect *")] Rect* B, Rect* result);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnclosePoints", ExactSpelling = true)]
        public static extern CBool EnclosePoints([NativeTypeName("const Point *")] Point* points, int count, [NativeTypeName("const Rect *")] Rect* clip, Rect* result);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRectAndLine", ExactSpelling = true)]
        public static extern CBool IntersectRectAndLine([NativeTypeName("const Rect *")] Rect* rect, int* X1, int* Y1, int* X2, int* Y2);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasIntersectionF", ExactSpelling = true)]
        public static extern CBool HasIntersectionF([NativeTypeName("const FRect *")] FRect* A, [NativeTypeName("const FRect *")] FRect* B);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectFRect", ExactSpelling = true)]
        public static extern CBool IntersectFRect([NativeTypeName("const FRect *")] FRect* A, [NativeTypeName("const FRect *")] FRect* B, FRect* result);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnionFRect", ExactSpelling = true)]
        public static extern void UnionFRect([NativeTypeName("const FRect *")] FRect* A, [NativeTypeName("const FRect *")] FRect* B, FRect* result);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EncloseFPoints", ExactSpelling = true)]
        public static extern CBool EncloseFPoints([NativeTypeName("const FPoint *")] FPoint* points, int count, [NativeTypeName("const FRect *")] FRect* clip, FRect* result);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectFRectAndLine", ExactSpelling = true)]
        public static extern CBool IntersectFRectAndLine([NativeTypeName("const FRect *")] FRect* rect, float* X1, float* Y1, float* X2, float* Y2);
    }
}
