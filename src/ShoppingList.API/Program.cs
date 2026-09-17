using ShoppingList.API.Common.ExceptionHandlers;
using ShoppingList.API.Endpoints.Itens;
using ShoppingList.Application;
using ShoppingList.Infrastructure;

var envFile = FindEnvFile();
if (envFile is not null)
{
    DotNetEnv.Env.Load(envFile);
}

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["ConnectionStrings:DefaultConnection"] = BuildConnectionString(builder.Configuration);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();

app.MapItensEndpoints();
app.MapHealthChecks("/health");

app.Run();

static string BuildConnectionString(IConfiguration configuration)
{
    var host = Environment.GetEnvironmentVariable("DB_HOST") ?? configuration["Db:Host"] ?? "localhost";
    var port = Environment.GetEnvironmentVariable("DB_PORT") ?? configuration["Db:Port"] ?? "3306";
    var database = Environment.GetEnvironmentVariable("DB_NAME") ?? configuration["Db:Name"] ?? "shoppinglist";
    var user = Environment.GetEnvironmentVariable("DB_USER") ?? configuration["Db:User"] ?? "root";
    var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? configuration["Db:Password"] ?? string.Empty;

    return $"Server={host};Port={port};Database={database};User={user};Password={password};";
}

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