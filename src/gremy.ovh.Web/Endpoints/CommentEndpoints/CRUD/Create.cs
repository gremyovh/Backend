using System.Net.Mime;
using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public class Create : EndpointBaseAsync
  .WithRequest<CreateCommentRequest>
  .WithActionResult<CreateCommentResponse>
{
  private readonly IRepository<Comment> _repository;
  private readonly IRepository<Post> _postRepository;

  public Create(IRepository<Comment> repository, IRepository<Post> postRepository)
  {
    _repository = repository;
    _postRepository = postRepository;
  }

  [HttpPost(CreateCommentRequest.Route)]
  [Produces(MediaTypeNames.Application.Json)]
  [Consumes(MediaTypeNames.Application.Json)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [SwaggerOperation(
    Summary = "Creates a new Comment",
    Description = "Create a new Comment",
    OperationId = "Comment.Create",
    Tags = new[] { "Comment" })]
  public override async Task<ActionResult<CreateCommentResponse>> HandleAsync(
    CreateCommentRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request is null) return BadRequest();

    if (_postRepository.GetByIdAsync(request.PostId, cancellationToken) is null) return BadRequest();

    var newComment = new Comment(request.Title, request.Body, request.PostId);
    var createdItem = await _repository.AddAsync(newComment, cancellationToken);

    var response = new CreateCommentResponse
    {
      Comment = new CommentRecord
      (
        createdItem.Id,
        createdItem.Title,
        createdItem.Body,
        createdItem.CreationDate,
        createdItem.PostId
      ),
    };

    return Created(CreateCommentRequest.Route, response);
  }
}
