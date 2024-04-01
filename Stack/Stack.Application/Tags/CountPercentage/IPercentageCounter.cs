using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.CountPercentage;

public interface IPercentageCounter
{
    IEnumerable<float> CountPercentageFromData(List<int> counts);
}
