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

internal class SeedDataToDb : ISeedData//here will be writting to db
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
        try
        {
            var tagsList = tags.Cast<Tag>().ToList();
            if (!await _tagRepository.BulkInsertToDbAsync(tagsList))
            {
                _logger.LogError($"Unable to insert data into database.");
                throw new Exception("Unable to insert data into database.");
            }
            _logger.LogInformation("Successfully inserted data to database.");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, $"Unable to cust data to Tag.");
            throw new InvalidCastException();
        }

    }
}
