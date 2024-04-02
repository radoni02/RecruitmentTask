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

    public ForceRedownloadCommandHandler(ITagRepository tagRepository, SeedDataIfNeeded seedDataIfNeeded)
    {
        _tagRepository = tagRepository;
        _seedDataIfNeeded = seedDataIfNeeded;
    }

    public async Task HandleAsync(ForceRedownloadCommand command, CancellationToken cancellationToken)
    {
        if(!await _tagRepository.DeleteAllTags())
        {
            //throw error
        }
        await _seedDataIfNeeded.SeedData<Tag>();

        //delete cache key
    }
}
