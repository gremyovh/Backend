using System.Net.Mime;
using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public class Delete : EndpointBaseAsync
  .WithRequest<DeleteCommentRequest>
  .WithoutResult
{
  private readonly IRepository<Comment> _repository;

  public Delete(IRepository<Comment> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteCommentRequest.Route)]
  [Produces(MediaTypeNames.Application.Json)]
  [Consumes(MediaTypeNames.Application.Json)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [SwaggerOperation(
    Summary = "Delete a Comment",
    Description = "Delete a Comment",
    OperationId = "Comment.Delete",
    Tags = new[] { "Comment" })
  ]
  public override async Task<ActionResult> HandleAsync(
    [FromRoute] DeleteCommentRequest request,
    CancellationToken cancellationToken = new())
  {
    var commentToDelete = await _repository.GetByIdAsync(request.CommentId, cancellationToken);
    if (commentToDelete is null) return NotFound();

    await _repository.DeleteAsync(commentToDelete, cancellationToken);

    return NoContent();
  }
}
