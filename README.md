# gRPC-Streaming

This repository contains a simple example of a gRPC streaming application using .NET 8.0. It demonstrates both unary and server streaming gRPC services with a client and server implementation.

## Project Structure

- **Server/**: ASP.NET Core gRPC server hosting two services:
	- `GreeterService`: Simple unary greeting service.
	- `ConcurrencyStreaminService`: Server streaming service that streams random currency values.
- **Client/**: .NET console application that connects to the server and consumes the streaming service.

## gRPC Services

### Greeter Service

- **Proto:** [`Server/Protos/greet.proto`](Server/Protos/greet.proto)
- **Implementation:** [`Server/Services/GreeterService.cs`](Server/Services/GreeterService.cs)
- **Method:** `SayHello` — returns a greeting message.

### Concurrency Streaming Service

- **Proto:** [`Server/Protos/concurrencyStreaming.proto`](Server/Protos/concurrencyStreaming.proto)
- **Implementation:** [`Server/Services/ConcurrencyStreaminService.cs`](Server/Services/ConcurrencyStreaminService.cs)
- **Method:** `Stream` — streams random currency values every second.

## How to Run

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- (Optional) [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code

### 1. Start the Server

```sh
cd Server
dotnet run
```

The server listens on `https://localhost:7138` and `http://localhost:5266` by default.

### 2. Run the Client

Open a new terminal:

```sh
cd Client
dotnet run
```

The client will connect to the server and start printing streamed currency values. Press Enter to stop.

## Protobuf Definitions

Protobuf files are located in both [`Server/Protos`](Server/Protos) and [`Client/Protos`](Client/Protos) and are kept in sync.

## Customization

- To change the streaming interval or logic, edit [`Server/Services/ConcurrencyStreaminService.cs`](Server/Services/ConcurrencyStreaminService.cs).
- To add more services or methods, update the `.proto` files and regenerate the gRPC code.

## License

MIT (add your license here)