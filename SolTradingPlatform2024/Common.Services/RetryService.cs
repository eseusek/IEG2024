using Microsoft.Extensions.Logging;
using Polly;
using Serilog.Core;
using System;

namespace Common.Services
{
    public class RetryService
    {
        private readonly ILogger<RetryService> _logger;
        private readonly int _maxAttempts;

        public RetryService(ILogger<RetryService> logger, int maxAttempts)
        {
            _logger = logger;
            _maxAttempts = maxAttempts;
        }

        public T Execute<T>(Func<T> operation)
        {
            for (int attempt = 1; attempt <= _maxAttempts; attempt++)
            {
                try
                {
                    return operation();
                }
                catch (Exception)
                {
                    if (attempt == _maxAttempts)
                    {
                        throw;
                    }
                }
            }

            return default;
        }
    }
}