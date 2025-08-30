using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Server.Protos;

namespace Server.Services
{
    public class ConcurrencyStreaminService : ConcurrencyStreamer.ConcurrencyStreamerBase
    {
        private readonly Random _rand = new();

        private readonly ILogger<ConcurrencyStreaminService> _logger;

        public ConcurrencyStreaminService(ILogger<ConcurrencyStreaminService> logger)
        {
            _logger = logger;
        }

        public override async Task Stream(Empty request, IServerStreamWriter<StreamResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var value = Math.Round(1000 + _rand.NextDouble() * 100, 2);

                var response = new StreamResponse
                {
                    MoneyValue = value,
                    Currency = "USD",
                    Timestamp = DateTime.UtcNow.ToString("O")
                };

                _logger.LogInformation(response.ToString());

                await responseStream.WriteAsync(response);

                await Task.Delay(1000, context.CancellationToken);
            }
        }
    }
}
