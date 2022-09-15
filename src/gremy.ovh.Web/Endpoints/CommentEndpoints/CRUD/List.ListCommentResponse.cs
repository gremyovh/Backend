#nullable disable

using gremy;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public class ListCommentResponse
{
  public ICollection<CommentRecord> Comments { get; set; }
}
