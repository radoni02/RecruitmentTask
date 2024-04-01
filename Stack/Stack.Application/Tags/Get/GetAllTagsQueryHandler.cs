using Stack.Application.Abstractions;
using Stack.Application.Abstractions.Queries;
using Stack.Application.Dtos;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.Get
{
    public sealed class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, PagedResult<TagDto>>
    {
        private readonly ITagRepository _tagRepository;

        public GetAllTagsQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<PagedResult<TagDto>> HandleAsync(GetAllTagsQuery query, CancellationToken cancellationToken = default)
        {
            IQueryable<Tag> tags = _tagRepository.GetAllTags();
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
                t.UserId));

            var pagedTags = await PagedResult<TagDto>.CreateAsync(tagsDtos,query.Page,query.PageSize);
            return pagedTags;
        }
    }
}
