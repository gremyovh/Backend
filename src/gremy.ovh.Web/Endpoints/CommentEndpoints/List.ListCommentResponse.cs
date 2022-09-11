#nullable disable

namespace gremy.ovh.Web.Endpoints.CommentEndpoints;

public class ListCommentResponse
{
  public ICollection<CommentRecord> Comments { get; set; }
}
