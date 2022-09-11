﻿using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<ListCommentResponse>
{
  private readonly IReadRepository<Comment> _repository;

  public List(IReadRepository<Comment> repository)
  {
    _repository = repository;
  }

  [HttpGet(ListCommentRequest.Route)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Gets a list of all Comments",
      Description = "Gets a list of all Comments",
      OperationId = "Comment.List",
      Tags = new[] { "CommentEndpoints" })
  ]
  public override async Task<ActionResult<ListCommentResponse>> HandleAsync(
    CancellationToken cancellationToken = new())
  {
    var comments = await _repository.ListAsync(cancellationToken);

    var response = new ListCommentResponse
    {
      Comments = comments
      .Select(comment => new CommentRecord(comment.Id, comment.Title, comment.Body, comment.CreationDate, comment.PostId))
      .ToList()
    };

    return Ok(response);
  }
}
