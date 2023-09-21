using EvoMarket.Payment.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDbContexts(builder.Configuration);

builder.Services.ConfigureRepositories();

// Add services to the container.
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();