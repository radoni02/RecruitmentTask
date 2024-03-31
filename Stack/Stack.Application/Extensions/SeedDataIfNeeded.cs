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

    public async void SeedData()
    {
        if(await _tagRepository.AnyAsync())
        {
            //done
        }
        var tags =await _unPackData.UnPackObjects();
        if(tags is null)
        {
            //logging and exception handling
        }
        _seedData.Seed();
    }
}
