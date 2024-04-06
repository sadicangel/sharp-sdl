using SharpSDL.Interop;
using SharpSDL.Objects;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Tests;

public class LayoutTests
{
    private readonly static Dictionary<Type, Type> TypeMap = new()
    {
        [typeof(SDL_Color)] = typeof(ColorRgba),
        [typeof(SDL_Event)] = typeof(Event),
    };

    [Theory]
    [MemberData(nameof(GetData))]
    public void Assert_Equivalent(Type from, Type to)
    {
        var asserter = new Asserter(from, to);
        asserter.AssertSize();
        asserter.AssertPadding();
        asserter.AssertAlignment();
    }

    public static TheoryData<Type, Type> GetData()
    {
        return TypeMap.Aggregate(
            new TheoryData<Type, Type>(), (data, entry) =>
            {
                data.Add(entry.Key, entry.Value);
                return data;
            });
    }

    internal sealed class Asserter(Type fromType, Type toType)
    {
        private static readonly MethodInfo SizeOfMethod = typeof(Unsafe).GetMethod(nameof(Unsafe.SizeOf), genericParameterCount: 1, BindingFlags.Static | BindingFlags.Public, null, types: [], null)!;

        public Type FromType { get; } = fromType;
        public Type ToType { get; } = toType;

        private static bool AreEqual<T>(T? a, T? b) => a is null ? b is null : a.Equals(b);

        private static int GetSizeOf(Type type) => (int)SizeOfMethod.MakeGenericMethod(type).Invoke(null, null)!;

        private void AssertEqual<T>(string attr, T? from, T? to) =>
            Assert.True(AreEqual(to, from), $"Expected {attr} of '{from}' ({FromType.Name}). Actual {attr} was '{to}' ({ToType.Name})");

        public void AssertSize() => AssertEqual("size", GetSizeOf(FromType), GetSizeOf(ToType));

        public void AssertPadding() => AssertEqual("padding", GetPadding(FromType), GetPadding(ToType));

        public void AssertAlignment() => AssertEqual("alignment", GetAlignment(FromType), GetAlignment(ToType));

        private static int GetAlignment(Type type)
        {
            return GetAlignmentImpl(type);

            static int GetAlignmentImpl(Type type)
            {
                if (type.IsPrimitive)
                    return GetSizeOf(type);

                var align = 0;

                foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    align = int.Max(align, GetAlignmentImpl(field.FieldType));
                }

                return int.Min(8, align);
            }
        }

        private static int GetPadding(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            int sizeOfFields = 0;
            foreach (var field in fields)
            {
                var offsetAttr = field.GetCustomAttribute<FieldOffsetAttribute>();
                int fieldOffset = offsetAttr != null ? offsetAttr.Value : sizeOfFields;

                int fieldSize = GetSizeOf(field.FieldType);
                sizeOfFields = fieldOffset + fieldSize;
            }

            int alignment = 1; // Default alignment
            var structLayoutAttr = type.GetCustomAttribute<StructLayoutAttribute>();
            if (structLayoutAttr is not null)
            {
                alignment = structLayoutAttr.Pack == 0 ? 1 : structLayoutAttr.Pack;
            }

            int padding = (sizeOfFields % alignment) == 0 ? 0 : alignment - (sizeOfFields % alignment);
            return padding;
        }
    }
}