using M3S02_5;
using M3S02_5.Configurations;
using M3S02_5.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers().Services
    .AddAuthentication("ApiKey")
    .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthorizationHandler>("ApiKey", null)
    .Services
    .AddDbContext<ApiKeyContext>()
    .AddScoped<IClienteService, ClienteService>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(swagger =>
    {
        swagger.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Description = "ApiKey via header",
            Type = SecuritySchemeType.ApiKey,
            Name = "XApiKey",
            In = ParameterLocation.Header,
            Scheme = "ApiKeyScheme"
        });

        var key = new OpenApiSecurityScheme()
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKey"
            },
            In = ParameterLocation.Header
        };

        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { key, new List<string>() }
        });
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();