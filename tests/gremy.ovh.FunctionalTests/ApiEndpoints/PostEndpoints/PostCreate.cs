using System.Text;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints;
using Newtonsoft.Json;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.PostEndpoints;

[Collection("Sequential")]
public class PostCreate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PostCreate(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnBadRequestCreate()
  {
    var post = new Post("Test project title", string.Empty);
    _ = await _client.PostAndEnsureBadRequestAsync(
      CreatePostRequest.Route,
      new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));
  }

  [Fact]
  public async Task ReturnCreatedCreate()
  {
    var post = new Post("Test project title", "Test project body");
    var response = await _client.PostAndDeserializeAsync<CreatePostResponse>(
      CreatePostRequest.Route,
      new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));

    Assert.Equal(response.Post.Title, post.Title);
    Assert.Equal(response.Post.Body, post.Body);
  }
}
