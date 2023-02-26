using Grpc.Core;
using Grpc.Net.Client;

namespace GrpcService2.Services;

public class ByeerService : Byeer.ByeerBase {
    private readonly Greeter.GreeterClient _client;

    public ByeerService() {
        var channel = GrpcChannel.ForAddress("https://localhost:7078");
        _client = new Greeter.GreeterClient(channel);
    }

    public override async Task<ByeReply> SayBye(ByeRequest request, ServerCallContext context) {
        var helloReply = await _client.SayHelloAsync(new HelloRequest {
            Name = request.Name
        });
        return new ByeReply {
            Message = $"Bye {helloReply.Message}"
        };
    }
}