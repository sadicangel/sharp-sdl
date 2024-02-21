using System.Diagnostics;

namespace SharpSDL.Interop;
/// <summary>Defines the type of a member as it was used in the native signature.</summary>
/// <remarks>Initializes a new instance of the <see cref="NativeTypeNameAttribute" /> class.</remarks>
/// <param name="name">The name of the type that was used in the native signature.</param>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
[Conditional("DEBUG")]
internal sealed partial class NativeTypeNameAttribute(string name) : Attribute
{
    /// <summary>Gets the name of the type that was used in the native signature.</summary>
    public string Name { get; } = name;
}

public readonly struct CBool : IEquatable<CBool>
{
    private readonly int _value;

    public CBool(bool value) => _value = value ? 1 : 0;
    public CBool(int value) => _value = value;

    public bool Equals(CBool other) => this ? other._value == 0 : other._value != 0;
    public override bool Equals(object? obj) => obj is CBool other && Equals(other);
    public override int GetHashCode() => this ? true.GetHashCode() : false.GetHashCode();

    public static bool operator ==(CBool left, CBool right) => left.Equals(right);
    public static bool operator !=(CBool left, CBool right) => !(left == right);

    public static bool operator true(CBool value) => value._value != 0;
    public static bool operator false(CBool value) => value._value == 0;

    public static implicit operator bool(CBool value) => value._value != 0;
    public static implicit operator CBool(bool value) => new(value);
}