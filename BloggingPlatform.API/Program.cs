using BloggingPlatform.Domain.DI;
using BloggingPlatform.Infrastructure;
using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();

builder.Services.InstallServices(
    builder.Configuration,
    typeof(BloggingPlatform.Domain.ServiceCollectionExtensions).Assembly,
    typeof(BloggingPlatform.Application.DependencyInstaller).Assembly,
    typeof(BloggingPlatform.Infrastructure.DependencyInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapCarter();

app.ApplyMigrations();

app.Run();
