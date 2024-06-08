using IEGEasyCreditcardService.Services;

namespace IEGEasyCreditcardService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register multiple instances of ICreditcardValidator
            builder.Services.AddScoped<ICreditcardValidator, CreditcardValidator>();
            builder.Services.AddScoped<ICreditcardValidator, CreditcardValidator>();

            builder.Services.AddScoped<Common.Services.LoggingService>();
            builder.Services.AddScoped<Common.Services.RetryService>(sp =>
                new Common.Services.RetryService(
                    sp.GetRequiredService<ILogger<Common.Services.RetryService>>(),
                    int.Parse(builder.Configuration["MaxAttempts"] ?? "0")));


            // Register RoundRobinSelector
            builder.Services.AddScoped<RoundRobinSelector>(sp =>
            {
                var validators = sp.GetServices<ICreditcardValidator>().ToList();
                return new RoundRobinSelector(validators);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}