﻿using Stack.Application.SeedData;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure.SeedData;

public sealed class UnPack : IUnPack
{
    private readonly StackExchangeService _service;

    public UnPack(StackExchangeService service)
    {
        _service = service;
    }

    public async Task<List<Tag>> UnPackObjects()
    {
        bool hasMore = true;
        int page = 1;
        var tags = new List<Tag>();
        while (hasMore)
        {
            var response = await _service.GetTagsAsync($"/2.3/tags?page={page}&pagesize=100&order=desc&sort=popular&site=stackoverflow");

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
