using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using gremy.ovh.Core.ProjectAggregate.Specifications.PostSpec;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class GetById : EndpointBaseAsync
  .WithRequest<GetPostByIdRequest>
  .WithActionResult<GetPostByIdResponse>
{
  private readonly IRepository<Post> _repository;

  public GetById(IRepository<Post> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetPostByIdRequest.Route)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Gets one post",
      Description = "Gets one post",
      OperationId = "Post.Get",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<GetPostByIdResponse>> HandleAsync(
    [FromRoute] GetPostByIdRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request is null) return BadRequest();

    var spec = new PostByIdSpec(request.PostId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity is null) return NotFound();

    var response = new GetPostByIdResponse
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
