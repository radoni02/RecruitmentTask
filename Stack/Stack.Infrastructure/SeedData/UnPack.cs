using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
    private readonly StackExchangeOptions _options;

    public UnPack(StackExchangeService service,ILogger<UnPack> logger, IOptions<StackExchangeOptions> options)
    {
        _service = service;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<List<Tag>> UnPackObjects()
    {
        _logger.LogInformation("Start fetching data from StackExchange api.");
        bool hasMore = true;
        int page = 1;
        var tags = new List<Tag>();
        while (hasMore)
        {
            var response = await _service.GetTagsAsync(_options.Url + $"{page}");

            foreach (var t in response.Items)
                tags.Add(t);

            if (response.HasMore)
                if (page >= _options.NumberOfPages)
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
