using Api.IntegrationTests.Abstractions;
using Docker.DotNet.Models;
using FluentAssertions;
using Stack.Application.Dtos;
using Stack.Application.Tags.CountPercentage;
using Stack.Domain.Model;
using Stack.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Api.IntegrationTests.Tags;

public class CountPercentageTests : BaseIntegrationTests
{
    public CountPercentageTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Should_Return3FloatValues()
    {
        float[] percentages = { 2f * 100f / 15f, 5f * 100f / 15f, 8f * 100f / 15f };

        var response = await HttpClient.GetFromJsonAsync<IEnumerable<TagPercentageDto>>("api/Tags/percentages");

        response.Select(r => r.Percentage)
            .Should().HaveCount(3)
            .And.AllBeOfType<float>()
            .And.Contain(percentages);
    }
}
