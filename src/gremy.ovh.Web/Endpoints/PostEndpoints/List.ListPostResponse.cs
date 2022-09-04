#nullable disable

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class ListPostResponse
{
  public ICollection<PostRecord> Posts { get; set; }
}
