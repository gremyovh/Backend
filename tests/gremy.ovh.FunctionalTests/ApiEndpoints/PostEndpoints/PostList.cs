using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.PostEndpoints;

[Collection("Sequential")]
public class PostList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PostList(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnOnePost()
  {
    var result = await _client.GetAndDeserializeAsync<ListPostResponse>(ListPostRequest.Route);

    Assert.Contains(result.Posts, i => i.Id == SeedData.TestPost1.Id);
    Assert.Contains(result.Posts, i => i.Title == SeedData.TestPost1.Title);
    Assert.Contains(result.Posts, i => i.Body == SeedData.TestPost1.Body);
  }
}
