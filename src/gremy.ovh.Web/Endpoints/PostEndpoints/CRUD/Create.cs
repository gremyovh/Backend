using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public class Create : EndpointBaseAsync
  .WithRequest<CreatePostRequest>
  .WithActionResult<CreatePostResponse>
{
  private readonly IRepository<Post> _repository;

  public Create(IRepository<Post> repository)
  {
    _repository = repository;
  }

  [HttpPost(CreatePostRequest.Route)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [SwaggerOperation(
    Summary = "Creates a new Post",
    Description = "Creates a new Post",
    OperationId = "Post.Create",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<CreatePostResponse>> HandleAsync(
    CreatePostRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request is null) return BadRequest();

    var newPost = new Post(request.Title, request.Body);
    var createdItem = await _repository.AddAsync(newPost, cancellationToken);

    var response = new CreatePostResponse
    {
      Post = new PostRecord
      (
        createdItem.Id,
        createdItem.Title,
        createdItem.Body
      ),
    };

    return Created(CreatePostRequest.Route, response);
  }
}
