using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace CustomerReviewService.Extensions
{
    public static class HttpClientBuilderExtensions
    {
        public static IHttpClientBuilder AddResiliencePolicies(this IHttpClientBuilder builder)
        {
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

            return builder
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(circuitBreakerPolicy);
        }
    }
}