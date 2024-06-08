using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using PaymentService.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace PaymentService.Formatters
{
    public class CsvInputFormatter : TextInputFormatter
    {
        private readonly ILogger<CsvInputFormatter> _logger;

        public CsvInputFormatter(ILogger<CsvInputFormatter> logger)
        {
            _logger = logger;
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(Payment);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var httpContext = context.HttpContext;
            using var reader = new StreamReader(httpContext.Request.Body, encoding);
            try
            {
                var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
                await csvReader.ReadAsync(); // Use the async method
                var payment = csvReader.GetRecord<Payment>();
                _logger.LogInformation("Successfully parsed CSV data into Payment object.");
                return await InputFormatterResult.SuccessAsync(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing CSV data into Payment object.");
                return await InputFormatterResult.FailureAsync();
            }
        }

    }
}