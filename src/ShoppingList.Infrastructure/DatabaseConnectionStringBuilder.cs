using Microsoft.Extensions.Configuration;

namespace ShoppingList.Infrastructure;

public static class DatabaseConnectionStringBuilder
{
    public static string BuildConnectionString(IConfiguration configuration)
    {
        var host = GetValueOrDefault(
            new[] { "DB_HOST", "MYSQLHOST" },
            configuration["Db:Host"] ?? configuration["ConnectionStrings:DefaultConnection"]);

        var port = GetValueOrDefault(
            new[] { "DB_PORT", "MYSQLPORT" },
            configuration["Db:Port"] ?? "3306");

        var database = GetValueOrDefault(
            new[] { "DB_NAME", "MYSQLDATABASE" },
            configuration["Db:Name"] ?? "shoppinglist");

        var user = GetValueOrDefault(
            new[] { "DB_USER", "MYSQLUSER" },
            configuration["Db:User"] ?? "root");

        var password = GetValueOrDefault(
            new[] { "DB_PASSWORD", "MYSQLPASSWORD" },
            configuration["Db:Password"] ?? string.Empty);

        return $"Server={host};Port={port};Database={database};User={user};Password={password};";
    }

    private static string GetValueOrDefault(string[] keys, string? fallback)
    {
        foreach (var key in keys)
        {
            var value = Environment.GetEnvironmentVariable(key);
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
        }

        return fallback ?? string.Empty;
    }
}
