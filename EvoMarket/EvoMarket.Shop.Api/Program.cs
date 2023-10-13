using EvoMarket.Shop.Api.Extensions;
using Microsoft.OpenApi.Models;

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
app.UsePathBase("/api-shop");

app.UseSwagger(c =>
{
 c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
 {
  swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"/api-shop" } };
 });
});
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

 app.MapControllers();
//app.MapControllerRoute("Default", "/api-shop/{controller}/{action}");

app.Run();