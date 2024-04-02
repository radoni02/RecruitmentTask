using Microsoft.AspNetCore.Builder;
using Stack.Application.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Extensions;

public class SeedDataIfNeeded
{
    private readonly ISeedData _seedData;
    private readonly IUnPack _unPackData;
    private readonly ITagRepository _tagRepository;

    public SeedDataIfNeeded(ISeedData seedData, IUnPack unPack, ITagRepository tagRepository)
    {
        _seedData = seedData;
        _unPackData = unPack;
        _tagRepository = tagRepository;
    }

    public async Task Tags()
    {
        if (await _tagRepository.AnyAsync())
        {
            //done
        }
        else
        {
            await SeedData();
        }
        
    }

    public async Task SeedData()
    {
        
        var objects = await _unPackData.UnPackObjects();
        if(objects is null)
        {
            //logging and exception handling
        }
        await _seedData.Seed(objects);
    }
}
