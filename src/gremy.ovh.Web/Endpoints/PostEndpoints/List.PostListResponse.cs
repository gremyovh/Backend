#nullable disable

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class PostListResponse
{
  public ICollection<PostRecord> Posts { get; set; }
}
