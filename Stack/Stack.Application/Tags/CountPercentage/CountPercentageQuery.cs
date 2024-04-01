using Stack.Application.Abstractions.Queries;
using Stack.Application.Abstractions;
using Stack.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.CountPercentage;

public record CountPercentageQuery() : IQuery<IEnumerable<TagPercentageDto>>;
