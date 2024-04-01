using Stack.Application.Abstractions;
using Stack.Application.Abstractions.Queries;
using Stack.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.CountPercentage;

public sealed class CountPercentageQueryHandler : IQueryHandler<CountPercentageQuery, IEnumerable<TagPercentageDto>>
{
    private readonly IPercentageCounter _percentageCounter;
    private readonly ITagRepository _tagRepository;

    public CountPercentageQueryHandler(IPercentageCounter percentageCounter, ITagRepository tagRepository)
    {
        _percentageCounter = percentageCounter;
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<TagPercentageDto>> HandleAsync(CountPercentageQuery query, CancellationToken cancellationToken = default)
    {
        var tags = await _tagRepository.GetAllTagsAsIEnumerable();
        if(tags is null)
        {
            //log error
        }
        var percentages = _percentageCounter.CountPercentageFromData(tags.Select(t => t.Count).ToList());

        
        var tagPercetageDtos = tags.Zip(percentages, (tag,percentage) =>
            new TagPercentageDto(tag.Name,tag.Count,percentage));


        return tagPercetageDtos;
    }
}
