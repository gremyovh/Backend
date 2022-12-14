using System.Net;
using System.Text;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;
using Newtonsoft.Json;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.PostEndpoints;

[Collection("Sequential")]
public class PostUpdate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PostUpdate(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnBadRequestUpdate()
  {
    var post = new Post("Test rename title", string.Empty);
    var response = await _client.PutAndEnsureBadRequestAsync(
      UpdatePostRequest.Route,
      new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }

  [Fact]
  public async Task ReturnNotFoundUpdate()
  {
    var post = new Post("Test rename title", "Test rename body")
    {
      Id = 0,
    };
    var response = await _client.PutAndEnsureNotFoundAsync(
      UpdatePostRequest.Route,
      new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task ReturnOkUpdate()
  {
    var post = new Post("Test rename title", "Test rename body")
    {
      Id = SeedData.TestPost1.Id,
    };
    var response = await _client.PutAndDeserializeAsync<UpdatePostResponse>(
      UpdatePostRequest.Route,
      new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));

    Assert.Equal(response.Post.Id, post.Id);
    Assert.Equal(response.Post.Title, post.Title);
    Assert.Equal(response.Post.Body, post.Body);
  }
}
