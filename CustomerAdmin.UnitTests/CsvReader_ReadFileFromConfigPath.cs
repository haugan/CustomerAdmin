using CustomerAdmin.Data.Csv;
using CustomerAdmin.Data.Csv.Interfaces;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CustomerAdmin.UnitTests
{
    public class CsvReader_ReadFileFromConfigPath
    {
        private readonly IConfiguration config;
        private readonly ICsvReader csvReader;
        private readonly string path;

        public CsvReader_ReadFileFromConfigPath()
        {
            config = new ConfigurationBuilder()
                .AddJsonFile("C:\\Dev\\DotNET\\CustomerAdmin\\CustomerAdmin.UnitTests\\appsettings.json")
                .Build();

            path = config.GetSection("FilePaths")[$"Csv:Test"];
            csvReader = new CsvReader(config);
        }

        [Fact]
        public void ReturnParsedList_NotEmpty()
        {
            var list = csvReader.ParseFile(path);
            Assert.NotEmpty(list);
        }
    }
}
