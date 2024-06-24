using Client;
using Domain;
using Grpc.Net.Client;
using static Demo;

public class RPCClient
{
    private readonly DemoClient _client;
    private readonly GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:6000");
    public RPCClient()
    {
        Console.WriteLine(channel.State);
        _client = new DemoClient(channel);
    }

    public async IAsyncEnumerable<NumberModel>
        GetNumbers(CancellationToken ct)
    {
        var result = _client.GetNumberStream(new Empty());

        if(result == null)
        {
            Console.WriteLine("What happened");
        }
        var head = await result.ResponseHeadersAsync;
        Console.WriteLine(head);

        while(await result.ResponseStream.MoveNext(ct))
        {
            yield return result.ResponseStream.Current.ToModel();
        }

    }
}

