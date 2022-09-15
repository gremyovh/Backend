#nullable disable

using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public class UpdateCommentRequest
{
  public const string Route = "/Comments";

  [Required] public int CommentId { get; set; }
  [Required(AllowEmptyStrings = false)] public string Title { get; set; }
  [Required(AllowEmptyStrings = false)] public string Body { get; set; }
  [Required] public int PostId { get; set; }
}
