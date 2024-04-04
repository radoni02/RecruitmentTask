using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure.SeedData;

public sealed class StackExchangeOptions
{
    public string Url { get; set; }
    public int NumberOfPages { get; set; }
    public string Key { get; set; }
    public string WebSite { get; set; }
}
