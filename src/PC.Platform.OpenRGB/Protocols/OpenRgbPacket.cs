using System;

namespace PC.Platform.OpenRGB.Protocols;

public sealed class OpenRgbPacket
{
    public const string DefaultMagic = "ORGB";

    public string Magic { get; }
    public uint DeviceId { get; }
    public uint PacketId { get; }
    public IReadOnlyList<byte> Payload { get; }

    public OpenRgbPacket(
        uint deviceId,
        uint packetId,
        byte[] payload
    ) {
        ArgumentNullException.ThrowIfNull(payload);

        Magic = DefaultMagic;
        DeviceId = deviceId;
        PacketId = packetId;

        Payload = (byte[])payload.Clone();
    }

    public uint PayloadLength => (uint)Payload.Count;
}