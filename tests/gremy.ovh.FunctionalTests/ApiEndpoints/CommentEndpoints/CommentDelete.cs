using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using System.Net;
using Xunit;
using gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.CommentEndpoints;

[Collection("Sequential")]
public class CommentDelete : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public CommentDelete(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnNotFoundDelete()
  {
    var response = await _client.DeleteAndEnsureNotFoundAsync(DeleteCommentRequest.BuildRoute(0));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task ReturnDeletedDelete()
  {
    var response = await _client.DeleteAndEnsureNoContentAsync(DeleteCommentRequest.BuildRoute(SeedData.TestComment2.Id));

    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
  }
}
