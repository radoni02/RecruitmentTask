using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.IntegrationTests.Abstractions;

public class BaseIntegrationTests : IClassFixture<IntegrationTestWebAppFactory>
{
    public BaseIntegrationTests(IntegrationTestWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
    }

    protected HttpClient HttpClient { get; init; }
}
