namespace SharpSDL.Interop;

internal partial struct SDL_HapticDirection
{
    public byte type;

    [NativeTypeName("[3]")]
    public _dir_e__FixedBuffer dir;

    [InlineArray(3)]
    internal partial struct _dir_e__FixedBuffer
    {
        public int e0;
    }
}

internal partial struct SDL_HapticConstant
{
    public ushort type;

    public SDL_HapticDirection direction;

    public uint length;

    public ushort delay;

    public ushort button;

    public ushort interval;

    public short level;

    public ushort attack_length;

    public ushort attack_level;

    public ushort fade_length;

    public ushort fade_level;
}

internal partial struct SDL_HapticPeriodic
{
    public ushort type;

    public SDL_HapticDirection direction;

    public uint length;

    public ushort delay;

    public ushort button;

    public ushort interval;

    public ushort period;

    public short magnitude;

    public short offset;

    public ushort phase;

    public ushort attack_length;

    public ushort attack_level;

    public ushort fade_length;

    public ushort fade_level;
}

internal partial struct SDL_HapticCondition
{
    public ushort type;

    public SDL_HapticDirection direction;

    public uint length;

    public ushort delay;

    public ushort button;

    public ushort interval;

    [NativeTypeName("[3]")]
    public _right_sat_e__FixedBuffer right_sat;

    [NativeTypeName("[3]")]
    public _left_sat_e__FixedBuffer left_sat;

    [NativeTypeName("[3]")]
    public _right_coeff_e__FixedBuffer right_coeff;

    [NativeTypeName("[3]")]
    public _left_coeff_e__FixedBuffer left_coeff;

    [NativeTypeName("[3]")]
    public _deadband_e__FixedBuffer deadband;

    [NativeTypeName("[3]")]
    public _center_e__FixedBuffer center;

    [InlineArray(3)]
    internal partial struct _right_sat_e__FixedBuffer
    {
        public ushort e0;
    }

    [InlineArray(3)]
    internal partial struct _left_sat_e__FixedBuffer
    {
        public ushort e0;
    }

    [InlineArray(3)]
    internal partial struct _right_coeff_e__FixedBuffer
    {
        public short e0;
    }

    [InlineArray(3)]
    internal partial struct _left_coeff_e__FixedBuffer
    {
        public short e0;
    }

    [InlineArray(3)]
    internal partial struct _deadband_e__FixedBuffer
    {
        public ushort e0;
    }

    [InlineArray(3)]
    internal partial struct _center_e__FixedBuffer
    {
        public short e0;
    }
}

internal partial struct SDL_HapticRamp
{
    public ushort type;

    public SDL_HapticDirection direction;

    public uint length;

    public ushort delay;

    public ushort button;

    public ushort interval;

    public short start;

    public short end;

    public ushort attack_length;

    public ushort attack_level;

    public ushort fade_length;

    public ushort fade_level;
}

internal partial struct SDL_HapticLeftRight
{
    public ushort type;

    public uint length;

    public ushort large_magnitude;

    public ushort small_magnitude;
}

internal unsafe partial struct SDL_HapticCustom
{
    public ushort type;

    public SDL_HapticDirection direction;

    public uint length;

    public ushort delay;

    public ushort button;

    public ushort interval;

    public byte channels;

    public ushort period;

    public ushort samples;

    [NativeTypeName(" *")]
    public ushort* data;

    public ushort attack_length;

    public ushort attack_level;

    public ushort fade_length;

    public ushort fade_level;
}

[StructLayout(LayoutKind.Explicit)]
internal partial struct SDL_HapticEffect
{
    [FieldOffset(0)]
    public ushort type;

    [FieldOffset(0)]
    public SDL_HapticConstant constant;

    [FieldOffset(0)]
    public SDL_HapticPeriodic periodic;

    [FieldOffset(0)]
    public SDL_HapticCondition condition;

    [FieldOffset(0)]
    public SDL_HapticRamp ramp;

    [FieldOffset(0)]
    public SDL_HapticLeftRight leftright;

    [FieldOffset(0)]
    public SDL_HapticCustom custom;
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_NumHaptics")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int NumHaptics();

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* HapticName(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticOpen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Haptic *")]
    public static partial nint HapticOpen(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticOpened")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticOpened(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticIndex([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_MouseIsHaptic")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MouseIsHaptic();

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticOpenFromMouse")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Haptic *")]
    public static partial nint HapticOpenFromMouse();

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickIsHaptic")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int JoystickIsHaptic([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticOpenFromJoystick")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Haptic *")]
    public static partial nint HapticOpenFromJoystick([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticClose")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void HapticClose([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticNumEffects")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticNumEffects([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticNumEffectsPlaying")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticNumEffectsPlaying([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticQuery")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("unsigned int")]
    public static partial uint HapticQuery([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticNumAxes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticNumAxes([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticEffectSupported")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticEffectSupported([NativeTypeName("SDL_Haptic *")] nint haptic, SDL_HapticEffect* effect);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticNewEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticNewEffect([NativeTypeName("SDL_Haptic *")] nint haptic, SDL_HapticEffect* effect);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticUpdateEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticUpdateEffect([NativeTypeName("SDL_Haptic *")] nint haptic, int effect, SDL_HapticEffect* data);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticRunEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticRunEffect([NativeTypeName("SDL_Haptic *")] nint haptic, int effect, uint iterations);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticStopEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticStopEffect([NativeTypeName("SDL_Haptic *")] nint haptic, int effect);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticDestroyEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void HapticDestroyEffect([NativeTypeName("SDL_Haptic *")] nint haptic, int effect);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticGetEffectStatus")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticGetEffectStatus([NativeTypeName("SDL_Haptic *")] nint haptic, int effect);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticSetGain")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticSetGain([NativeTypeName("SDL_Haptic *")] nint haptic, int gain);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticSetAutocenter")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticSetAutocenter([NativeTypeName("SDL_Haptic *")] nint haptic, int autocenter);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticPause")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticPause([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticUnpause")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticUnpause([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticStopAll")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticStopAll([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticRumbleSupported")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticRumbleSupported([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticRumbleInit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticRumbleInit([NativeTypeName("SDL_Haptic *")] nint haptic);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticRumblePlay")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticRumblePlay([NativeTypeName("SDL_Haptic *")] nint haptic, float strength, uint length);

    [LibraryImport("SDL2", EntryPoint = "SDL_HapticRumbleStop")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int HapticRumbleStop([NativeTypeName("SDL_Haptic *")] nint haptic);

    [NativeTypeName("#define SDL_HAPTIC_CONSTANT (1u<<0)")]
    public const uint SDL_HAPTIC_CONSTANT = (1U << 0);

    [NativeTypeName("#define SDL_HAPTIC_SINE (1u<<1)")]
    public const uint SDL_HAPTIC_SINE = (1U << 1);

    [NativeTypeName("#define SDL_HAPTIC_LEFTRIGHT (1u<<2)")]
    public const uint SDL_HAPTIC_LEFTRIGHT = (1U << 2);

    [NativeTypeName("#define SDL_HAPTIC_TRIANGLE (1u<<3)")]
    public const uint SDL_HAPTIC_TRIANGLE = (1U << 3);

    [NativeTypeName("#define SDL_HAPTIC_SAWTOOTHUP (1u<<4)")]
    public const uint SDL_HAPTIC_SAWTOOTHUP = (1U << 4);

    [NativeTypeName("#define SDL_HAPTIC_SAWTOOTHDOWN (1u<<5)")]
    public const uint SDL_HAPTIC_SAWTOOTHDOWN = (1U << 5);

    [NativeTypeName("#define SDL_HAPTIC_RAMP (1u<<6)")]
    public const uint SDL_HAPTIC_RAMP = (1U << 6);

    [NativeTypeName("#define SDL_HAPTIC_SPRING (1u<<7)")]
    public const uint SDL_HAPTIC_SPRING = (1U << 7);

    [NativeTypeName("#define SDL_HAPTIC_DAMPER (1u<<8)")]
    public const uint SDL_HAPTIC_DAMPER = (1U << 8);

    [NativeTypeName("#define SDL_HAPTIC_INERTIA (1u<<9)")]
    public const uint SDL_HAPTIC_INERTIA = (1U << 9);

    [NativeTypeName("#define SDL_HAPTIC_FRICTION (1u<<10)")]
    public const uint SDL_HAPTIC_FRICTION = (1U << 10);

    [NativeTypeName("#define SDL_HAPTIC_CUSTOM (1u<<11)")]
    public const uint SDL_HAPTIC_CUSTOM = (1U << 11);

    [NativeTypeName("#define SDL_HAPTIC_GAIN (1u<<12)")]
    public const uint SDL_HAPTIC_GAIN = (1U << 12);

    [NativeTypeName("#define SDL_HAPTIC_AUTOCENTER (1u<<13)")]
    public const uint SDL_HAPTIC_AUTOCENTER = (1U << 13);

    [NativeTypeName("#define SDL_HAPTIC_STATUS (1u<<14)")]
    public const uint SDL_HAPTIC_STATUS = (1U << 14);

    [NativeTypeName("#define SDL_HAPTIC_PAUSE (1u<<15)")]
    public const uint SDL_HAPTIC_PAUSE = (1U << 15);

    [NativeTypeName("#define SDL_HAPTIC_POLAR 0")]
    public const int SDL_HAPTIC_POLAR = 0;

    [NativeTypeName("#define SDL_HAPTIC_CARTESIAN 1")]
    public const int SDL_HAPTIC_CARTESIAN = 1;

    [NativeTypeName("#define SDL_HAPTIC_SPHERICAL 2")]
    public const int SDL_HAPTIC_SPHERICAL = 2;

    [NativeTypeName("#define SDL_HAPTIC_STEERING_AXIS 3")]
    public const int SDL_HAPTIC_STEERING_AXIS = 3;

    [NativeTypeName("#define SDL_HAPTIC_INFINITY 4294967295U")]
    public const uint SDL_HAPTIC_INFINITY = 4294967295U;
}
