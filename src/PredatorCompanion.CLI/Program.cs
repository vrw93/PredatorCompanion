using PC.Platform.OpenRGB.Client;
using System.Net.Sockets;

await using var client = new OpenRgbClient();

try
{
    await client.ConnectAsync();

    Console.WriteLine("Connected to OpenRGB!");
}
catch (SocketException e)
{
    Console.WriteLine($"Connection failed: {e.Message}");
}