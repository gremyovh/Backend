using System.Net;
using System.Text;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.CommentEndpoints;
using Newtonsoft.Json;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.CommentEndpoints;

[Collection("Sequential")]
public class CommentUpdate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public CommentUpdate(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnBadRequestUpdate()
  {
    var comment = new Comment("Test rename title", string.Empty, 1);
    var response = await _client.PutAndEnsureBadRequestAsync(
      UpdateCommentRequest.Route,
      new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json"));

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }

  [Fact]
  public async Task ReturnNotFoundUpdate()
  {
    var comment = new Comment("Test rename title", "Test rename body", 1)
    {
      Id = 0,
    };
    var response = await _client.PutAndEnsureNotFoundAsync(
      UpdateCommentRequest.Route,
      new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json"));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task ReturnOkUpdate()
  {
    var comment = new Comment("Test rename title", "Test rename body", SeedData.TestPost1.Id)
    {
      Id = SeedData.TestComment1.Id,
    };
    var response = await _client.PutAndDeserializeAsync<UpdateCommentResponse>(
      UpdateCommentRequest.Route,
      new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json"));

    Assert.Equal(response.Comment.Id, comment.Id);
    Assert.Equal(response.Comment.Title, comment.Title);
    Assert.Equal(response.Comment.Body, comment.Body);
    Assert.Equal(response.Comment.PostId, comment.PostId);
  }
}
