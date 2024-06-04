using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Log;
using LogService;
using LogLevel = Log.LogLevel;

namespace LogService.Services
{
    public class GrpcLoggingService : Log.LogService.LogServiceBase
    {
        private readonly ILogger<GrpcLoggingService> _logger;

        public GrpcLoggingService(ILogger<GrpcLoggingService> logger)
        {
            _logger = logger;
        }

        public override Task<Empty> Log(LogMessage request, ServerCallContext context)
        {
            switch (request.Level)
            {
                case LogLevel.Debug:
                    _logger.LogDebug(request.Message);
                    break;
                case LogLevel.Info:
                    _logger.LogInformation(request.Message);
                    break;
                case LogLevel.Warn:
                    _logger.LogWarning(request.Message);
                    break;
                case LogLevel.Error:
                    _logger.LogError(request.Message);
                    break;
                case LogLevel.Fatal:
                    _logger.LogCritical(request.Message);
                    break;
                default:
                    _logger.LogTrace(request.Message);
                    break;
            }

            Console.WriteLine("######" + request.ToString());

            return Task.FromResult(new Empty());
        }


    }


}
