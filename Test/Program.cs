// The port number must match the port of the gRPC server.
var client = new RPCClient();
var reply = client.GetNumbers(CancellationToken.None);
await foreach(var r in reply)
{
    Console.WriteLine(r.Value);
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
