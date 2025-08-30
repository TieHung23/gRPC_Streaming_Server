using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Test
{
    public class TestStreamResponse
    {
        private readonly string url = "https://localhost:7138";

        public async Task CallingConcurrencyStreaming()
        {
            using var cts = new CancellationTokenSource();

            using var channel = GrpcChannel.ForAddress(url);

            var client = new ConcurrencyStreamer.ConcurrencyStreamerClient(channel);

            using var call = client.Stream(new Empty());

            var task = Task.Run(async () =>
            {
                await foreach (var update in call.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine($"{update.Timestamp} | {update.Currency} {update.MoneyValue}");
                }
            });

            Console.WriteLine("Enter to stop");
            Console.ReadLine();
            cts.Cancel();

            await task;
        }
    }
}
