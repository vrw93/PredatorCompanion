using PC.Platform.OpenRGB.Client;

await using var client = new OpenRgbClient();

try
{
    await client.ConnectAsync();

    Console.WriteLine("Connected to OpenRGB!");

    uint serverVersion =
        await client.NegotiateProtocolVersionAsync(3);

    Console.WriteLine($"Server Protocol: {serverVersion}");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}