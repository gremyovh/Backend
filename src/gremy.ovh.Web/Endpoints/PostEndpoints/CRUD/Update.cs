using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public class Update : EndpointBaseAsync
  .WithRequest<UpdatePostRequest>
  .WithActionResult<UpdatePostResponse>
{
  private readonly IRepository<Post> _repository;

  public Update(IRepository<Post> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdatePostRequest.Route)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Update a Post",
    Description = "Update a Post",
    OperationId = "Post.Update",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<UpdatePostResponse>> HandleAsync(
    UpdatePostRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request is null) return BadRequest();

    var existingPost = await _repository.GetByIdAsync(request.PostId, cancellationToken);
    if (existingPost is null) return NotFound();

    existingPost.Update(request.Title, request.Body);

    await _repository.UpdateAsync(existingPost, cancellationToken);

    var response = new UpdatePostResponse
    {
      Post = new PostRecord
      (
        existingPost.Id,
        existingPost.Title,
        existingPost.Body
      )
    };

    return Ok(response);
  }
}
