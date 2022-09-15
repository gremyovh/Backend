using System.Net;
using System.Text;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;
using Newtonsoft.Json;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.CommentEndpoints;

[Collection("Sequential")]
public class CommentCreate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public CommentCreate(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnBadRequestCreate()
  {
    var comment = new Comment("Test comment title", string.Empty, 0);
    var response = await _client.PostAndEnsureBadRequestAsync(
      CreateCommentRequest.Route,
      new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json"));

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }

  [Fact]
  public async Task ReturnCreatedCreate()
  {
    var comment = new Comment("Test comment title", "Test comment body", SeedData.TestPost1.Id);
    var response = await _client.PostAndDeserializeAsync<CreateCommentResponse>(
      CreateCommentRequest.Route,
      new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json"));

    Assert.Equal(response.Comment.Title, comment.Title);
    Assert.Equal(response.Comment.Body, comment.Body);
    Assert.Equal(response.Comment.PostId, comment.PostId);
  }
}
