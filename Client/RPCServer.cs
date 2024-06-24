using Domain;
using Grpc.Core;
using static Demo;

namespace Client;

public class RPCServer : DemoBase
{
    public override Task<NumberDto> GetNumber(GetRequest request, ServerCallContext context)
    {
        return Task.FromResult(new NumberDto(){Value = request.Value+1});
    }

    public override Task<NumbersDto> GetNumbers(Empty request, ServerCallContext context)
    {

        var numbers = from number in Enumerable.Range(1,200) select new NumberModel(){Value = number};
    
        return Task.FromResult(numbers.ToDto());
    }

    public override async Task GetNumberStream(Empty request, IServerStreamWriter<NumberDto> responseStream, ServerCallContext context)
    {
        var numbers = from number in Enumerable.Range(1,1000) select new NumberModel(){Value = number};
        foreach(var num in numbers)
        {
            Console.WriteLine(num.Value);
            await responseStream.WriteAsync(num.ToDto());
        }
    }

    public override Task<Empty> SetLetter(SetRequest request, ServerCallContext context)
    {
        return base.SetLetter(request, context);
    }

}
