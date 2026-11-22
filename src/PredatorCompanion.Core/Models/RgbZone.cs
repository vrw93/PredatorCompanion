using System;

public readonly struct RgbZone : IEquatable<RgbZone>
{
    public int Id { get; }
    public string Name { get; }
    public int Index { get; }

    public RgbZone(int id, string name, int index)
    {
        this.Id = id;
        this.Name = name;
        this.Index = index;
    }

    public bool Equals(RgbZone other)
    {
        return Id == other.Id && Name == other.Name && Index == other.Index;
    }

    public override bool Equals(object? obj)
    {
        return obj is RgbZone other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Index);
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