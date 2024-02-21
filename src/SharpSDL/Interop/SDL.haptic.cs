using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct _SDL_Haptic
    {
    }

    public partial struct HapticDirection
    {
        public byte type;

        [NativeTypeName("[3]")]
        public _dir_e__FixedBuffer dir;

        [InlineArray(3)]
        public partial struct _dir_e__FixedBuffer
        {
            public int e0;
        }
    }

    public partial struct HapticConstant
    {
        public ushort type;

        public HapticDirection direction;

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

    public partial struct HapticPeriodic
    {
        public ushort type;

        public HapticDirection direction;

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

    public partial struct HapticCondition
    {
        public ushort type;

        public HapticDirection direction;

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
        public partial struct _right_sat_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(3)]
        public partial struct _left_sat_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(3)]
        public partial struct _right_coeff_e__FixedBuffer
        {
            public short e0;
        }

        [InlineArray(3)]
        public partial struct _left_coeff_e__FixedBuffer
        {
            public short e0;
        }

        [InlineArray(3)]
        public partial struct _deadband_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(3)]
        public partial struct _center_e__FixedBuffer
        {
            public short e0;
        }
    }

    public partial struct HapticRamp
    {
        public ushort type;

        public HapticDirection direction;

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

    public partial struct HapticLeftRight
    {
        public ushort type;

        public uint length;

        public ushort large_magnitude;

        public ushort small_magnitude;
    }

    public unsafe partial struct HapticCustom
    {
        public ushort type;

        public HapticDirection direction;

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
    public partial struct HapticEffect
    {
        [FieldOffset(0)]
        public ushort type;

        [FieldOffset(0)]
        public HapticConstant constant;

        [FieldOffset(0)]
        public HapticPeriodic periodic;

        [FieldOffset(0)]
        public HapticCondition condition;

        [FieldOffset(0)]
        public HapticRamp ramp;

        [FieldOffset(0)]
        public HapticLeftRight leftright;

        [FieldOffset(0)]
        public HapticCustom custom;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumHaptics", ExactSpelling = true)]
        public static extern int NumHaptics();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* HapticName(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpen", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Haptic *")]
        public static extern _SDL_Haptic* HapticOpen(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpened", ExactSpelling = true)]
        public static extern int HapticOpened(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticIndex", ExactSpelling = true)]
        public static extern int HapticIndex([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MouseIsHaptic", ExactSpelling = true)]
        public static extern int MouseIsHaptic();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpenFromMouse", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Haptic *")]
        public static extern _SDL_Haptic* HapticOpenFromMouse();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickIsHaptic", ExactSpelling = true)]
        public static extern int JoystickIsHaptic([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpenFromJoystick", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Haptic *")]
        public static extern _SDL_Haptic* HapticOpenFromJoystick([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticClose", ExactSpelling = true)]
        public static extern void HapticClose([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNumEffects", ExactSpelling = true)]
        public static extern int HapticNumEffects([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNumEffectsPlaying", ExactSpelling = true)]
        public static extern int HapticNumEffectsPlaying([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticQuery", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint HapticQuery([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNumAxes", ExactSpelling = true)]
        public static extern int HapticNumAxes([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HapticEffectSupported", ExactSpelling = true)]
        public static extern int HapticEffectSupported([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, HapticEffect* effect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNewEffect", ExactSpelling = true)]
        public static extern int HapticNewEffect([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, HapticEffect* effect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticUpdateEffect", ExactSpelling = true)]
        public static extern int HapticUpdateEffect([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int effect, HapticEffect* data);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRunEffect", ExactSpelling = true)]
        public static extern int HapticRunEffect([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int effect, uint iterations);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticStopEffect", ExactSpelling = true)]
        public static extern int HapticStopEffect([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int effect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticDestroyEffect", ExactSpelling = true)]
        public static extern void HapticDestroyEffect([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int effect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticGetEffectStatus", ExactSpelling = true)]
        public static extern int HapticGetEffectStatus([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int effect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticSetGain", ExactSpelling = true)]
        public static extern int HapticSetGain([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int gain);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticSetAutocenter", ExactSpelling = true)]
        public static extern int HapticSetAutocenter([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, int autocenter);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticPause", ExactSpelling = true)]
        public static extern int HapticPause([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticUnpause", ExactSpelling = true)]
        public static extern int HapticUnpause([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticStopAll", ExactSpelling = true)]
        public static extern int HapticStopAll([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumbleSupported", ExactSpelling = true)]
        public static extern int HapticRumbleSupported([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumbleInit", ExactSpelling = true)]
        public static extern int HapticRumbleInit([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumblePlay", ExactSpelling = true)]
        public static extern int HapticRumblePlay([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic, float strength, uint length);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumbleStop", ExactSpelling = true)]
        public static extern int HapticRumbleStop([NativeTypeName("SDL_Haptic *")] _SDL_Haptic* haptic);

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
}
