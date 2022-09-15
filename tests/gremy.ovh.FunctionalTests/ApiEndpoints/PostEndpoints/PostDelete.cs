using System.Net;
using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;
using Xunit;

namespace gremy.ovh.FunctionalTests.ApiEndpoints.PostEndpoints;

[Collection("Sequential")]
public class PostDelete : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PostDelete(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnNotFoundDelete()
  {
    var response = await _client.DeleteAndEnsureNotFoundAsync(DeletePostRequest.BuildRoute(0));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task ReturnDeletedDelete()
  {
    var response = await _client.DeleteAndEnsureNoContentAsync(DeletePostRequest.BuildRoute(SeedData.TestPost2.Id));

    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
  }
}
