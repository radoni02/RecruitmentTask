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
        var total = 0;
        foreach (var c in counts)
        {
            total += c;
        }
        foreach (var c in counts)
        {
            //float percentage = c * 100.0f / total;
            yield return c * 100.0f / total;
        }
    }
}
