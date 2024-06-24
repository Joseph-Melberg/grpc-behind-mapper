using Client;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://localhost:6000");
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGrpcService<RPCServer>();//.RequireHost($"*:6000");

app.Run();
