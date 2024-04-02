using Microsoft.Extensions.Logging;
using Stack.Application.Dtos;
using Stack.Application.Tags.CountPercentage;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure.CountPercentage;

internal class PercentageCounter : IPercentageCounter
{
    //yield cannot work in async methods
    public IEnumerable<float> CountPercentageFromData(List<int> counts)
    {
        var total = counts.Sum();
        foreach (var c in counts)
        {
            yield return c * 100.0f / total;
        }
    }
}
