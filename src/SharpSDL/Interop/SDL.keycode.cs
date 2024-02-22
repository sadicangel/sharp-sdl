namespace SharpSDL.Interop;

internal enum SDL_KeyCode
{
    SDLK_UNKNOWN = 0,
    SDLK_RETURN = '\r',
    SDLK_ESCAPE = '',
    SDLK_BACKSPACE = '',
    SDLK_TAB = '\t',
    SDLK_SPACE = ' ',
    SDLK_EXCLAIM = '!',
    SDLK_QUOTEDBL = '"',
    SDLK_HASH = '#',
    SDLK_PERCENT = '%',
    SDLK_DOLLAR = '$',
    SDLK_AMPERSAND = '&',
    SDLK_QUOTE = '\'',
    SDLK_LEFTPAREN = '(',
    SDLK_RIGHTPAREN = ')',
    SDLK_ASTERISK = '*',
    SDLK_PLUS = '+',
    SDLK_COMMA = ',',
    SDLK_MINUS = '-',
    SDLK_PERIOD = '.',
    SDLK_SLASH = '/',
    SDLK_0 = '0',
    SDLK_1 = '1',
    SDLK_2 = '2',
    SDLK_3 = '3',
    SDLK_4 = '4',
    SDLK_5 = '5',
    SDLK_6 = '6',
    SDLK_7 = '7',
    SDLK_8 = '8',
    SDLK_9 = '9',
    SDLK_COLON = ':',
    SDLK_SEMICOLON = ';',
    SDLK_LESS = '<',
    SDLK_EQUALS = '=',
    SDLK_GREATER = '>',
    SDLK_QUESTION = '?',
    SDLK_AT = '@',
    SDLK_LEFTBRACKET = '[',
    SDLK_BACKSLASH = '\\',
    SDLK_RIGHTBRACKET = ']',
    SDLK_CARET = '^',
    SDLK_UNDERSCORE = '_',
    SDLK_BACKQUOTE = '`',
    SDLK_a = 'a',
    SDLK_b = 'b',
    SDLK_c = 'c',
    SDLK_d = 'd',
    SDLK_e = 'e',
    SDLK_f = 'f',
    SDLK_g = 'g',
    SDLK_h = 'h',
    SDLK_i = 'i',
    SDLK_j = 'j',
    SDLK_k = 'k',
    SDLK_l = 'l',
    SDLK_m = 'm',
    SDLK_n = 'n',
    SDLK_o = 'o',
    SDLK_p = 'p',
    SDLK_q = 'q',
    SDLK_r = 'r',
    SDLK_s = 's',
    SDLK_t = 't',
    SDLK_u = 'u',
    SDLK_v = 'v',
    SDLK_w = 'w',
    SDLK_x = 'x',
    SDLK_y = 'y',
    SDLK_z = 'z',
    SDLK_CAPSLOCK = (SDL_Scancode.SDL_SCANCODE_CAPSLOCK | (1 << 30)),
    SDLK_F1 = (SDL_Scancode.SDL_SCANCODE_F1 | (1 << 30)),
    SDLK_F2 = (SDL_Scancode.SDL_SCANCODE_F2 | (1 << 30)),
    SDLK_F3 = (SDL_Scancode.SDL_SCANCODE_F3 | (1 << 30)),
    SDLK_F4 = (SDL_Scancode.SDL_SCANCODE_F4 | (1 << 30)),
    SDLK_F5 = (SDL_Scancode.SDL_SCANCODE_F5 | (1 << 30)),
    SDLK_F6 = (SDL_Scancode.SDL_SCANCODE_F6 | (1 << 30)),
    SDLK_F7 = (SDL_Scancode.SDL_SCANCODE_F7 | (1 << 30)),
    SDLK_F8 = (SDL_Scancode.SDL_SCANCODE_F8 | (1 << 30)),
    SDLK_F9 = (SDL_Scancode.SDL_SCANCODE_F9 | (1 << 30)),
    SDLK_F10 = (SDL_Scancode.SDL_SCANCODE_F10 | (1 << 30)),
    SDLK_F11 = (SDL_Scancode.SDL_SCANCODE_F11 | (1 << 30)),
    SDLK_F12 = (SDL_Scancode.SDL_SCANCODE_F12 | (1 << 30)),
    SDLK_PRINTSCREEN = (SDL_Scancode.SDL_SCANCODE_PRINTSCREEN | (1 << 30)),
    SDLK_SCROLLLOCK = (SDL_Scancode.SDL_SCANCODE_SCROLLLOCK | (1 << 30)),
    SDLK_PAUSE = (SDL_Scancode.SDL_SCANCODE_PAUSE | (1 << 30)),
    SDLK_INSERT = (SDL_Scancode.SDL_SCANCODE_INSERT | (1 << 30)),
    SDLK_HOME = (SDL_Scancode.SDL_SCANCODE_HOME | (1 << 30)),
    SDLK_PAGEUP = (SDL_Scancode.SDL_SCANCODE_PAGEUP | (1 << 30)),
    SDLK_DELETE = '',
    SDLK_END = (SDL_Scancode.SDL_SCANCODE_END | (1 << 30)),
    SDLK_PAGEDOWN = (SDL_Scancode.SDL_SCANCODE_PAGEDOWN | (1 << 30)),
    SDLK_RIGHT = (SDL_Scancode.SDL_SCANCODE_RIGHT | (1 << 30)),
    SDLK_LEFT = (SDL_Scancode.SDL_SCANCODE_LEFT | (1 << 30)),
    SDLK_DOWN = (SDL_Scancode.SDL_SCANCODE_DOWN | (1 << 30)),
    SDLK_UP = (SDL_Scancode.SDL_SCANCODE_UP | (1 << 30)),
    SDLK_NUMLOCKCLEAR = (SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR | (1 << 30)),
    SDLK_KP_DIVIDE = (SDL_Scancode.SDL_SCANCODE_KP_DIVIDE | (1 << 30)),
    SDLK_KP_MULTIPLY = (SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY | (1 << 30)),
    SDLK_KP_MINUS = (SDL_Scancode.SDL_SCANCODE_KP_MINUS | (1 << 30)),
    SDLK_KP_PLUS = (SDL_Scancode.SDL_SCANCODE_KP_PLUS | (1 << 30)),
    SDLK_KP_ENTER = (SDL_Scancode.SDL_SCANCODE_KP_ENTER | (1 << 30)),
    SDLK_KP_1 = (SDL_Scancode.SDL_SCANCODE_KP_1 | (1 << 30)),
    SDLK_KP_2 = (SDL_Scancode.SDL_SCANCODE_KP_2 | (1 << 30)),
    SDLK_KP_3 = (SDL_Scancode.SDL_SCANCODE_KP_3 | (1 << 30)),
    SDLK_KP_4 = (SDL_Scancode.SDL_SCANCODE_KP_4 | (1 << 30)),
    SDLK_KP_5 = (SDL_Scancode.SDL_SCANCODE_KP_5 | (1 << 30)),
    SDLK_KP_6 = (SDL_Scancode.SDL_SCANCODE_KP_6 | (1 << 30)),
    SDLK_KP_7 = (SDL_Scancode.SDL_SCANCODE_KP_7 | (1 << 30)),
    SDLK_KP_8 = (SDL_Scancode.SDL_SCANCODE_KP_8 | (1 << 30)),
    SDLK_KP_9 = (SDL_Scancode.SDL_SCANCODE_KP_9 | (1 << 30)),
    SDLK_KP_0 = (SDL_Scancode.SDL_SCANCODE_KP_0 | (1 << 30)),
    SDLK_KP_PERIOD = (SDL_Scancode.SDL_SCANCODE_KP_PERIOD | (1 << 30)),
    SDLK_APPLICATION = (SDL_Scancode.SDL_SCANCODE_APPLICATION | (1 << 30)),
    SDLK_POWER = (SDL_Scancode.SDL_SCANCODE_POWER | (1 << 30)),
    SDLK_KP_EQUALS = (SDL_Scancode.SDL_SCANCODE_KP_EQUALS | (1 << 30)),
    SDLK_F13 = (SDL_Scancode.SDL_SCANCODE_F13 | (1 << 30)),
    SDLK_F14 = (SDL_Scancode.SDL_SCANCODE_F14 | (1 << 30)),
    SDLK_F15 = (SDL_Scancode.SDL_SCANCODE_F15 | (1 << 30)),
    SDLK_F16 = (SDL_Scancode.SDL_SCANCODE_F16 | (1 << 30)),
    SDLK_F17 = (SDL_Scancode.SDL_SCANCODE_F17 | (1 << 30)),
    SDLK_F18 = (SDL_Scancode.SDL_SCANCODE_F18 | (1 << 30)),
    SDLK_F19 = (SDL_Scancode.SDL_SCANCODE_F19 | (1 << 30)),
    SDLK_F20 = (SDL_Scancode.SDL_SCANCODE_F20 | (1 << 30)),
    SDLK_F21 = (SDL_Scancode.SDL_SCANCODE_F21 | (1 << 30)),
    SDLK_F22 = (SDL_Scancode.SDL_SCANCODE_F22 | (1 << 30)),
    SDLK_F23 = (SDL_Scancode.SDL_SCANCODE_F23 | (1 << 30)),
    SDLK_F24 = (SDL_Scancode.SDL_SCANCODE_F24 | (1 << 30)),
    SDLK_EXECUTE = (SDL_Scancode.SDL_SCANCODE_EXECUTE | (1 << 30)),
    SDLK_HELP = (SDL_Scancode.SDL_SCANCODE_HELP | (1 << 30)),
    SDLK_MENU = (SDL_Scancode.SDL_SCANCODE_MENU | (1 << 30)),
    SDLK_SELECT = (SDL_Scancode.SDL_SCANCODE_SELECT | (1 << 30)),
    SDLK_STOP = (SDL_Scancode.SDL_SCANCODE_STOP | (1 << 30)),
    SDLK_AGAIN = (SDL_Scancode.SDL_SCANCODE_AGAIN | (1 << 30)),
    SDLK_UNDO = (SDL_Scancode.SDL_SCANCODE_UNDO | (1 << 30)),
    SDLK_CUT = (SDL_Scancode.SDL_SCANCODE_CUT | (1 << 30)),
    SDLK_COPY = (SDL_Scancode.SDL_SCANCODE_COPY | (1 << 30)),
    SDLK_PASTE = (SDL_Scancode.SDL_SCANCODE_PASTE | (1 << 30)),
    SDLK_FIND = (SDL_Scancode.SDL_SCANCODE_FIND | (1 << 30)),
    SDLK_MUTE = (SDL_Scancode.SDL_SCANCODE_MUTE | (1 << 30)),
    SDLK_VOLUMEUP = (SDL_Scancode.SDL_SCANCODE_VOLUMEUP | (1 << 30)),
    SDLK_VOLUMEDOWN = (SDL_Scancode.SDL_SCANCODE_VOLUMEDOWN | (1 << 30)),
    SDLK_KP_COMMA = (SDL_Scancode.SDL_SCANCODE_KP_COMMA | (1 << 30)),
    SDLK_KP_EQUALSAS400 = (SDL_Scancode.SDL_SCANCODE_KP_EQUALSAS400 | (1 << 30)),
    SDLK_ALTERASE = (SDL_Scancode.SDL_SCANCODE_ALTERASE | (1 << 30)),
    SDLK_SYSREQ = (SDL_Scancode.SDL_SCANCODE_SYSREQ | (1 << 30)),
    SDLK_CANCEL = (SDL_Scancode.SDL_SCANCODE_CANCEL | (1 << 30)),
    SDLK_CLEAR = (SDL_Scancode.SDL_SCANCODE_CLEAR | (1 << 30)),
    SDLK_PRIOR = (SDL_Scancode.SDL_SCANCODE_PRIOR | (1 << 30)),
    SDLK_RETURN2 = (SDL_Scancode.SDL_SCANCODE_RETURN2 | (1 << 30)),
    SDLK_SEPARATOR = (SDL_Scancode.SDL_SCANCODE_SEPARATOR | (1 << 30)),
    SDLK_OUT = (SDL_Scancode.SDL_SCANCODE_OUT | (1 << 30)),
    SDLK_OPER = (SDL_Scancode.SDL_SCANCODE_OPER | (1 << 30)),
    SDLK_CLEARAGAIN = (SDL_Scancode.SDL_SCANCODE_CLEARAGAIN | (1 << 30)),
    SDLK_CRSEL = (SDL_Scancode.SDL_SCANCODE_CRSEL | (1 << 30)),
    SDLK_EXSEL = (SDL_Scancode.SDL_SCANCODE_EXSEL | (1 << 30)),
    SDLK_KP_00 = (SDL_Scancode.SDL_SCANCODE_KP_00 | (1 << 30)),
    SDLK_KP_000 = (SDL_Scancode.SDL_SCANCODE_KP_000 | (1 << 30)),
    SDLK_THOUSANDSSEPARATOR = (SDL_Scancode.SDL_SCANCODE_THOUSANDSSEPARATOR | (1 << 30)),
    SDLK_DECIMALSEPARATOR = (SDL_Scancode.SDL_SCANCODE_DECIMALSEPARATOR | (1 << 30)),
    SDLK_CURRENCYUNIT = (SDL_Scancode.SDL_SCANCODE_CURRENCYUNIT | (1 << 30)),
    SDLK_CURRENCYSUBUNIT = (SDL_Scancode.SDL_SCANCODE_CURRENCYSUBUNIT | (1 << 30)),
    SDLK_KP_LEFTPAREN = (SDL_Scancode.SDL_SCANCODE_KP_LEFTPAREN | (1 << 30)),
    SDLK_KP_RIGHTPAREN = (SDL_Scancode.SDL_SCANCODE_KP_RIGHTPAREN | (1 << 30)),
    SDLK_KP_LEFTBRACE = (SDL_Scancode.SDL_SCANCODE_KP_LEFTBRACE | (1 << 30)),
    SDLK_KP_RIGHTBRACE = (SDL_Scancode.SDL_SCANCODE_KP_RIGHTBRACE | (1 << 30)),
    SDLK_KP_TAB = (SDL_Scancode.SDL_SCANCODE_KP_TAB | (1 << 30)),
    SDLK_KP_BACKSPACE = (SDL_Scancode.SDL_SCANCODE_KP_BACKSPACE | (1 << 30)),
    SDLK_KP_A = (SDL_Scancode.SDL_SCANCODE_KP_A | (1 << 30)),
    SDLK_KP_B = (SDL_Scancode.SDL_SCANCODE_KP_B | (1 << 30)),
    SDLK_KP_C = (SDL_Scancode.SDL_SCANCODE_KP_C | (1 << 30)),
    SDLK_KP_D = (SDL_Scancode.SDL_SCANCODE_KP_D | (1 << 30)),
    SDLK_KP_E = (SDL_Scancode.SDL_SCANCODE_KP_E | (1 << 30)),
    SDLK_KP_F = (SDL_Scancode.SDL_SCANCODE_KP_F | (1 << 30)),
    SDLK_KP_XOR = (SDL_Scancode.SDL_SCANCODE_KP_XOR | (1 << 30)),
    SDLK_KP_POWER = (SDL_Scancode.SDL_SCANCODE_KP_POWER | (1 << 30)),
    SDLK_KP_PERCENT = (SDL_Scancode.SDL_SCANCODE_KP_PERCENT | (1 << 30)),
    SDLK_KP_LESS = (SDL_Scancode.SDL_SCANCODE_KP_LESS | (1 << 30)),
    SDLK_KP_GREATER = (SDL_Scancode.SDL_SCANCODE_KP_GREATER | (1 << 30)),
    SDLK_KP_AMPERSAND = (SDL_Scancode.SDL_SCANCODE_KP_AMPERSAND | (1 << 30)),
    SDLK_KP_DBLAMPERSAND = (SDL_Scancode.SDL_SCANCODE_KP_DBLAMPERSAND | (1 << 30)),
    SDLK_KP_VERTICALBAR = (SDL_Scancode.SDL_SCANCODE_KP_VERTICALBAR | (1 << 30)),
    SDLK_KP_DBLVERTICALBAR = (SDL_Scancode.SDL_SCANCODE_KP_DBLVERTICALBAR | (1 << 30)),
    SDLK_KP_COLON = (SDL_Scancode.SDL_SCANCODE_KP_COLON | (1 << 30)),
    SDLK_KP_HASH = (SDL_Scancode.SDL_SCANCODE_KP_HASH | (1 << 30)),
    SDLK_KP_SPACE = (SDL_Scancode.SDL_SCANCODE_KP_SPACE | (1 << 30)),
    SDLK_KP_AT = (SDL_Scancode.SDL_SCANCODE_KP_AT | (1 << 30)),
    SDLK_KP_EXCLAM = (SDL_Scancode.SDL_SCANCODE_KP_EXCLAM | (1 << 30)),
    SDLK_KP_MEMSTORE = (SDL_Scancode.SDL_SCANCODE_KP_MEMSTORE | (1 << 30)),
    SDLK_KP_MEMRECALL = (SDL_Scancode.SDL_SCANCODE_KP_MEMRECALL | (1 << 30)),
    SDLK_KP_MEMCLEAR = (SDL_Scancode.SDL_SCANCODE_KP_MEMCLEAR | (1 << 30)),
    SDLK_KP_MEMADD = (SDL_Scancode.SDL_SCANCODE_KP_MEMADD | (1 << 30)),
    SDLK_KP_MEMSUBTRACT = (SDL_Scancode.SDL_SCANCODE_KP_MEMSUBTRACT | (1 << 30)),
    SDLK_KP_MEMMULTIPLY = (SDL_Scancode.SDL_SCANCODE_KP_MEMMULTIPLY | (1 << 30)),
    SDLK_KP_MEMDIVIDE = (SDL_Scancode.SDL_SCANCODE_KP_MEMDIVIDE | (1 << 30)),
    SDLK_KP_PLUSMINUS = (SDL_Scancode.SDL_SCANCODE_KP_PLUSMINUS | (1 << 30)),
    SDLK_KP_CLEAR = (SDL_Scancode.SDL_SCANCODE_KP_CLEAR | (1 << 30)),
    SDLK_KP_CLEARENTRY = (SDL_Scancode.SDL_SCANCODE_KP_CLEARENTRY | (1 << 30)),
    SDLK_KP_BINARY = (SDL_Scancode.SDL_SCANCODE_KP_BINARY | (1 << 30)),
    SDLK_KP_OCTAL = (SDL_Scancode.SDL_SCANCODE_KP_OCTAL | (1 << 30)),
    SDLK_KP_DECIMAL = (SDL_Scancode.SDL_SCANCODE_KP_DECIMAL | (1 << 30)),
    SDLK_KP_HEXADECIMAL = (SDL_Scancode.SDL_SCANCODE_KP_HEXADECIMAL | (1 << 30)),
    SDLK_LCTRL = (SDL_Scancode.SDL_SCANCODE_LCTRL | (1 << 30)),
    SDLK_LSHIFT = (SDL_Scancode.SDL_SCANCODE_LSHIFT | (1 << 30)),
    SDLK_LALT = (SDL_Scancode.SDL_SCANCODE_LALT | (1 << 30)),
    SDLK_LGUI = (SDL_Scancode.SDL_SCANCODE_LGUI | (1 << 30)),
    SDLK_RCTRL = (SDL_Scancode.SDL_SCANCODE_RCTRL | (1 << 30)),
    SDLK_RSHIFT = (SDL_Scancode.SDL_SCANCODE_RSHIFT | (1 << 30)),
    SDLK_RALT = (SDL_Scancode.SDL_SCANCODE_RALT | (1 << 30)),
    SDLK_RGUI = (SDL_Scancode.SDL_SCANCODE_RGUI | (1 << 30)),
    SDLK_MODE = (SDL_Scancode.SDL_SCANCODE_MODE | (1 << 30)),
    SDLK_AUDIONEXT = (SDL_Scancode.SDL_SCANCODE_AUDIONEXT | (1 << 30)),
    SDLK_AUDIOPREV = (SDL_Scancode.SDL_SCANCODE_AUDIOPREV | (1 << 30)),
    SDLK_AUDIOSTOP = (SDL_Scancode.SDL_SCANCODE_AUDIOSTOP | (1 << 30)),
    SDLK_AUDIOPLAY = (SDL_Scancode.SDL_SCANCODE_AUDIOPLAY | (1 << 30)),
    SDLK_AUDIOMUTE = (SDL_Scancode.SDL_SCANCODE_AUDIOMUTE | (1 << 30)),
    SDLK_MEDIASELECT = (SDL_Scancode.SDL_SCANCODE_MEDIASELECT | (1 << 30)),
    SDLK_WWW = (SDL_Scancode.SDL_SCANCODE_WWW | (1 << 30)),
    SDLK_MAIL = (SDL_Scancode.SDL_SCANCODE_MAIL | (1 << 30)),
    SDLK_CALCULATOR = (SDL_Scancode.SDL_SCANCODE_CALCULATOR | (1 << 30)),
    SDLK_COMPUTER = (SDL_Scancode.SDL_SCANCODE_COMPUTER | (1 << 30)),
    SDLK_AC_SEARCH = (SDL_Scancode.SDL_SCANCODE_AC_SEARCH | (1 << 30)),
    SDLK_AC_HOME = (SDL_Scancode.SDL_SCANCODE_AC_HOME | (1 << 30)),
    SDLK_AC_BACK = (SDL_Scancode.SDL_SCANCODE_AC_BACK | (1 << 30)),
    SDLK_AC_FORWARD = (SDL_Scancode.SDL_SCANCODE_AC_FORWARD | (1 << 30)),
    SDLK_AC_STOP = (SDL_Scancode.SDL_SCANCODE_AC_STOP | (1 << 30)),
    SDLK_AC_REFRESH = (SDL_Scancode.SDL_SCANCODE_AC_REFRESH | (1 << 30)),
    SDLK_AC_BOOKMARKS = (SDL_Scancode.SDL_SCANCODE_AC_BOOKMARKS | (1 << 30)),
    SDLK_BRIGHTNESSDOWN = (SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN | (1 << 30)),
    SDLK_BRIGHTNESSUP = (SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP | (1 << 30)),
    SDLK_DISPLAYSWITCH = (SDL_Scancode.SDL_SCANCODE_DISPLAYSWITCH | (1 << 30)),
    SDLK_KBDILLUMTOGGLE = (SDL_Scancode.SDL_SCANCODE_KBDILLUMTOGGLE | (1 << 30)),
    SDLK_KBDILLUMDOWN = (SDL_Scancode.SDL_SCANCODE_KBDILLUMDOWN | (1 << 30)),
    SDLK_KBDILLUMUP = (SDL_Scancode.SDL_SCANCODE_KBDILLUMUP | (1 << 30)),
    SDLK_EJECT = (SDL_Scancode.SDL_SCANCODE_EJECT | (1 << 30)),
    SDLK_SLEEP = (SDL_Scancode.SDL_SCANCODE_SLEEP | (1 << 30)),
    SDLK_APP1 = (SDL_Scancode.SDL_SCANCODE_APP1 | (1 << 30)),
    SDLK_APP2 = (SDL_Scancode.SDL_SCANCODE_APP2 | (1 << 30)),
    SDLK_AUDIOREWIND = (SDL_Scancode.SDL_SCANCODE_AUDIOREWIND | (1 << 30)),
    SDLK_AUDIOFASTFORWARD = (SDL_Scancode.SDL_SCANCODE_AUDIOFASTFORWARD | (1 << 30)),
    SDLK_SOFTLEFT = (SDL_Scancode.SDL_SCANCODE_SOFTLEFT | (1 << 30)),
    SDLK_SOFTRIGHT = (SDL_Scancode.SDL_SCANCODE_SOFTRIGHT | (1 << 30)),
    SDLK_CALL = (SDL_Scancode.SDL_SCANCODE_CALL | (1 << 30)),
    SDLK_ENDCALL = (SDL_Scancode.SDL_SCANCODE_ENDCALL | (1 << 30)),
}

internal enum SDL_Keymod
{
    KMOD_NONE = 0x0000,
    KMOD_LSHIFT = 0x0001,
    KMOD_RSHIFT = 0x0002,
    KMOD_LCTRL = 0x0040,
    KMOD_RCTRL = 0x0080,
    KMOD_LALT = 0x0100,
    KMOD_RALT = 0x0200,
    KMOD_LGUI = 0x0400,
    KMOD_RGUI = 0x0800,
    KMOD_NUM = 0x1000,
    KMOD_CAPS = 0x2000,
    KMOD_MODE = 0x4000,
    KMOD_SCROLL = 0x8000,
    KMOD_CTRL = KMOD_LCTRL | KMOD_RCTRL,
    KMOD_SHIFT = KMOD_LSHIFT | KMOD_RSHIFT,
    KMOD_ALT = KMOD_LALT | KMOD_RALT,
    KMOD_GUI = KMOD_LGUI | KMOD_RGUI,
    KMOD_RESERVED = KMOD_SCROLL,
}

internal static partial class SDL
{
    [NativeTypeName("#define SDLK_SCANCODE_MASK (1<<30)")]
    public const int SDLK_SCANCODE_MASK = (1 << 30);
}
