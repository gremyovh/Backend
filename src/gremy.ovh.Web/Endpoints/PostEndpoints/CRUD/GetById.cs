using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public class GetById : EndpointBaseAsync
  .WithRequest<GetByIdPostRequest>
  .WithActionResult<GetByIdPostResponse>
{
  private readonly IRepository<Post> _repository;

  public GetById(IRepository<Post> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetByIdPostRequest.Route)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Gets one post",
      Description = "Gets one post",
      OperationId = "Post.Get",
      Tags = new[] { "Project" })
  ]
  public override async Task<ActionResult<GetByIdPostResponse>> HandleAsync(
    [FromRoute] GetByIdPostRequest request,
    CancellationToken cancellationToken = new())
  {
    var entity = await _repository.GetByIdAsync(request.PostId, cancellationToken);
    if (entity is null) return NotFound();

    var response = new GetByIdPostResponse
    {
      Post = new PostRecord
      (
        entity.Id,
        entity.Title,
        entity.Body
      ),
    };

    return Ok(response);
  }
}
