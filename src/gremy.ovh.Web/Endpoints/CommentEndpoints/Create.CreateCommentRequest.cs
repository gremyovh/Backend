#nullable disable

using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints;

public class CreateCommentRequest
{
  public const string Route = "/Comments";

  [Required(AllowEmptyStrings = false)] public string Title { get; set; }
  [Required(AllowEmptyStrings = false)] public string Body { get; set; }
  [Required] public int PostId { get; set; }
}
