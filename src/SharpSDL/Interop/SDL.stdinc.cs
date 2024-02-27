namespace SharpSDL.Interop;

internal enum SDL_DUMMY_ENUM
{
    DUMMY_ENUM_VALUE,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_malloc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* malloc([NativeTypeName("size_t")] nuint size);

    [LibraryImport("SDL2", EntryPoint = "SDL_calloc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* calloc([NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size);

    [LibraryImport("SDL2", EntryPoint = "SDL_realloc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* realloc(void* mem, [NativeTypeName("size_t")] nuint size);

    [LibraryImport("SDL2", EntryPoint = "SDL_free")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void free(void* mem);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetOriginalMemoryFunctions")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetOriginalMemoryFunctions([NativeTypeName("SDL_malloc_func *")] delegate* unmanaged[Cdecl]<nuint, void*>* malloc_func, [NativeTypeName("SDL_calloc_func *")] delegate* unmanaged[Cdecl]<nuint, nuint, void*>* calloc_func, [NativeTypeName("SDL_realloc_func *")] delegate* unmanaged[Cdecl]<void*, nuint, void*>* realloc_func, [NativeTypeName("SDL_free_func *")] delegate* unmanaged[Cdecl]<void*, void>* free_func);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetMemoryFunctions")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetMemoryFunctions([NativeTypeName("SDL_malloc_func *")] delegate* unmanaged[Cdecl]<nuint, void*>* malloc_func, [NativeTypeName("SDL_calloc_func *")] delegate* unmanaged[Cdecl]<nuint, nuint, void*>* calloc_func, [NativeTypeName("SDL_realloc_func *")] delegate* unmanaged[Cdecl]<void*, nuint, void*>* realloc_func, [NativeTypeName("SDL_free_func *")] delegate* unmanaged[Cdecl]<void*, void>* free_func);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetMemoryFunctions")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetMemoryFunctions([NativeTypeName("SDL_malloc_func")] delegate* unmanaged[Cdecl]<nuint, void*> malloc_func, [NativeTypeName("SDL_calloc_func")] delegate* unmanaged[Cdecl]<nuint, nuint, void*> calloc_func, [NativeTypeName("SDL_realloc_func")] delegate* unmanaged[Cdecl]<void*, nuint, void*> realloc_func, [NativeTypeName("SDL_free_func")] delegate* unmanaged[Cdecl]<void*, void> free_func);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumAllocations")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumAllocations();

    [LibraryImport("SDL2", EntryPoint = "SDL_getenv")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* getenv([NativeTypeName("const char *")] byte* name);

    [LibraryImport("SDL2", EntryPoint = "SDL_setenv")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int setenv([NativeTypeName("const char *")] byte* name, [NativeTypeName("const char *")] byte* value, int overwrite);

    [LibraryImport("SDL2", EntryPoint = "SDL_qsort")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void qsort(void* @base, [NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size, [NativeTypeName("int (*)(const void *, const void *) __attribute__((cdecl))")] delegate* unmanaged[Cdecl]<void*, void*, int> compare);

    [LibraryImport("SDL2", EntryPoint = "SDL_bsearch")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* bsearch([NativeTypeName("const void *")] void* key, [NativeTypeName("const void *")] void* @base, [NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size, [NativeTypeName("int (*)(const void *, const void *) __attribute__((cdecl))")] delegate* unmanaged[Cdecl]<void*, void*, int> compare);

    [LibraryImport("SDL2", EntryPoint = "SDL_abs")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int abs(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isalpha")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isalpha(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isalnum")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isalnum(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isblank")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isblank(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_iscntrl")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int iscntrl(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isdigit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isdigit(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isxdigit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isxdigit(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_ispunct")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int ispunct(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isspace")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isspace(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isupper")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isupper(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_islower")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int islower(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isprint")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isprint(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_isgraph")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int isgraph(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_toupper")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int toupper(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_tolower")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int tolower(int x);

    [LibraryImport("SDL2", EntryPoint = "SDL_crc16")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort crc16(ushort crc, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_crc32")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint crc32(uint crc, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_memset")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* memset(void* dst, int c, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_memcpy")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* memcpy(void* dst, [NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_memmove")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* memmove(void* dst, [NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_memcmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int memcmp([NativeTypeName("const void *")] void* s1, [NativeTypeName("const void *")] void* s2, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcslen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint wcslen([NativeTypeName("const wchar_t *")] ushort* wstr);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcslcpy")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint wcslcpy([NativeTypeName("wchar_t *")] ushort* dst, [NativeTypeName("const wchar_t *")] ushort* src, [NativeTypeName("size_t")] nuint maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcslcat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint wcslcat([NativeTypeName("wchar_t *")] ushort* dst, [NativeTypeName("const wchar_t *")] ushort* src, [NativeTypeName("size_t")] nuint maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcsdup")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("wchar_t *")]
    public static partial ushort* wcsdup([NativeTypeName("const wchar_t *")] ushort* wstr);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcsstr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("wchar_t *")]
    public static partial ushort* wcsstr([NativeTypeName("const wchar_t *")] ushort* haystack, [NativeTypeName("const wchar_t *")] ushort* needle);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcscmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int wcscmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcsncmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int wcsncmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2, [NativeTypeName("size_t")] nuint maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcscasecmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int wcscasecmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2);

    [LibraryImport("SDL2", EntryPoint = "SDL_wcsncasecmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int wcsncasecmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2, [NativeTypeName("size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_strlen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint strlen([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_strlcpy")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint strlcpy([NativeTypeName("char *")] byte* dst, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_utf8strlcpy")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint utf8strlcpy([NativeTypeName("char *")] byte* dst, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint dst_bytes);

    [LibraryImport("SDL2", EntryPoint = "SDL_strlcat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint strlcat([NativeTypeName("char *")] byte* dst, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_strdup")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strdup([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_strrev")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strrev([NativeTypeName("char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_strupr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strupr([NativeTypeName("char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_strlwr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strlwr([NativeTypeName("char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_strchr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strchr([NativeTypeName("const char *")] byte* str, int c);

    [LibraryImport("SDL2", EntryPoint = "SDL_strrchr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strrchr([NativeTypeName("const char *")] byte* str, int c);

    [LibraryImport("SDL2", EntryPoint = "SDL_strstr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strstr([NativeTypeName("const char *")] byte* haystack, [NativeTypeName("const char *")] byte* needle);

    [LibraryImport("SDL2", EntryPoint = "SDL_strcasestr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strcasestr([NativeTypeName("const char *")] byte* haystack, [NativeTypeName("const char *")] byte* needle);

    [LibraryImport("SDL2", EntryPoint = "SDL_strtokr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* strtokr([NativeTypeName("char *")] byte* s1, [NativeTypeName("const char *")] byte* s2, [NativeTypeName("char **")] byte** saveptr);

    [LibraryImport("SDL2", EntryPoint = "SDL_utf8strlen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint utf8strlen([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_utf8strnlen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint utf8strnlen([NativeTypeName("const char *")] byte* str, [NativeTypeName("size_t")] nuint bytes);

    [LibraryImport("SDL2", EntryPoint = "SDL_itoa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* itoa(int value, [NativeTypeName("char *")] byte* str, int radix);

    [LibraryImport("SDL2", EntryPoint = "SDL_uitoa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* uitoa([NativeTypeName("unsigned int")] uint value, [NativeTypeName("char *")] byte* str, int radix);

    [LibraryImport("SDL2", EntryPoint = "SDL_ltoa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* ltoa([NativeTypeName("long")] int value, [NativeTypeName("char *")] byte* str, int radix);

    [LibraryImport("SDL2", EntryPoint = "SDL_ultoa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* ultoa([NativeTypeName("unsigned long")] uint value, [NativeTypeName("char *")] byte* str, int radix);

    [LibraryImport("SDL2", EntryPoint = "SDL_lltoa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* lltoa(long value, [NativeTypeName("char *")] byte* str, int radix);

    [LibraryImport("SDL2", EntryPoint = "SDL_ulltoa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* ulltoa(ulong value, [NativeTypeName("char *")] byte* str, int radix);

    [LibraryImport("SDL2", EntryPoint = "SDL_atoi")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int atoi([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_atof")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double atof([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_strtol")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("long")]
    public static partial int strtol([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [LibraryImport("SDL2", EntryPoint = "SDL_strtoul")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("unsigned long")]
    public static partial uint strtoul([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [LibraryImport("SDL2", EntryPoint = "SDL_strtoll")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long strtoll([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [LibraryImport("SDL2", EntryPoint = "SDL_strtoull")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong strtoull([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp, int @base);

    [LibraryImport("SDL2", EntryPoint = "SDL_strtod")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double strtod([NativeTypeName("const char *")] byte* str, [NativeTypeName("char **")] byte** endp);

    [LibraryImport("SDL2", EntryPoint = "SDL_strcmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int strcmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2);

    [LibraryImport("SDL2", EntryPoint = "SDL_strncmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int strncmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2, [NativeTypeName("size_t")] nuint maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_strcasecmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int strcasecmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2);

    [LibraryImport("SDL2", EntryPoint = "SDL_strncasecmp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int strncasecmp([NativeTypeName("const char *")] byte* str1, [NativeTypeName("const char *")] byte* str2, [NativeTypeName("size_t")] nuint len);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sscanf", ExactSpelling = true)]
    public static extern int sscanf([NativeTypeName("const char *")] byte* text, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [LibraryImport("SDL2", EntryPoint = "SDL_vsscanf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int vsscanf([NativeTypeName("const char *")] byte* text, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_snprintf", ExactSpelling = true)]
    public static extern int snprintf([NativeTypeName("char *")] byte* text, [NativeTypeName("size_t")] nuint maxlen, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [LibraryImport("SDL2", EntryPoint = "SDL_vsnprintf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int vsnprintf([NativeTypeName("char *")] byte* text, [NativeTypeName("size_t")] nuint maxlen, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asprintf", ExactSpelling = true)]
    public static extern int asprintf([NativeTypeName("char **")] byte** strp, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [LibraryImport("SDL2", EntryPoint = "SDL_vasprintf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int vasprintf([NativeTypeName("char **")] byte** strp, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [LibraryImport("SDL2", EntryPoint = "SDL_acos")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double acos(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_acosf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float acosf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_asin")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double asin(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_asinf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float asinf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_atan")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double atan(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_atanf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float atanf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_atan2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double atan2(double y, double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_atan2f")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float atan2f(float y, float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_ceil")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double ceil(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_ceilf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float ceilf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_copysign")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double copysign(double x, double y);

    [LibraryImport("SDL2", EntryPoint = "SDL_copysignf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float copysignf(float x, float y);

    [LibraryImport("SDL2", EntryPoint = "SDL_cos")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double cos(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_cosf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float cosf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_exp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double exp(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_expf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float expf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_fabs")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double fabs(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_fabsf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float fabsf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_floor")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double floor(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_floorf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float floorf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_trunc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double trunc(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_truncf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float truncf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_fmod")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double fmod(double x, double y);

    [LibraryImport("SDL2", EntryPoint = "SDL_fmodf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float fmodf(float x, float y);

    [LibraryImport("SDL2", EntryPoint = "SDL_log")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double log(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_logf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float logf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_log10")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double log10(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_log10f")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float log10f(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_pow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double pow(double x, double y);

    [LibraryImport("SDL2", EntryPoint = "SDL_powf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float powf(float x, float y);

    [LibraryImport("SDL2", EntryPoint = "SDL_round")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double round(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_roundf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float roundf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_lround")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("long")]
    public static partial int lround(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_lroundf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("long")]
    public static partial int lroundf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_scalbn")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double scalbn(double x, int n);

    [LibraryImport("SDL2", EntryPoint = "SDL_scalbnf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float scalbnf(float x, int n);

    [LibraryImport("SDL2", EntryPoint = "SDL_sin")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double sin(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_sinf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sinf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_sqrt")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double sqrt(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_sqrtf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sqrtf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_tan")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double tan(double x);

    [LibraryImport("SDL2", EntryPoint = "SDL_tanf")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float tanf(float x);

    [LibraryImport("SDL2", EntryPoint = "SDL_iconv_open")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_iconv_t")]
    public static partial nint iconv_open([NativeTypeName("const char *")] byte* tocode, [NativeTypeName("const char *")] byte* fromcode);

    [LibraryImport("SDL2", EntryPoint = "SDL_iconv_close")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int iconv_close([NativeTypeName("SDL_iconv_t")] nint cd);

    [LibraryImport("SDL2", EntryPoint = "SDL_iconv")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint iconv([NativeTypeName("SDL_iconv_t")] nint cd, [NativeTypeName("const char **")] byte** inbuf, [NativeTypeName("size_t *")] nuint* inbytesleft, [NativeTypeName("char **")] byte** outbuf, [NativeTypeName("size_t *")] nuint* outbytesleft);

    [LibraryImport("SDL2", EntryPoint = "SDL_iconv_string")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* iconv_string([NativeTypeName("const char *")] byte* tocode, [NativeTypeName("const char *")] byte* fromcode, [NativeTypeName("const char *")] byte* inbuf, [NativeTypeName("size_t")] nuint inbytesleft);

    [LibraryImport("SDL2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("_Bool")]
    public static partial byte __builtin_mul_overflow();

    [LibraryImport("SDL2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("_Bool")]
    public static partial byte __builtin_add_overflow();

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
