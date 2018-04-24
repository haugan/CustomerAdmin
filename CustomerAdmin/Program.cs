using CustomerAdmin.Data.Database;
using CustomerAdmin.Data.Models.DbContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomerAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CustomerContext>();
                    CustomerAdminDbInitializer.Seed(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred while seeding the db: {e.Message}");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
