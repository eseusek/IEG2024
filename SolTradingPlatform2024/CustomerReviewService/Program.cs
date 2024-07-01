using CustomerReviewService.Models;
using CustomerReviewService.Services;
using CustomerReviewService.Extensions;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddHttpClient<InventoryServiceClient>();

builder.Services.AddHttpClient<InventoryServiceClient>(client =>
    {
        client.BaseAddress = new Uri("http://inventory-management-service"); // Adjust as necessary
    })
    .AddResiliencePolicies();



builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<ReviewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
