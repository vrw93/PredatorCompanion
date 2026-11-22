using System;

public readonly struct RgbColor : IEquatable<RgbColor>
{
    public byte Red { get; }
    public byte Green { get; }
    public byte Blue { get; }

    public RgbColor(byte red, byte green, byte blue)
    {
        this.Red = red;
        this.Green = green;
        this.Blue = blue;
    }

    public string ToHex()
    {
        return $"#{Red.ToHex()}{Green.ToHex()}{Blue.ToHex()}";
    }

    public bool Equals(RgbColor other)
    {
        return Red == other.Red &&
               Green == other.Green &&
               Blue == other.Blue;
    }

    public override bool Equals(object? obj)
    {
        return obj is RgbColor other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Red, Green, Blue);
    }

    public static bool operator ==(RgbColor left, RgbColor right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RgbColor left, RgbColor right)
    {
        return !left.Equals(right);
    }
}

public static class Extensions
{
    public static string ToHex(this byte value)
    {
        return $"{value:X2}";
    }
}

public static class RgbColors
{
    public static readonly RgbColor Red = new RgbColor(255, 0, 0);
    public static readonly RgbColor Green = new RgbColor(0, 255, 0);
    public static readonly RgbColor Blue = new RgbColor(0, 0, 255);
    public static readonly RgbColor Black = new RgbColor(0, 0, 0);
    public static readonly RgbColor White = new RgbColor(255, 255, 255);
}