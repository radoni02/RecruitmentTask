using Microsoft.Extensions.Logging;
using Stack.Application.SeedData;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure.SeedData;

internal sealed class UnPack : IUnPack
{
    private readonly ILogger<UnPack> _logger;
    private readonly StackExchangeService _service;

    public UnPack(StackExchangeService service,ILogger<UnPack> logger)
    {
        _service = service;
        _logger = logger;
    }

    public async Task<List<T>> UnPackObjects<T>()
        where T : class, IStackMarker
    {
        _logger.LogInformation("Start fetching data from StackExchange api.");
        bool hasMore = true;
        int page = 1;
        var tags = new List<T>();
        while (hasMore)
        {
            var response = await _service.GetTagsAsync<T>($"/2.3/tags?page={page}&pagesize=100&order=desc&sort=popular&site=stackoverflow");

            foreach (var t in response.Items)
                tags.Add(t);

            if (response.HasMore)
                if (page >= 2)
                    hasMore = false;
                else
                {
                    hasMore = true;
                    page++;
                }

            else
                hasMore = false;

        }
        return tags;
    }
}
