using Microsoft.Extensions.Logging;
using Moq;
using Stack.Application.Extensions;
using Stack.Application.SeedData;
using Stack.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Stack.Domain.Model;
using Stack.Application.Exceptions;

namespace Application.UnitTests.Tags;

public class SeedDataIfNeededTests
{
    private readonly IUnPack _unPackMock;
    private readonly ITagRepository _tagRepositoryMock;
    private readonly ILogger<SeedDataIfNeeded> _loggerMock;
    private readonly SeedDataIfNeeded _seedData;

    public SeedDataIfNeededTests()
    {
        _tagRepositoryMock = Substitute.For<ITagRepository>();
        _loggerMock = Substitute.For<ILogger<SeedDataIfNeeded>>();
        _unPackMock = Substitute.For<IUnPack>();

        _seedData = new SeedDataIfNeeded(null, _unPackMock, _tagRepositoryMock, _loggerMock);

    }

    [Fact]
    public async Task Tags_DatabaseAlreadyPopulated_LogsInformation()
    {

        _tagRepositoryMock.AnyAsync().Returns(true);
        await _seedData.Tags();

        _loggerMock.Received(1).LogInformation("Database already populated.");
    }

    [Fact]
    public async Task UnPackObjects_ReturnsNull_LogsError()
    {
        _unPackMock.UnPackObjects().Returns((List<Tag>)null);

        await Assert.ThrowsAsync<BadConfigurationException>(async () => await _seedData.SeedData());

        _loggerMock.Received(1).LogError("Bad stack Exchange configuration.");
    }

}
