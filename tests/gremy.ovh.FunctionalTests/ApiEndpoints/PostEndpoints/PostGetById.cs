using System.Net;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;
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
    var response = await _client.GetAndEnsureNotFoundAsync(GetByIdPostRequest.BuildRoute(0));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task ReturnOkGetById()
  {
    var result = await _client.GetAndDeserializeAsync<GetByIdPostResponse>(GetByIdPostRequest.BuildRoute(SeedData.TestPost1.Id));

    Assert.Equal(1, result.Post.Id);
    Assert.Equal(SeedData.TestPost1.Title, result.Post.Title);
    Assert.Equal(SeedData.TestPost1.Body, result.Post.Body);
  }
}
