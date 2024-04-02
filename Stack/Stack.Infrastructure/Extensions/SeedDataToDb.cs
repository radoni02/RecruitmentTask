using Microsoft.Extensions.Logging;
using Stack.Application;
using Stack.Application.SeedData;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure.Extensions;

internal class SeedDataToDb : ISeedData
{
    private readonly ILogger<SeedDataToDb> _logger;
    private readonly ITagRepository _tagRepository;

    public SeedDataToDb(ITagRepository tagRepository, ILogger<SeedDataToDb> logger)
    {
        _tagRepository = tagRepository;
        _logger = logger;
    }

    public async Task Seed<T>(List<T> tags)
    {

        var tagsList = tags.Cast<Tag>().ToList();
        await _tagRepository.BulkInsertToDbAsync(tagsList);
        _logger.LogInformation("Successfully inserted data to database.");


    }
}
