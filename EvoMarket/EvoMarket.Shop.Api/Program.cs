using EvoMarket.Shop.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls(builder.Configuration.GetSection("Urls:WebHost").Get<string>());    
    
// Add services to the container.

builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureRepositories();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.UsePathBase(new PathString("/api-shop"));
// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

// app.MapControllers();
app.MapControllerRoute("Default", "/api-shop/{controller}/{action}");

app.Run();