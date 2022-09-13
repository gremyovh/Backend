using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.CommentEndpoints;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.CommentEndpoints;

[Collection("Sequential")]
public class CommentList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public CommentList(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnOnePost()
  {
    var result = await _client.GetAndDeserializeAsync<ListCommentResponse>(ListCommentRequest.Route);

    Assert.Contains(result.Comments, i => i.Id == SeedData.TestComment1.Id);
    Assert.Contains(result.Comments, i => i.Title == SeedData.TestComment1.Title);
    Assert.Contains(result.Comments, i => i.Body == SeedData.TestComment1.Body);
    Assert.Contains(result.Comments, i => i.PostId == SeedData.TestComment1.PostId);
  }
}
