using EvoMarket.Payment.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDbContexts(builder.Configuration);

builder.Services.ConfigureRepositories();

// Add services to the container.
builder.Host.ConfigureHostConfiguration(configurationBuilder =>
{
    configurationBuilder.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true,
        reloadOnChange: true);
});


builder.WebHost
    .UseUrls("http://*:1211");

//add serilog 
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UsePathBase("/api-payment");
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();