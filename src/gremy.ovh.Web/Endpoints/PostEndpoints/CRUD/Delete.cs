using System.Net.Mime;
using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public class Delete : EndpointBaseAsync
  .WithRequest<DeletePostRequest>
  .WithoutResult
{
  private readonly IRepository<Post> _repository;

  public Delete(IRepository<Post> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeletePostRequest.Route)]
  [Produces(MediaTypeNames.Application.Json)]
  [Consumes(MediaTypeNames.Application.Json)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [SwaggerOperation(
    Summary = "Delete a Post",
    Description = "Delete a Post",
    OperationId = "Post.Delete",
    Tags = new[] { "Project" })
  ]
  public override async Task<ActionResult> HandleAsync(
    [FromRoute] DeletePostRequest request,
    CancellationToken cancellationToken = new())
  {
    var postToDelete = await _repository.GetByIdAsync(request.PostId, cancellationToken);
    if (postToDelete is null) return NotFound();

    await _repository.DeleteAsync(postToDelete, cancellationToken);

    return NoContent();
  }
}
