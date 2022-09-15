using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using gremy.ovh.Web.Endpoints.PostEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public class GetById : EndpointBaseAsync
  .WithRequest<GetByIdCommentRequest>
  .WithActionResult<GetByIdCommentResponse>
{
  private readonly IRepository<Comment> _repository;

  public GetById(IRepository<Comment> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetByIdCommentRequest.Route)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Gets one Comment",
    Description = "Gets one Comment",
    OperationId = "Comment.GetById",
    Tags = new[] { "CommentEndpoints" })
  ]
  public override async Task<ActionResult<GetByIdCommentResponse>> HandleAsync(
    [FromRoute] GetByIdCommentRequest request,
    CancellationToken cancellationToken = new())
  {
    var entity = await _repository.GetByIdAsync(request.CommentId, cancellationToken);
    if (entity is null) return NotFound();

    var response = new GetByIdCommentResponse
    {
      Comment = new CommentRecord
      (
        entity.Id,
        entity.Title,
        entity.Body,
        entity.CreationDate,
        entity.PostId
      ),
    };

    return Ok(response);
  }
}
