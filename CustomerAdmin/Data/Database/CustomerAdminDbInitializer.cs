using CustomerAdmin.Data.Csv;
using CustomerAdmin.Data.Models.DbContexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace CustomerAdmin.Data.Database
{
    public static class CustomerAdminDbInitializer
    {
        public static void Seed(CustomerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;
            }

            var config = new ConfigurationBuilder().AddJsonFile("C:\\Dev\\DotNET\\CustomerAdmin\\CustomerAdmin\\appsettings.json").Build();
            var parsedCsv = new CsvReader(config).ParseFile(config.GetSection("FilePaths")["Csv:Mockaroo"]);
            var customers = new CsvParser().BuildCustomerModels(parsedCsv);

            foreach (var c in customers)
            {
                if (String.IsNullOrEmpty(c.Id))
                {
                    continue;
                }

                context.Customers.Add(c);
            }

            context.SaveChanges();
        }
    }
}
