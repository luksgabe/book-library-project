using BookLibrary.Api.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Library API", Version = "v1" }));

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

//Add Database Config
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddDeppendecyInjectionConfig();

var app = builder.Build();

DatabaseConfig.CreateDatabaseIfNotExists(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Library Api");
    });
}

app.UseHttpsRedirection();

app.UseCors(p =>
{
    p.AllowAnyHeader();
    p.AllowAnyMethod();
    p.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
