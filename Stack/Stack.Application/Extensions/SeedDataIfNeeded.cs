using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Stack.Application.SeedData;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Extensions;

public class SeedDataIfNeeded
{
    private readonly ILogger<SeedDataIfNeeded> _logger;
    private readonly ISeedData _seedData;
    private readonly IUnPack _unPackData;
    private readonly ITagRepository _tagRepository;

    public SeedDataIfNeeded(ISeedData seedData, IUnPack unPack, ITagRepository tagRepository,ILogger<SeedDataIfNeeded> logger)
    {
        _seedData = seedData;
        _unPackData = unPack;
        _tagRepository = tagRepository;
        _logger = logger;
    }

    public async Task Tags()
    {
        if (await _tagRepository.AnyAsync())
        {
            _logger.LogInformation("Database already populated.");
        }
        else
        {
            _logger.LogInformation("Data will be seed into database.");
            await SeedData();
        }
        
    }

    public async Task SeedData()
    {
        
        var objects = await _unPackData.UnPackObjects();
        if(objects is null)
        {
            _logger.LogError("Objects are null.");
        }
        await _seedData.Seed(objects);
    }
}
