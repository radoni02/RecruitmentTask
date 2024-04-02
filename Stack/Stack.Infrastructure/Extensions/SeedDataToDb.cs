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
    private readonly ITagRepository _tagRepository;

    public SeedDataToDb(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task Seed<T>(List<T> tags)
    {
        try
        {
            var tagsList = tags.Cast<Tag>().ToList();
            if (!await _tagRepository.BulkInsertToDbAsync(tagsList))
            {
                //throw ex
                //log error
            }
            //log success
        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync($"{ex.Message}");
        }

    }
}
