using Microsoft.Extensions.Logging;
using Stack.Application.Abstractions;
using Stack.Application.Abstractions.Queries;
using Stack.Application.Dtos;
using Stack.Application.Exceptions;
using Stack.Application.Tags.ForceRedownload;
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
    private readonly ILogger<CountPercentageQueryHandler> _logger;

    public CountPercentageQueryHandler(IPercentageCounter percentageCounter, ITagRepository tagRepository, ILogger<CountPercentageQueryHandler> logger)
    {
        _percentageCounter = percentageCounter;
        _tagRepository = tagRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<TagPercentageDto>> HandleAsync(CountPercentageQuery query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Start processing {nameof(CountPercentageQuery)}");
        var tags = await _tagRepository.GetAllTagsAsIEnumerable();
        if(tags is null)
        {
            _logger.LogError("Unable to processed.");
            throw new NotFoundException("Unable to get tags.");
        }
        _logger.LogInformation($"Successfully gathered from database.");
        var percentages = _percentageCounter.CountPercentageFromData(tags.Select(t => t.Count).ToList());
        _logger.LogInformation($"Percentages have been recalculated.");


        var tagPercetageDtos = tags.Zip(percentages, (tag,percentage) =>
            new TagPercentageDto(tag.Name,tag.Count,percentage));
        _logger.LogInformation($"Percentages and tags ziped.");

        return tagPercetageDtos;
    }
}
