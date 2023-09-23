using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Shop.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls(builder.Configuration.GetSection("Urls:Host").Get<string>());

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    
});

builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureRepositories(builder.Configuration);



    builder.Host.ConfigureHostConfiguration(configurationBuilder =>
{
    configurationBuilder.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true,
        reloadOnChange: true);
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();