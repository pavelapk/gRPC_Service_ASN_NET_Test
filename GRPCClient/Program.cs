// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GRPCClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7054");
var client = new Byeer.ByeerClient(channel);

var response = await client.SayByeAsync(
    new ByeRequest {
        Name = "aboba"
    }
);

Console.WriteLine(response?.Message);

Console.ReadLine();