using System;
using Grpc.Net.Client;
using Serilog;
using Log;  // This is the namespace defined in your .proto file

namespace Common.Services
{
    public class LoggingService
    {
        private readonly Serilog.ILogger _log;
        private readonly GrpcChannel _channel;
        private readonly LogService.LogServiceClient _client;

        public LoggingService()
        {
            _log = Serilog.Log.ForContext<LoggingService>();

            // Create a gRPC channel
            _channel = GrpcChannel.ForAddress("localhost:50051");

            // Create a client for the gRPC service
            _client = new LogService.LogServiceClient(_channel);
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            // Log the error locally
            _log.Error(ex, message, args);

            // Create a log message for the gRPC service
            var grpcMessage = new LogMessage
            {
                Message = string.Format(message, args),
                Exception = ex.ToString(),
                Level = LogLevel.Error
            };

            // Send the log message to the gRPC service
            _client.Log(grpcMessage);
        }

        public void LogInformation(string message, params object[] args)
        {
            // Log the information locally
            _log.Information(message, args);

            // Create a log message for the gRPC service
            var grpcMessage = new LogMessage
            {
                Message = string.Format(message, args),
                Level = LogLevel.Info
            };

            // Send the log message to the gRPC service
            _client.Log(grpcMessage);
        }

        public void LogWarning(string message, params object[] args)
        {
            // Log the warning locally
            _log.Warning(message, args);

            // Create a log message for the gRPC service
            var grpcMessage = new LogMessage
            {
                Message = string.Format(message, args),
                Level = LogLevel.Warn
            };

            // Send the log message to the gRPC service
            _client.Log(grpcMessage);
        }

        // Implement similar methods for other log levels (LogDebug, LogTrace, etc.)
    }
}
