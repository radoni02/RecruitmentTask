using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Stack.Application;
using Stack.Application.Dtos;
using Stack.Application.Exceptions;
using Stack.Application.Tags.CountPercentage;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Tags;

public class CountPercentageQueryTests
{
    private static readonly CountPercentageQuery Query = new();
    private readonly CountPercentageQueryHandler _handler;
    private readonly ITagRepository _tagRepositoryMock;
    private readonly IPercentageCounter _percentageCounterMock;
    private readonly ILogger<CountPercentageQueryHandler> _loggerMock;

    public CountPercentageQueryTests()
    {
        _tagRepositoryMock = Substitute.For<ITagRepository>();
        _percentageCounterMock = Substitute.For<IPercentageCounter>();
        _loggerMock = Substitute.For<ILogger<CountPercentageQueryHandler>>();
        _handler = new CountPercentageQueryHandler(_percentageCounterMock, _tagRepositoryMock, _loggerMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenTagsAreNull()
    {
         _tagRepositoryMock.GetAllTagsAsIEnumerable().Returns(Task.FromResult<IEnumerable<Tag>>(null));

        await Assert.ThrowsAsync<NotFoundException>(() => _handler.HandleAsync(new CountPercentageQuery()));
    }

    [Fact]
    public async Task Handle_Should_Return_TagPercentageDtos()
    {
        // Arrange
        var tags = new List<Tag>
        {
            new Tag { Name = "Tag1", Count = 10 },
            new Tag { Name = "Tag2", Count = 20 }
        };

        var percentages = new List<float> { 50.0f, 50.0f };

        _tagRepositoryMock.GetAllTagsAsIEnumerable().Returns(Task.FromResult<IEnumerable<Tag>>(tags));
        _percentageCounterMock.CountPercentageFromData(Arg.Any<List<int>>()).Returns(percentages);

        // Act
        var result = await _handler.HandleAsync(new CountPercentageQuery());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(tags.Count, result.Count());
        foreach (var (tag, percentage) in tags.Zip(percentages, (t, p) => (t, p)))
        {
            Assert.Contains(result, dto => dto.Name == tag.Name && dto.Count == tag.Count && dto.Percentage == percentage);
        }
    }
}
