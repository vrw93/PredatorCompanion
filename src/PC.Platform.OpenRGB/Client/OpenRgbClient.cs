using System;
using System.Buffers.Binary;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using PC.Platform.OpenRGB.Protocols;

namespace PC.Platform.OpenRGB.Client;

public sealed class OpenRgbClient : IAsyncDisposable
{
    private const int HeaderSize = 16;
    private const uint MaxPayloadLength = 16 * 1024 * 1024;

    private readonly string _host;
    private readonly int _port;

    private TcpClient? _client;
    private NetworkStream? _stream;

    public OpenRgbClient(string host = "127.0.0.1", int port = 6742)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(host);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(port);

        _host = host;
        _port = port;
    }

    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        if (_client is not null)
            throw new InvalidOperationException("Client Is Already Initialized");

        var client = new TcpClient();

        try
        {
            await client.ConnectAsync(
                _host,
                _port,
                cancellationToken);

            _client = client;
            _stream = client.GetStream();
        }
        catch
        {
            client.Dispose();
            throw;
        }
    }

    public async Task SendPacketAsync(
        OpenRgbPacket packet,
        CancellationToken cancellationToken = default
    ) {
        ArgumentNullException.ThrowIfNull(packet);

        NetworkStream stream = GetStream();

        byte[] data = OpenRgbPacketCodec.Encode(packet);

        await stream.WriteAsync(
            data.AsMemory(),
            cancellationToken
        );
    }

    public async Task<OpenRgbPacket> RecivePacketAsync(CancellationToken cancellation = default)
    {
        NetworkStream stream = GetStream();

        byte[] header = new byte[HeaderSize];

        await stream.ReadExactlyAsync(
            header.AsMemory(),
            cancellation
        );

        uint payloadLength = BinaryPrimitives.ReadUInt32LittleEndian(header.AsSpan(12, 4));

        if (payloadLength > MaxPayloadLength)
            throw new InvalidOperationException($"Payload To Large. Max {MaxPayloadLength}");

        byte[] packetData = new byte[HeaderSize + (int)payloadLength];

        header.CopyTo(packetData, 0);

        if(payloadLength > 0)
        {
            await stream.ReadExactlyAsync(
                packetData.AsMemory(HeaderSize, (int)payloadLength),
                cancellation
            );
        }

        return OpenRgbPacketCodec.Decode(packetData);
    }

    public async Task<uint> NegotiateProtocolVersionAsync(
        uint requestedVersion = 3,
        CancellationToken cancellation = default
    ) {
        byte[] payload = new byte[4];

        BinaryPrimitives.WriteUInt32LittleEndian(
            payload,
            requestedVersion
        );

        var request = new OpenRgbPacket(
            deviceId: 0,
            packetId: 40,
            payload: payload
        );

        await SendPacketAsync(request, cancellation);

        OpenRgbPacket response = await RecivePacketAsync(cancellation);

        if (response.PacketId != 40)
            throw new InvalidOperationException($"Unexpected Respond Packet Id: {response.PacketId}");

        if (response.Payload.Count != 4)
            throw new InvalidOperationException("Invalid Protocol Version");

        byte[] responsePayload = [
            response.Payload[0],
            response.Payload[1],
            response.Payload[2],
            response.Payload[3]
        ];

        return BinaryPrimitives.ReadUInt32LittleEndian(responsePayload);
    }

    private NetworkStream GetStream()
    {
        return _stream ?? throw new InvalidOperationException("Client Is Not Connected");
    }

    public ValueTask DisposeAsync()
    {
        _stream?.Dispose();
        _client?.Dispose();

        _stream = null;
        _client = null;

        return ValueTask.CompletedTask;
    }
}