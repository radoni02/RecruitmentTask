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
        private readonly ITagRepository _tagRepository;

        public GetAllTagsQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IReadOnlyList<TagDto>> HandleAsync(GetAllTagsQuery query, CancellationToken cancellationToken = default)
        {
            var tags = await _tagRepository.GetAllTags();
            if (tags is null)
            {
                //log error
            }

            var tagsDtos = tags.Select(t => new TagDto(
                t.Count,
                t.HasSynonyms,
                t.IsModeratorOnly,
                t.IsRequired,
                t.Name,
                t.UserId)).ToList();

            return tagsDtos;
        }
    }
}
