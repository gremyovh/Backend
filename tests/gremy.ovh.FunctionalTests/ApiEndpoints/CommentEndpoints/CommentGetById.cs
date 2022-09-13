using System.Net;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.CommentEndpoints;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.CommentEndpoints;

[Collection("Sequential")]
public class CommentGetById : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public CommentGetById(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnNotFoundGetById()
  {
    var response = await _client.GetAndEnsureNotFoundAsync(GetByIdCommentRequest.BuildRoute(0));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task ReturnOkGetById()
  {
    var result = await _client.GetAndDeserializeAsync<GetByIdCommentResponse>(GetByIdCommentRequest.BuildRoute(SeedData.TestComment1.Id));

    Assert.Equal(1, result.Comment.Id);
    Assert.Equal(SeedData.TestComment1.Title, result.Comment.Title);
    Assert.Equal(SeedData.TestComment1.Body, result.Comment.Body);
    Assert.Equal(SeedData.TestComment1.PostId, result.Comment.PostId);
  }
}
