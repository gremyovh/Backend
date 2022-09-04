using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.PostEndpoints;

[Collection("Sequential")]
public class PostGetById : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PostGetById(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnNotFoundGetById()
  {
    _ = await _client.GetAndEnsureNotFoundAsync(GetByIdPostRequest.BuildRoute(0));
  }

  [Fact]
  public async Task ReturnOkGetById()
  {
    var result = await _client.GetAndDeserializeAsync<GetByIdPostResponse>(GetByIdPostRequest.BuildRoute(1));

    Assert.Equal(1, result.Post.Id);
    Assert.Equal(SeedData.TestPost1.Title, result.Post.Title);
    Assert.Equal(SeedData.TestPost1.Body, result.Post.Body);
  }
}
