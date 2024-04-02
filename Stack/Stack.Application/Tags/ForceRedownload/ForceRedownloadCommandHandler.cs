using Microsoft.Extensions.Logging;
using Stack.Application.Abstractions.Commands;
using Stack.Application.Extensions;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Tags.ForceRedownload;

public sealed class ForceRedownloadCommandHandler : ICommandHandler<ForceRedownloadCommand>
{
    private readonly ITagRepository _tagRepository;
    private readonly SeedDataIfNeeded _seedDataIfNeeded;
    private readonly ILogger<ForceRedownloadCommandHandler> _logger;

    public ForceRedownloadCommandHandler(ITagRepository tagRepository, SeedDataIfNeeded seedDataIfNeeded,ILogger<ForceRedownloadCommandHandler> logger)
    {
        _tagRepository = tagRepository;
        _seedDataIfNeeded = seedDataIfNeeded;
        _logger = logger;
    }

    public async Task HandleAsync(ForceRedownloadCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start processing {nameof(ForceRedownloadCommand)}");
        if(!await _tagRepository.DeleteAllTags())
        {
            _logger.LogError("Unable to processed.");
            throw new Exception("Unable to delete data from database.");
        }
        _logger.LogInformation("Successfully deleted.");
        await _seedDataIfNeeded.SeedData<Tag>();

        //delete cache key
    }
}
