using CsvHelper;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(IEnumerable<Payment>).IsAssignableFrom(type) || typeof(Payment).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            await using var writer = new StringWriter();
            await using var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);

            if (context.Object is IEnumerable<Payment> dataEnumerable)
            {
                await csvWriter.WriteRecordsAsync(dataEnumerable);
            }
            else if (context.Object is Payment payment)
            {
                csvWriter.WriteRecord(payment);
            }

            await response.WriteAsync(writer.ToString());
        }
    }
}