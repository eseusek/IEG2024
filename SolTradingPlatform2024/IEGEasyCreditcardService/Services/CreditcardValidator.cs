using IEGEasyCreditcardService.Models;
using Common.Services;

namespace IEGEasyCreditcardService.Services
{
    public class CreditcardValidator : ICreditcardValidator
    {
        private readonly LoggingService _loggingService;
        private readonly RetryService _retryService;
        private readonly RoundRobinSelector _selector;

        public CreditcardValidator(LoggingService loggingService, RetryService retryService, RoundRobinSelector selector)
        {
            _loggingService = loggingService;
            _retryService = retryService;
            _selector = selector;
        }

        public bool IsValid(CreditcardTransaction transaction)
        {
            while (true)
            {
                try
                {
                    return _retryService.Execute<bool>(() =>
                    {
                        var service = _selector.GetNextService();
                        return service.IsValid(transaction);
                    });
                }
                catch (Exception ex)
                {
                    _loggingService.LogError(ex, "Failed to validate transaction: {Transaction}", transaction);
                    // After n unsuccessful attempts, the next service will be called in the next iteration of the loop.
                }
            }
        }

    }


}