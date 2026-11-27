using PC.Platform.OpenRGB.Protocols;

var packet = new OpenRgbPacket(
    0,
    40,
    new byte[] { 3, 0, 0, 0 }
);

byte[] encoded = OpenRgbPacketCodec.Encode(packet);

var decoded = OpenRgbPacketCodec.Decode(encoded);

Console.WriteLine($"Device: {decoded.DeviceId}");
Console.WriteLine($"Packet: {decoded.PacketId}");
Console.WriteLine($"Payload: {decoded.PayloadLength}");