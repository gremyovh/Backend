using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using gremy.ovh.Web.Endpoints.PostEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateCommentRequest>
  .WithActionResult<UpdateCommentResponse>
{
  private readonly IRepository<Comment> _repository;
  private readonly IRepository<Post> _postRepository;

  public Update(IRepository<Comment> repository, IRepository<Post> postRepository)
  {
    _repository = repository;
    _postRepository = postRepository;
  }

  [HttpPut(UpdateCommentRequest.Route)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Update a Comment",
    Description = "Update a Comment",
    OperationId = "Comment.Update",
    Tags = new[] { "CommentEndpoints" })
  ]
  public override async Task<ActionResult<UpdateCommentResponse>> HandleAsync(
    UpdateCommentRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request is null) return BadRequest();

    if (_postRepository.GetByIdAsync(request.PostId, cancellationToken) is null) return BadRequest();

    var existingComment = await _repository.GetByIdAsync(request.CommentId, cancellationToken);
    if (existingComment is null) return NotFound();

    existingComment.Update(request.Title, request.Body, request.PostId);

    await _repository.UpdateAsync(existingComment, cancellationToken);

    var response = new UpdateCommentResponse
    {
      Comment = new CommentRecord
      (
        existingComment.Id,
        existingComment.Title,
        existingComment.Body,
        existingComment.CreationDate,
        existingComment.PostId
      ),
    };

    return Ok(response);
  }
}
