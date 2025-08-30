// See https://aka.ms/new-console-template for more information
using Client.Test;

Console.WriteLine("Hello, World!");


var solution = new TestStreamResponse();

await solution.CallingConcurrencyStreaming();