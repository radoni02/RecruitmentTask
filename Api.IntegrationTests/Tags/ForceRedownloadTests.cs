using Api.IntegrationTests.Abstractions;
using Stack.Application;
using Stack.Application.Tags.ForceRedownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Api.IntegrationTests.Tags;

public class ForceRedownloadTests : BaseIntegrationTests
{
    public ForceRedownloadTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Handle_Should_Return_RealDataFromStackExchangeApi()
    {
        var request = new ForceRedownloadCommand();

        var result = await HttpClient.PostAsJsonAsync("api/Tags", request);

        Assert.True(result.IsSuccessStatusCode);

    }
}
