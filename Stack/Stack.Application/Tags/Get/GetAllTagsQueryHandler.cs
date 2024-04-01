using Stack.Application.Abstractions.Queries;
using Stack.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.Get
{
    public sealed class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, IReadOnlyList<TagDto>>
    {
        public Task<IReadOnlyList<TagDto>> HandleAsync(GetAllTagsQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
