using Microsoft.EntityFrameworkCore;
using ShoppingList.API.Common.ExceptionHandlers;
using ShoppingList.API.Endpoints.Itens;
using ShoppingList.Application;
using ShoppingList.Infrastructure;
using ShoppingList.Infrastructure.Persistence;

var envFile = FindEnvFile();
if (envFile is not null)
{
    DotNetEnv.Env.Load(envFile);
}

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["ConnectionStrings:DefaultConnection"] = DatabaseConnectionStringBuilder.BuildConnectionString(builder.Configuration);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ShoppingListDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();

app.MapItensEndpoints();
app.MapHealthChecks("/health");

app.Run();

static string? FindEnvFile()
{
    var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

    while (directory is not null)
    {
        var candidate = Path.Combine(directory.FullName, ".env");
        if (File.Exists(candidate))
        {
            return candidate;
        }

        directory = directory.Parent;
    }

    return null;
}