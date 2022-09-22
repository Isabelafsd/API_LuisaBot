

using API_LuisaBot.Repositories.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace API_LuisaBot.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration config)
        {
            string connString = getConnectionString(config);
            var conn = new NpgsqlConnection(connString);
            services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(conn));
        }

        private static string getConnectionString(IConfiguration config) {

            string connectionUrl = config["Heroku:Database_Url"];
            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');

            string[] userInfo = databaseUri.UserInfo
                                .Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};" +
                   $"Port={databaseUri.Port};Database={db};Pooling=true;" +
                   $"SSL Mode=Require;Trust Server Certificate=True;";
        }

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (appDbContext.Database.GetPendingMigrations().Any())
                {
                    appDbContext.Database.Migrate();
                }
            }
        }
    }
}
