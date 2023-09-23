using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using EvoMarket.Auth.Api.Extensions;
using EvoMarket.Auth.Service.Interfaces;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using EvoMarket.Auth.Service.Services;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.Notification.Infrastructures.Repositories;
using EvoMarket.Notification.Services.Interfaces;
using EvoMarket.Notification.Services.Services;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.Shop.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shop.Interfaces;
using Shop.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureRepositories();
    
builder.Services.AddControllers();
builder.WebHost.UseUrls("http://localhost:1214");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    OpenApiSecurityScheme scheme = new OpenApiSecurityScheme()
    {
        Description = "JWT Bearer",
        In = ParameterLocation.Header,
        Name = "JWT",
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Type = SecuritySchemeType.Http,
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.SecurityScheme,
            Id = JwtBearerDefaults.AuthenticationScheme
        }
    };
    
    options.SwaggerGeneratorOptions
        .SecuritySchemes
        .Add(JwtBearerDefaults.AuthenticationScheme, scheme);
    
    options.SwaggerGeneratorOptions
        .SecurityRequirements
        .Add(new OpenApiSecurityRequirement()
        {
            {new OpenApiSecurityScheme(scheme), new List<string>()}
        });
});


builder
    .Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        string key = builder.Configuration.GetSection("Authentication")["SecurityKey"];
        string issuer = builder.Configuration.GetSection("Authentication")["Issuer"];
        string audience = builder.Configuration.GetSection("Authentication")["Audience"];
        int expiresInMinutes = builder.Configuration.GetSection("Authentication").GetValue<int>("ExpireAtInMinutes");
        
        
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ClockSkew = TimeSpan.Zero
        };
        
    });


builder.Services
    .AddAuthorization(options =>
    {
        // options.
    });




var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();