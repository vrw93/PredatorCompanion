using System;
using System.Buffers.Binary;
using System.Text;

namespace PC.Platform.OpenRGB.Protocols;

public static class OpenRgbPacketCodec
{
    private const int HeaderSize = 16;

    public static byte[] Encode(OpenRgbPacket packet)
    {
        ArgumentNullException.ThrowIfNull(packet);

        byte[] payload = packet.Payload.ToArray();
        byte[] buffer = new byte[HeaderSize + payload.Length];

        Encoding.ASCII.GetBytes(
            OpenRgbPacket.DefaultMagic,
            buffer.AsSpan(0, 4)
        );

        BinaryPrimitives.WriteUInt32LittleEndian(
            buffer.AsSpan(4, 4),
            packet.DeviceId
        );

        BinaryPrimitives.WriteUInt32LittleEndian(
            buffer.AsSpan(8, 4),
            packet.PacketId
        );

        BinaryPrimitives.WriteUInt32LittleEndian(
            buffer.AsSpan(12, 4),
            packet.PayloadLength
        );

        payload.CopyTo(buffer, HeaderSize);

        return buffer;
    }

    public static OpenRgbPacket Decode(byte[] data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (data.Length < HeaderSize)
            throw new ArgumentException("Incomplate Packet Header = ", nameof(data));

        string magic = Encoding.ASCII.GetString(data, 0, 4);

        if (magic != OpenRgbPacket.DefaultMagic)
            throw new InvalidOperationException("Invalid OpenRGB Packet Magic");

        uint deviceId = BinaryPrimitives.ReadUInt32LittleEndian(
            data.AsSpan(4,4)
        );

        uint packetId = BinaryPrimitives.ReadUInt32LittleEndian(
            data.AsSpan(8, 4)
        );

        uint payloadLength = BinaryPrimitives.ReadUInt32LittleEndian(
            data.AsSpan(12, 4)
        );

        if (payloadLength > int.MaxValue)
            throw new InvalidOperationException("Payload To Large");

        if (data.Length != HeaderSize + (int)payloadLength)
            throw new ArgumentException("Packet Length != Header");

        byte[] payload = data.AsSpan(HeaderSize).ToArray();

        return new OpenRgbPacket(deviceId, packetId, payload);
    }
}