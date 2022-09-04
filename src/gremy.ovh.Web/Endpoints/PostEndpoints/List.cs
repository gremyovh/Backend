﻿using Ardalis.ApiEndpoints;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<ListPostResponse>
{
  private readonly IReadRepository<Post> _repository;

  public List(IReadRepository<Post> repository)
  {
    _repository = repository;
  }

  [HttpGet(ListPostRequest.Route)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [SwaggerOperation(
    Summary = "Gets a list of all Posts",
      Description = "Gets a list of all Posts",
      OperationId = "Post.List",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<ListPostResponse>> HandleAsync(
    CancellationToken cancellationToken = new())
  {
    var posts = await _repository.ListAsync(cancellationToken);

    var response = new ListPostResponse
    {
      Posts = posts
      .Select(post => new PostRecord(post.Id, post.Title, post.Body))
      .ToList()
    };

    return Ok(response);
  }
}
