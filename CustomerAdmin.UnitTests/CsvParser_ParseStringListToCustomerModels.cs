using CustomerAdmin.Data.Csv;
using CustomerAdmin.Data.Csv.Interfaces;
using CustomerAdmin.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace CustomerAdmin.UnitTests
{
    public class CsvParser_ParseStringListToCustomerModels
    {
        private readonly IConfiguration config;
        private readonly ICsvReader csvReader;
        private readonly ICsvParser csvParser;
        private readonly string path;
        private List<string> parsedCsv;
        private List<Customer> customers;

        public CsvParser_ParseStringListToCustomerModels()
        {
            config = new ConfigurationBuilder()
                .AddJsonFile("C:\\Dev\\DotNET\\CustomerAdmin\\CustomerAdmin.UnitTests\\appsettings.json")
                .Build();
            path = config.GetSection("FilePaths")["Csv:Test"];

            csvReader = new CsvReader(config);
            csvParser = new CsvParser();
            parsedCsv = csvReader.ParseFile(path);
            customers = csvParser.BuildCustomerModels(parsedCsv);
        }

        [Fact]
        public void ReturnCustomerList_NoNullFields()
        {
            foreach (var customer in customers)
            {
                Assert.NotNull(customer.Id);
                Assert.NotNull(customer.FirstName);
                Assert.NotNull(customer.LastName);
                Assert.NotNull(customer.Username);
                Assert.NotNull(customer.Email);
                Assert.NotNull(customer.Gender);
                Assert.NotNull(customer.Country);
                Assert.NotNull(customer.Ccn);
            }
        }

        [Fact]
        public void ReturnCustomerList_NotEmpty()
        {
            Assert.NotEmpty(customers);
        }

        [Fact]
        public void ReturnCustomerList_ParsedEveryLine()
        {
            var parsedLines = parsedCsv.Count - 1; // skip headers (first line)
            var createdCustomers = customers.Count;

            Assert.Equal(parsedLines, createdCustomers);
        }

        [Fact]
        public void ReturnCustomerList_ParsedToType()
        {
            Assert.IsType<List<Customer>>(customers);
        }

        
    }
}
