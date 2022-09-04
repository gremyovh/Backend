using Ardalis.HttpClientTestExtensions;
using gremy.ovh.Web;
using gremy.ovh.Web.Endpoints.PostEndpoints;
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
    _ = await _client.DeleteAndEnsureNotFoundAsync(DeletePostRequest.BuildRoute(0));
  }

  [Fact]
  public async Task ReturnDeletedDelete()
  {
    _ = await _client.DeleteAndEnsureNoContentAsync(DeletePostRequest.BuildRoute(SeedData.TestPost2.Id));
  }
}
