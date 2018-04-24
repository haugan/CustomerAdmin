using CustomerAdmin.Data.Csv.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerAdmin.Data.Csv
{
    public class CsvReader : ICsvReader
    {
        private readonly IConfiguration config;

        public CsvReader(IConfiguration config)
        {
            this.config = config;
        }

        public List<string> ParseFile(string path)
        {
            var parsedList = new List<string>();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        parsedList.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Couldn't read file: {e}");
            }

            return parsedList;
        }
    }
}
