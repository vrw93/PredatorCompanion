using System;

namespace PredatorCompanion.Core.Models;

public readonly struct RgbLedUpdate
{
    public int DeviceIndex { get; }
    public int ZoneIndex { get; }
    public int LedIndex { get; }
    public RgbColor Color { get; }

    public RgbLedUpdate(
        int deviceIndex, int zoneIndex,
        int ledIndex, RgbColor color
    ) {
        ArgumentOutOfRangeException.ThrowIfNegative(deviceIndex);
        ArgumentOutOfRangeException.ThrowIfNegative(zoneIndex);
        ArgumentOutOfRangeException.ThrowIfNegative(ledIndex);

        DeviceIndex = deviceIndex;
        ZoneIndex = zoneIndex;
        LedIndex = ledIndex;
        Color = color;
    }
}