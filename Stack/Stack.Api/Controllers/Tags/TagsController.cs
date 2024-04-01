using Microsoft.AspNetCore.Mvc;
using Stack.Application.Abstractions;
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
    public async Task<PagedResult<TagDto>> GetAllTags(int page,int pageSize,CancellationToken cancellationToken)
    {
        var query = new GetAllTagsQuery(page,pageSize);
        var tags = await _queryDispatcher.QueryAsync<GetAllTagsQuery,PagedResult<TagDto>>(query,cancellationToken);
        return tags;
    }
}
