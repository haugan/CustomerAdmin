using CustomerAdmin.Data.Csv.Interfaces;
using CustomerAdmin.Data.Models;
using System;
using System.Collections.Generic;

namespace CustomerAdmin.Data.Csv
{
    public class CsvParser : ICsvParser
    {
        private const char separator = ',';

        public List<Customer> BuildCustomerModels(List<string> csvLines)
        {
            var customers = new List<Customer>();

            for (int i = 1; i < csvLines.Count; i++)
            {
                var fields = csvLines[i].Split(separator);
                customers.Add(new Customer
                {
                    Id = String.IsNullOrEmpty(fields[0]) ? "" : fields[0],
                    FirstName = String.IsNullOrEmpty(fields[0]) ? "" : fields[1],
                    LastName = String.IsNullOrEmpty(fields[0]) ? "" : fields[2],
                    Username = String.IsNullOrEmpty(fields[0]) ? "" : fields[3],
                    Email = String.IsNullOrEmpty(fields[0]) ? "" : fields[4],
                    Gender = String.IsNullOrEmpty(fields[0]) ? "" : fields[5],
                    Country = String.IsNullOrEmpty(fields[0]) ? "" : fields[6],
                    City = String.IsNullOrEmpty(fields[0]) ? "" : fields[7],
                    Ccn = String.IsNullOrEmpty(fields[0]) ? "" : fields[8],
                });
            }

            return customers;
        }
    }
}
