using System;

public readonly struct RgbZone : IEquatable<RgbZone>
{
    public int Index { get; }
    public string Name { get; }

    public IReadOnlyList<RgbLed> Leds { get; }

    public RgbZone(string name, int index, RgbLed[] leds)
    {
        Name = name;
        Index = index;

        ArgumentNullException.ThrowIfNull(leds);

        Leds = Array.AsReadOnly((RgbLed[])leds.Clone());
    }

    public bool Equals(RgbZone other)
    {
        return Index == other.Index;
    }

    public override bool Equals(object? obj)
    {
        return obj is RgbZone other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Index);
    }

    public static bool operator ==(RgbZone left, RgbZone right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RgbZone left, RgbZone right)
    {
        return !left.Equals(right);
    }
}