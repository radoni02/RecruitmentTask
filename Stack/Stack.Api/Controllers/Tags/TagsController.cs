using Microsoft.AspNetCore.Mvc;
using Stack.Application.Abstractions.Queries;
using Stack.Application.Dtos;
using Stack.Application.Tags.Get;
using Stack.Domain.Model;

namespace Stack.Api.Controllers.Tags;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public TagsController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IReadOnlyList<TagDto>> GetAllTags(CancellationToken cancellationToken)
    {
        var query = new GetAllTagsQuery();
        var tags = await _queryDispatcher.QueryAsync<GetAllTagsQuery,IReadOnlyList<TagDto>>(query,cancellationToken);
        return tags;
    }
}
