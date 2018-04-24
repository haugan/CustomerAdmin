using System.Collections.Generic;

namespace CustomerAdmin.Data.Csv.Interfaces
{
    public interface ICsvReader
    {
        List<string> ParseFile(string path);
    }
}
