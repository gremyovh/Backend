#nullable disable

using gremy;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public class ListPostResponse
{
  public ICollection<PostRecord> Posts { get; set; }
}
