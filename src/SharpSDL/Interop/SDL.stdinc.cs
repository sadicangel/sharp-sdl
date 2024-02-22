using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public partial struct _SDL_iconv_t
{
}

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_malloc", ExactSpelling = true)]
    public static extern void* malloc([NativeTypeName("size_t")] nuint size);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_calloc", ExactSpelling = true)]
    public static extern void* calloc([NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_realloc", ExactSpelling = true)]
    public static extern void* realloc(void* mem, [NativeTypeName("size_t")] nuint size);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_free", ExactSpelling = true)]
    public static extern void free(void* mem);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetOriginalMemoryFunctions", ExactSpelling = true)]
    public static extern void GetOriginalMemoryFunctions([NativeTypeName("SDL_malloc_func *")] delegate* unmanaged[Cdecl]<nuint, void*>* malloc_func, [NativeTypeName("SDL_calloc_func *")] delegate* unmanaged[Cdecl]<nuint, nuint, void*>* calloc_func, [NativeTypeName("SDL_realloc_func *")] delegate* unmanaged[Cdecl]<void*, nuint, void*>* realloc_func, [NativeTypeName("SDL_free_func *")] delegate* unmanaged[Cdecl]<void*, void>* free_func);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMemoryFunctions", ExactSpelling = true)]
    public static extern void GetMemoryFunctions([NativeTypeName("SDL_malloc_func *")] delegate* unmanaged[Cdecl]<nuint, void*>* malloc_func, [NativeTypeName("SDL_calloc_func *")] delegate* unmanaged[Cdecl]<nuint, nuint, void*>* calloc_func, [NativeTypeName("SDL_realloc_func *")] delegate* unmanaged[Cdecl]<void*, nuint, void*>* realloc_func, [NativeTypeName("SDL_free_func *")] delegate* unmanaged[Cdecl]<void*, void>* free_func);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetMemoryFunctions", ExactSpelling = true)]
    public static extern int SetMemoryFunctions([NativeTypeName("SDL_malloc_func")] delegate* unmanaged[Cdecl]<nuint, void*> malloc_func, [NativeTypeName("SDL_calloc_func")] delegate* unmanaged[Cdecl]<nuint, nuint, void*> calloc_func, [NativeTypeName("SDL_realloc_func")] delegate* unmanaged[Cdecl]<void*, nuint, void*> realloc_func, [NativeTypeName("SDL_free_func")] delegate* unmanaged[Cdecl]<void*, void> free_func);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAllocations", ExactSpelling = true)]
    public static extern int GetNumAllocations();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_getenv", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* getenv([NativeTypeName("const char *")] byte* name);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_setenv", ExactSpelling = true)]
    public static extern int setenv([NativeTypeName("const char *")] byte* name, [NativeTypeName("const char *")] byte* value, int overwrite);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_qsort", ExactSpelling = true)]
    public static extern void qsort(void* @base, [NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size, [NativeTypeName("int (*)(const void *, const void *) __attribute__((cdecl))")] delegate* unmanaged[Cdecl]<void*, void*, int> compare);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_bsearch", ExactSpelling = true)]
    public static extern void* bsearch([NativeTypeName("const void *")] void* key, [NativeTypeName("const void *")] void* @base, [NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size, [NativeTypeName("int (*)(const void *, const void *) __attribute__((cdecl))")] delegate* unmanaged[Cdecl]<void*, void*, int> compare);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_abs", ExactSpelling = true)]
    public static extern int abs(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isalpha", ExactSpelling = true)]
    public static extern int isalpha(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isalnum", ExactSpelling = true)]
    public static extern int isalnum(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isblank", ExactSpelling = true)]
    public static extern int isblank(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iscntrl", ExactSpelling = true)]
    public static extern int iscntrl(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isdigit", ExactSpelling = true)]
    public static extern int isdigit(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isxdigit", ExactSpelling = true)]
    public static extern int isxdigit(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ispunct", ExactSpelling = true)]
    public static extern int ispunct(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isspace", ExactSpelling = true)]
    public static extern int isspace(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isupper", ExactSpelling = true)]
    public static extern int isupper(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_islower", ExactSpelling = true)]
    public static extern int islower(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isprint", ExactSpelling = true)]
    public static extern int isprint(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isgraph", ExactSpelling = true)]
    public static extern int isgraph(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_toupper", ExactSpelling = true)]
    public static extern int toupper(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tolower", ExactSpelling = true)]
    public static extern int tolower(int x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_crc16", ExactSpelling = true)]
    public static extern ushort crc16(ushort crc, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_crc32", ExactSpelling = true)]
    public static extern uint crc32(uint crc, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memset", ExactSpelling = true)]
    public static extern void* memset(void* dst, int c, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memcpy", ExactSpelling = true)]
    public static extern void* memcpy(void* dst, [NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memmove", ExactSpelling = true)]
    public static extern void* memmove(void* dst, [NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memcmp", ExactSpelling = true)]
    public static extern int memcmp([NativeTypeName("const void *")] void* s1, [NativeTypeName("const void *")] void* s2, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcslen", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint wcslen([NativeTypeName("const wchar_t *")] ushort* wstr);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcslcpy", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint wcslcpy([NativeTypeName("wchar_t *")] ushort* dst, [NativeTypeName("const wchar_t *")] ushort* src, [NativeTypeName("size_t")] nuint maxlen);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcslcat", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint wcslcat([NativeTypeName("wchar_t *")] ushort* dst, [NativeTypeName("const wchar_t *")] ushort* src, [NativeTypeName("size_t")] nuint maxlen);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsdup", ExactSpelling = true)]
    [return: NativeTypeName("wchar_t *")]
    public static extern ushort* wcsdup([NativeTypeName("const wchar_t *")] ushort* wstr);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsstr", ExactSpelling = true)]
    [return: NativeTypeName("wchar_t *")]
    public static extern ushort* wcsstr([NativeTypeName("const wchar_t *")] ushort* haystack, [NativeTypeName("const wchar_t *")] ushort* needle);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcscmp", ExactSpelling = true)]
    public static extern int wcscmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsncmp", ExactSpelling = true)]
    public static extern int wcsncmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2, [NativeTypeName("size_t")] nuint maxlen);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcscasecmp", ExactSpelling = true)]
    public static extern int wcscasecmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsncasecmp", ExactSpelling = true)]
    public static extern int wcsncasecmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlen", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint strlen([NativeTypeName("const char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlcpy", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint strlcpy([NativeTypeName("char *")] byte* dst, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint maxlen);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_utf8strlcpy", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint utf8strlcpy([NativeTypeName("char *")] byte* dst, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint dst_bytes);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlcat", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint strlcat([NativeTypeName("char *")] byte* dst, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint maxlen);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strdup", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strdup([NativeTypeName("const char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strrev", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strrev([NativeTypeName("char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strupr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strupr([NativeTypeName("char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlwr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strlwr([NativeTypeName("char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strchr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strchr([NativeTypeName("const char *")] byte* str, int c);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strrchr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strrchr([NativeTypeName("const char *")] byte* str, int c);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strstr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strstr([NativeTypeName("const char *")] byte* haystack, [NativeTypeName("const char *")] byte* needle);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strcasestr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strcasestr([NativeTypeName("const char *")] byte* haystack, [NativeTypeName("const char *")] byte* needle);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtokr", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* strtokr([NativeTypeName("char *")] byte* s1, [NativeTypeName("const char *")] byte* s2, [NativeTypeName("char **")] byte** saveptr);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_utf8strlen", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint utf8strlen([NativeTypeName("const char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_utf8strnlen", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint utf8strnlen([NativeTypeName("const char *")] byte* str, [NativeTypeName("size_t")] nuint bytes);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_itoa", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* itoa(int value, [NativeTypeName("char *")] byte* str, int radix);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_uitoa", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* uitoa([NativeTypeName("unsigned int")] uint value, [NativeTypeName("char *")] byte* str, int radix);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ltoa", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* ltoa([NativeTypeName("long")] int value, [NativeTypeName("char *")] byte* str, int radix);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ultoa", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* ultoa([NativeTypeName("unsigned long")] uint value, [NativeTypeName("char *")] byte* str, int radix);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_lltoa", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* lltoa(long value, [NativeTypeName("char *")] byte* str, int radix);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ulltoa", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* ulltoa(ulong value, [NativeTypeName("char *")] byte* str, int radix);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atoi", ExactSpelling = true)]
    public static extern int atoi([NativeTypeName("const char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atof", ExactSpelling = true)]
    public static extern double atof([NativeTypeName("const char *")] byte* str);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtol", ExactSpelling = true)]
    [return: NativeTypeName("long")]
    public static extern int strtol([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtoul", ExactSpelling = true)]
    [return: NativeTypeName("unsigned long")]
    public static extern uint strtoul([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtoll", ExactSpelling = true)]
    public static extern long strtoll([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtoull", ExactSpelling = true)]
    public static extern ulong strtoull([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtod", ExactSpelling = true)]
    public static extern double strtod([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strcmp", ExactSpelling = true)]
    public static extern int strcmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strncmp", ExactSpelling = true)]
    public static extern int strncmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2, [NativeTypeName("size_t")] nuint maxlen);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strcasecmp", ExactSpelling = true)]
    public static extern int strcasecmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strncasecmp", ExactSpelling = true)]
    public static extern int strncasecmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sscanf", ExactSpelling = true)]
    public static extern int sscanf([NativeTypeName("const char *")] byte* text, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_vsscanf", ExactSpelling = true)]
    public static extern int vsscanf([NativeTypeName("const char *")] byte* text, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_snprintf", ExactSpelling = true)]
    public static extern int snprintf([NativeTypeName("char *")] byte* text, [NativeTypeName("size_t")] nuint maxlen, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_vsnprintf", ExactSpelling = true)]
    public static extern int vsnprintf([NativeTypeName("char *")] byte* text, [NativeTypeName("size_t")] nuint maxlen, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asprintf", ExactSpelling = true)]
    public static extern int asprintf([NativeTypeName("char **")] byte** strp, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_vasprintf", ExactSpelling = true)]
    public static extern int vasprintf([NativeTypeName("char **")] byte** strp, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_acos", ExactSpelling = true)]
    public static extern double acos(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_acosf", ExactSpelling = true)]
    public static extern float acosf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asin", ExactSpelling = true)]
    public static extern double asin(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asinf", ExactSpelling = true)]
    public static extern float asinf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atan", ExactSpelling = true)]
    public static extern double atan(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atanf", ExactSpelling = true)]
    public static extern float atanf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atan2", ExactSpelling = true)]
    public static extern double atan2(double y, double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atan2f", ExactSpelling = true)]
    public static extern float atan2f(float y, float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ceil", ExactSpelling = true)]
    public static extern double ceil(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ceilf", ExactSpelling = true)]
    public static extern float ceilf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_copysign", ExactSpelling = true)]
    public static extern double copysign(double x, double y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_copysignf", ExactSpelling = true)]
    public static extern float copysignf(float x, float y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_cos", ExactSpelling = true)]
    public static extern double cos(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_cosf", ExactSpelling = true)]
    public static extern float cosf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_exp", ExactSpelling = true)]
    public static extern double exp(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_expf", ExactSpelling = true)]
    public static extern float expf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fabs", ExactSpelling = true)]
    public static extern double fabs(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fabsf", ExactSpelling = true)]
    public static extern float fabsf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_floor", ExactSpelling = true)]
    public static extern double floor(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_floorf", ExactSpelling = true)]
    public static extern float floorf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_trunc", ExactSpelling = true)]
    public static extern double trunc(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_truncf", ExactSpelling = true)]
    public static extern float truncf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fmod", ExactSpelling = true)]
    public static extern double fmod(double x, double y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fmodf", ExactSpelling = true)]
    public static extern float fmodf(float x, float y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_log", ExactSpelling = true)]
    public static extern double log(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_logf", ExactSpelling = true)]
    public static extern float logf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_log10", ExactSpelling = true)]
    public static extern double log10(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_log10f", ExactSpelling = true)]
    public static extern float log10f(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_pow", ExactSpelling = true)]
    public static extern double pow(double x, double y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_powf", ExactSpelling = true)]
    public static extern float powf(float x, float y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_round", ExactSpelling = true)]
    public static extern double round(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_roundf", ExactSpelling = true)]
    public static extern float roundf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_lround", ExactSpelling = true)]
    [return: NativeTypeName("long")]
    public static extern int lround(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_lroundf", ExactSpelling = true)]
    [return: NativeTypeName("long")]
    public static extern int lroundf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_scalbn", ExactSpelling = true)]
    public static extern double scalbn(double x, int n);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_scalbnf", ExactSpelling = true)]
    public static extern float scalbnf(float x, int n);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sin", ExactSpelling = true)]
    public static extern double sin(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sinf", ExactSpelling = true)]
    public static extern float sinf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sqrt", ExactSpelling = true)]
    public static extern double sqrt(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sqrtf", ExactSpelling = true)]
    public static extern float sqrtf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tan", ExactSpelling = true)]
    public static extern double tan(double x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tanf", ExactSpelling = true)]
    public static extern float tanf(float x);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv_open", ExactSpelling = true)]
    [return: NativeTypeName("SDL_iconv_t")]
    public static extern _SDL_iconv_t* iconv_open([NativeTypeName("const char *")] byte* tocode, [NativeTypeName("const char *")] byte* fromcode);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv_close", ExactSpelling = true)]
    public static extern int iconv_close([NativeTypeName("SDL_iconv_t")] _SDL_iconv_t* cd);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint iconv([NativeTypeName("SDL_iconv_t")] _SDL_iconv_t* cd, [NativeTypeName("const char **")] byte** inbuf, [NativeTypeName("size_t *")] nuint* inbytesleft, [NativeTypeName("char **")] byte** outbuf, [NativeTypeName("size_t *")] nuint* outbytesleft);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv_string", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* iconv_string([NativeTypeName("const char *")] byte* tocode, [NativeTypeName("const char *")] byte* fromcode, [NativeTypeName("const char *")] byte* inbuf, [NativeTypeName("size_t")] nuint inbytesleft);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern byte __builtin_mul_overflow();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern byte __builtin_add_overflow();

    [NativeTypeName("#define SDL_SIZE_MAX SIZE_MAX")]
    public const ulong SDL_SIZE_MAX = 0xffffffffffffffffUL;

    [NativeTypeName("#define SDL_MAX_SINT8 (()0x7F)")]
    public const byte SDL_MAX_SINT8 = ((byte)(0x7F));

    [NativeTypeName("#define SDL_MIN_SINT8 (()(~0x7F))")]
    public const byte SDL_MIN_SINT8 = unchecked((byte)(~0x7F));

    [NativeTypeName("#define SDL_MAX_UINT8 (()0xFF)")]
    public const byte SDL_MAX_UINT8 = ((byte)(0xFF));

    [NativeTypeName("#define SDL_MIN_UINT8 (()0x00)")]
    public const byte SDL_MIN_UINT8 = ((byte)(0x00));

    [NativeTypeName("#define SDL_MAX_SINT16 (()0x7FFF)")]
    public const short SDL_MAX_SINT16 = ((short)(0x7FFF));

    [NativeTypeName("#define SDL_MIN_SINT16 (()(~0x7FFF))")]
    public const short SDL_MIN_SINT16 = ((short)(~0x7FFF));

    [NativeTypeName("#define SDL_MAX_UINT16 (()0xFFFF)")]
    public const ushort SDL_MAX_UINT16 = ((ushort)(0xFFFF));

    [NativeTypeName("#define SDL_MIN_UINT16 (()0x0000)")]
    public const ushort SDL_MIN_UINT16 = ((ushort)(0x0000));

    [NativeTypeName("#define SDL_MAX_SINT32 (()0x7FFFFFFF)")]
    public const int SDL_MAX_SINT32 = ((int)(0x7FFFFFFF));

    [NativeTypeName("#define SDL_MIN_SINT32 (()(~0x7FFFFFFF))")]
    public const int SDL_MIN_SINT32 = ((int)(~0x7FFFFFFF));

    [NativeTypeName("#define SDL_MAX_UINT32 (()0xFFFFFFFFu)")]
    public const uint SDL_MAX_UINT32 = ((uint)(0xFFFFFFFFU));

    [NativeTypeName("#define SDL_MIN_UINT32 (()0x00000000)")]
    public const uint SDL_MIN_UINT32 = ((uint)(0x00000000));

    [NativeTypeName("#define SDL_MAX_SINT64 (()0x7FFFFFFFFFFFFFFFll)")]
    public const long SDL_MAX_SINT64 = ((long)(0x7FFFFFFFFFFFFFFFL));

    [NativeTypeName("#define SDL_MIN_SINT64 (()(~0x7FFFFFFFFFFFFFFFll))")]
    public const long SDL_MIN_SINT64 = ((long)(~0x7FFFFFFFFFFFFFFFL));

    [NativeTypeName("#define SDL_MAX_UINT64 (()0xFFFFFFFFFFFFFFFFull)")]
    public const ulong SDL_MAX_UINT64 = ((ulong)(0xFFFFFFFFFFFFFFFFUL));

    [NativeTypeName("#define SDL_MIN_UINT64 (()(0x0000000000000000ull))")]
    public const ulong SDL_MIN_UINT64 = ((ulong)(0x0000000000000000UL));

    [NativeTypeName("#define SDL_FLT_EPSILON 1.1920928955078125e-07F")]
    public const float SDL_FLT_EPSILON = 1.1920928955078125e-07F;

    [NativeTypeName("#define SDL_PRIs64 \"I64d\"")]
    public static ReadOnlySpan<byte> SDL_PRIs64 => "I64d"u8;

    [NativeTypeName("#define SDL_PRIu64 \"I64u\"")]
    public static ReadOnlySpan<byte> SDL_PRIu64 => "I64u"u8;

    [NativeTypeName("#define SDL_PRIx64 \"I64x\"")]
    public static ReadOnlySpan<byte> SDL_PRIx64 => "I64x"u8;

    [NativeTypeName("#define SDL_PRIX64 \"I64X\"")]
    public static ReadOnlySpan<byte> SDL_PRIX64 => "I64X"u8;

    [NativeTypeName("#define SDL_PRIs32 \"d\"")]
    public static ReadOnlySpan<byte> SDL_PRIs32 => "d"u8;

    [NativeTypeName("#define SDL_PRIu32 \"u\"")]
    public static ReadOnlySpan<byte> SDL_PRIu32 => "u"u8;

    [NativeTypeName("#define SDL_PRIx32 \"x\"")]
    public static ReadOnlySpan<byte> SDL_PRIx32 => "x"u8;

    [NativeTypeName("#define SDL_PRIX32 \"X\"")]
    public static ReadOnlySpan<byte> SDL_PRIX32 => "X"u8;

    [NativeTypeName("#define M_PI 3.14159265358979323846264338327950288")]
    public const double M_PI = 3.14159265358979323846264338327950288;

    [NativeTypeName("#define SDL_ICONV_ERROR (size_t)-1")]
    public static nuint SDL_ICONV_ERROR => unchecked((nuint)(-1));

    [NativeTypeName("#define SDL_ICONV_E2BIG (size_t)-2")]
    public static nuint SDL_ICONV_E2BIG => unchecked((nuint)(-2));

    [NativeTypeName("#define SDL_ICONV_EILSEQ (size_t)-3")]
    public static nuint SDL_ICONV_EILSEQ => unchecked((nuint)(-3));

    [NativeTypeName("#define SDL_ICONV_EINVAL (size_t)-4")]
    public static nuint SDL_ICONV_EINVAL => unchecked((nuint)(-4));
}
