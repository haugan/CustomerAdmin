using CustomerAdmin.Data.Models;
using System.Collections.Generic;

namespace CustomerAdmin.Data.Csv.Interfaces
{
    public interface ICsvParser
    {
        List<Customer> BuildCustomerModels(List<string> csvLines);
    }
}
