using Microsoft.Extensions.Configuration;
using ShoppingList.Infrastructure;

namespace ShoppingList.UnitTests;

public sealed class DatabaseConnectionStringBuilderTests
{
    [Fact]
    public void BuildConnectionString_ShouldUseDbEnvironmentVariables()
    {
        var previousHost = Environment.GetEnvironmentVariable("DB_HOST");
        var previousPort = Environment.GetEnvironmentVariable("DB_PORT");
        var previousDatabase = Environment.GetEnvironmentVariable("DB_NAME");
        var previousUser = Environment.GetEnvironmentVariable("DB_USER");
        var previousPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        try
        {
            Environment.SetEnvironmentVariable("DB_HOST", "db");
            Environment.SetEnvironmentVariable("DB_PORT", "3306");
            Environment.SetEnvironmentVariable("DB_NAME", "shoppinglist");
            Environment.SetEnvironmentVariable("DB_USER", "shoppinglist");
            Environment.SetEnvironmentVariable("DB_PASSWORD", "secret");

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["Db:Host"] = "localhost",
                    ["Db:Port"] = "3307",
                    ["Db:Name"] = "fallback",
                    ["Db:User"] = "root",
                    ["Db:Password"] = "fallback-password",
                })
                .Build();

            var result = DatabaseConnectionStringBuilder.BuildConnectionString(configuration);

            Assert.Contains("Server=db", result);
            Assert.Contains("Port=3306", result);
            Assert.Contains("Database=shoppinglist", result);
            Assert.Contains("User=shoppinglist", result);
            Assert.Contains("Password=secret", result);
        }
        finally
        {
            Environment.SetEnvironmentVariable("DB_HOST", previousHost);
            Environment.SetEnvironmentVariable("DB_PORT", previousPort);
            Environment.SetEnvironmentVariable("DB_NAME", previousDatabase);
            Environment.SetEnvironmentVariable("DB_USER", previousUser);
            Environment.SetEnvironmentVariable("DB_PASSWORD", previousPassword);
        }
    }

    [Fact]
    public void BuildConnectionString_ShouldUseRenderMysqlEnvironmentVariables()
    {
        var previousHost = Environment.GetEnvironmentVariable("MYSQLHOST");
        var previousPort = Environment.GetEnvironmentVariable("MYSQLPORT");
        var previousDatabase = Environment.GetEnvironmentVariable("MYSQLDATABASE");
        var previousUser = Environment.GetEnvironmentVariable("MYSQLUSER");
        var previousPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD");

        try
        {
            Environment.SetEnvironmentVariable("MYSQLHOST", "render-db");
            Environment.SetEnvironmentVariable("MYSQLPORT", "3306");
            Environment.SetEnvironmentVariable("MYSQLDATABASE", "render_db");
            Environment.SetEnvironmentVariable("MYSQLUSER", "render_user");
            Environment.SetEnvironmentVariable("MYSQLPASSWORD", "render_pass");

            var configuration = new ConfigurationBuilder().Build();

            var result = DatabaseConnectionStringBuilder.BuildConnectionString(configuration);

            Assert.Contains("Server=render-db", result);
            Assert.Contains("Database=render_db", result);
            Assert.Contains("User=render_user", result);
            Assert.Contains("Password=render_pass", result);
        }
        finally
        {
            Environment.SetEnvironmentVariable("MYSQLHOST", previousHost);
            Environment.SetEnvironmentVariable("MYSQLPORT", previousPort);
            Environment.SetEnvironmentVariable("MYSQLDATABASE", previousDatabase);
            Environment.SetEnvironmentVariable("MYSQLUSER", previousUser);
            Environment.SetEnvironmentVariable("MYSQLPASSWORD", previousPassword);
        }
    }
}
