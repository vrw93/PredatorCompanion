using System;
using System.Diagnostics.CodeAnalysis;

public readonly struct RgbLed : IEquatable<RgbLed>
{
    public int Index{ get; }
    public string Name { get; }

    // Remove When When Proven Useless
    public uint Value { get; }

    public RgbLed(int index, string name, uint value)
    {
        Index = index;
        Name = name;
        Value = value;
    }

    public bool Equals(RgbLed other)
    {
        return Index == other.Index;
    }

    public override bool Equals(object? obj)
    {
        return obj is RgbLed other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Index);
    }

    public static bool operator ==(RgbLed left, RgbLed right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RgbLed left, RgbLed right)
    {
        return !left.Equals(right);
    }
}