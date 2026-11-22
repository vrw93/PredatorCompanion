using System;
using System.Collections.Generic;

public readonly struct RgbDevice : IEquatable<RgbDevice>
{
    public int Id { get; }
    public string Name { get; }
    public RgbDeviceType Type { get; }
    public IReadOnlyList<RgbZone> Zones { get; }

    public RgbDevice(int id, string name, RgbDeviceType type, RgbZone[] zones)
    {
        Id = id;
        Name = name;
        Type = type;

        ArgumentNullException.ThrowIfNull(zones);

        Zones = Array.AsReadOnly((RgbZone[])zones.Clone());
    }

    public bool Equals(RgbDevice other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is RgbDevice other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(RgbDevice left, RgbDevice right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RgbDevice left, RgbDevice right)
    {
        return !left.Equals(right);
    }
}