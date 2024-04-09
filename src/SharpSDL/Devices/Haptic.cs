namespace SharpSDL.Devices;
public sealed class Haptic : IDisposable
{
    private readonly nint _haptic;

    internal Haptic(nint haptic) => _haptic = haptic;

    public int DeviceIndex { get => SDL2.HapticIndex(_haptic) is var i and >= 0 ? i : SdlException.ThrowLastError<int>(); }

    public int EffectStoreCount { get => SDL2.HapticNumEffects(_haptic) is var i and >= 0 ? i : SdlException.ThrowLastError<int>(); }

    public int EffectPlayCount { get => SDL2.HapticNumEffectsPlaying(_haptic) is var i and >= 0 ? i : SdlException.ThrowLastError<int>(); }

    public HapticFeature Features { get => SDL2.HapticQuery(_haptic) is var f and > 0 ? (HapticFeature)f : SdlException.ThrowLastError<HapticFeature>(); }

    public int AxisCount { get => SDL2.HapticNumAxes(_haptic) is var c and >= 0 ? c : SdlException.ThrowLastError<int>(); }

    public bool IsRumbleSupported
    {
        get => SDL2.HapticRumbleSupported(_haptic) switch
        {
            0 => false,
            1 => true,
            _ => SdlException.ThrowLastError<bool>()
        };
    }

    public void SetGain(int value) =>
        _ = SDL2.HapticSetGain(_haptic, value) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void SetAutoCenter(int value) =>
        _ = SDL2.HapticSetAutocenter(_haptic, value) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void Pause() => _ = SDL2.HapticPause(_haptic) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void Resume() => _ = SDL2.HapticUnpause(_haptic) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void StopAllEffects() => _ = SDL2.HapticStopAll(_haptic) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void RumbleInit() => _ = SDL2.HapticRumbleInit(_haptic) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void RumblePlay(float strength, TimeSpan duration) => _ = SDL2.HapticRumblePlay(_haptic, strength, (uint)duration.TotalMilliseconds) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void RumbleStop() => _ = SDL2.HapticRumbleStop(_haptic) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public bool SupportsEffect(ref readonly HapticEffect effect)
    {
        unsafe
        {
            fixed (HapticEffect* ptr = &effect)
            {
                return SDL2.HapticEffectSupported(_haptic, (SDL_HapticEffect*)ptr) switch
                {
                    0 => false,
                    1 => true,
                    _ => SdlException.ThrowLastError<bool>()
                };
            }
        }
    }

    public HapticEffectId CreateEffect(ref readonly HapticEffect effect)
    {
        unsafe
        {
            fixed (HapticEffect* ptr = &effect)
            {
                var effectId = SDL2.HapticNewEffect(_haptic, (SDL_HapticEffect*)ptr);
                return effectId >= 0 ? new HapticEffectId(effectId) : SdlException.ThrowLastError<HapticEffectId>();
            }
        }
    }

    public void UpdateEffect(HapticEffectId effectId, ref readonly HapticEffect effect)
    {
        unsafe
        {
            fixed (HapticEffect* ptr = &effect)
            {
                _ = SDL2.HapticUpdateEffect(_haptic, effectId._effectId, (SDL_HapticEffect*)ptr) is 0
                    ? 0
                    : SdlException.ThrowLastError<int>();
            }
        }
    }

    public void RunEffect(HapticEffectId effectId, uint iterations) =>
        _ = SDL2.HapticRunEffect(_haptic, effectId._effectId, iterations) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void StopEffect(HapticEffectId effectId) =>
        _ = SDL2.HapticStopEffect(_haptic, effectId._effectId) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void DestroyEffect(HapticEffectId effectId) =>
        SDL2.HapticDestroyEffect(_haptic, effectId._effectId);

    public void Dispose()
    {
        if (_haptic is not 0)
        {
            unsafe
            {
                SDL2.HapticClose(_haptic);
                ref var ptr = ref Unsafe.AsRef(in _haptic);
                ptr = 0;
            }
        }
    }

    public static int HapticDeviceCount() => SDL2.NumHaptics() is var n and >= 0 ? n : SdlException.ThrowLastError<int>();

    public static Haptic FromMouse()
    {
        var haptic = SDL2.HapticOpenFromMouse();
        if (haptic is 0)
            SdlException.ThrowLastError();
        return new Haptic(haptic);
    }

    public static Haptic FromJoystick(Joystick joystick)
    {
        var haptic = SDL2.HapticOpenFromJoystick(joystick._joystick);
        if (haptic is 0)
            SdlException.ThrowLastError();
        return new Haptic(haptic);
    }
}

public enum HapticEffectType : ushort
{
    Constant = (ushort)SDL2.SDL_HAPTIC_CONSTANT,
    Sine = (ushort)SDL2.SDL_HAPTIC_SINE,
    LeftRight = (ushort)SDL2.SDL_HAPTIC_LEFTRIGHT,
    Triangle = (ushort)SDL2.SDL_HAPTIC_TRIANGLE,
    SawtoothUp = (ushort)SDL2.SDL_HAPTIC_SAWTOOTHUP,
    SawtoothDown = (ushort)SDL2.SDL_HAPTIC_SAWTOOTHDOWN,
    Ramp = (ushort)SDL2.SDL_HAPTIC_RAMP,
    Spring = (ushort)SDL2.SDL_HAPTIC_SPRING,
    Damper = (ushort)SDL2.SDL_HAPTIC_DAMPER,
    Inertia = (ushort)SDL2.SDL_HAPTIC_INERTIA,
    Friction = (ushort)SDL2.SDL_HAPTIC_FRICTION,
    Custom = (ushort)SDL2.SDL_HAPTIC_CUSTOM,
}

public enum HapticEffectStatus
{
    Stopped,
    Playing,
}

[Flags]
public enum HapticFeature : uint
{
    Gain = SDL2.SDL_HAPTIC_GAIN,
    AutoCenter = SDL2.SDL_HAPTIC_AUTOCENTER,
    Status = SDL2.SDL_HAPTIC_STATUS,
    Pause = SDL2.SDL_HAPTIC_PAUSE,
}

public enum HapticCoordinateSystem : byte
{
    Polar = SDL2.SDL_HAPTIC_POLAR,
    Cartesian = SDL2.SDL_HAPTIC_CARTESIAN,
    Spherical = SDL2.SDL_HAPTIC_SPHERICAL,
    SteeringAxis = SDL2.SDL_HAPTIC_STEERING_AXIS
}

[StructLayout(LayoutKind.Explicit, Size = 16, Pack = 4)]
public readonly record struct HapticDirection
{
    [FieldOffset(0)]
    public readonly HapticCoordinateSystem CoordinateSystem;
    [FieldOffset(4)]
    public readonly int X;
    [FieldOffset(8)]
    public readonly int Y;
    [FieldOffset(16)]
    public readonly int Z;
}

public readonly struct HapticEffectId
{
    internal readonly int _effectId;

    internal HapticEffectId(int effectId) => _effectId = effectId;
}


[StructLayout(LayoutKind.Explicit)]
public readonly struct HapticEffect
{
    [FieldOffset(0)]
    public readonly HapticEffectType Type;

    [FieldOffset(0)]
    public readonly HapticEffectUnion As;
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct HapticEffectUnion
{

    [FieldOffset(0)]
    public readonly ConstantHapticEffect Constant;

    [FieldOffset(0)]
    public readonly PeriodicHapticEffect Periodic;

    [FieldOffset(0)]
    public readonly ConditionHapticEffect Condition;

    [FieldOffset(0)]
    public readonly RampHapticEffect Ramp;

    [FieldOffset(0)]
    public readonly LeftRightHapticEffect LeftRight;

    [FieldOffset(0)]
    public readonly CustomHapticEffect Custom;
}

public readonly struct ConstantHapticEffect
{
    public readonly HapticEffectType Type;
    public readonly HapticDirection Direction;
    public readonly uint Length;
    public readonly ushort Delay;
    public readonly ushort Button;
    public readonly ushort Interval;
    public readonly short Level;
    public readonly ushort AttackLength;
    public readonly ushort AttackLevel;
    public readonly ushort FadeLength;
    public readonly ushort FadeLevel;
}

public readonly struct PeriodicHapticEffect
{
    public readonly HapticEffectType Type;
    public readonly HapticDirection Direction;
    public readonly uint Length;
    public readonly ushort Delay;
    public readonly ushort Button;
    public readonly ushort Interval;
    public readonly ushort Period;
    public readonly short Magnitude;
    public readonly short Offset;
    public readonly ushort Phase;
    public readonly ushort AttackLength;
    public readonly ushort AttackLevel;
    public readonly ushort FadeLength;
    public readonly ushort FadeLevel;
}

public readonly struct ConditionHapticEffect
{
    public readonly HapticEffectType Type;
    public readonly HapticDirection Direction;
    public readonly uint Length;
    public readonly ushort Delay;
    public readonly ushort Button;
    public readonly ushort Interval;
    public readonly Vec3<ushort> RightSat;
    public readonly Vec3<ushort> LeftSat;
    public readonly Vec3<short> RightCoeff;
    public readonly Vec3<short> LeftCoeff;
    public readonly Vec3<ushort> DeadBand;
    public readonly Vec3<short> Center;
}

[InlineArray(3)]
public struct Vec3<T> where T : unmanaged
{
    internal T _e0;
}

public readonly struct RampHapticEffect
{
    public readonly HapticEffectType Type;
    public readonly HapticDirection Direction;
    public readonly uint Length;
    public readonly ushort Delay;
    public readonly ushort Button;
    public readonly ushort Interval;
    public readonly short Start;
    public readonly short End;
    public readonly ushort AttackLength;
    public readonly ushort AttackLevel;
    public readonly ushort FadeLength;
    public readonly ushort FadeLevel;
}

public readonly struct LeftRightHapticEffect
{
    public readonly HapticEffectType Type;
    public readonly uint Length;
    public readonly ushort LargeMagnitude;
    public readonly ushort SmallMagnitude;
}

public readonly struct CustomHapticEffect
{
    public readonly HapticEffectType Type;
    public readonly HapticDirection Direction;
    public readonly uint Length;
    public readonly ushort Delay;
    public readonly ushort Button;
    public readonly ushort Interval;
    public readonly byte Channels;
    public readonly ushort Period;
    public readonly ushort Samples;
    public readonly unsafe ushort* Data;
    public readonly ushort AttackLength;
    public readonly ushort AttackLevel;
    public readonly ushort FadeLength;
    public readonly ushort FadeLevel;
}