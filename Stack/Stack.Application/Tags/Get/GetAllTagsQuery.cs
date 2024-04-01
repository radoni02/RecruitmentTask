using Stack.Application.Abstractions.Queries;
using Stack.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.Get;

public record GetAllTagsQuery(int Page, int PageSize) : IQuery<List<TagDto>>;
