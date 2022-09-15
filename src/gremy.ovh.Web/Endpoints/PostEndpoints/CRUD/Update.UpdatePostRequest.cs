#nullable disable

using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public class UpdatePostRequest
{
  public const string Route = "/Posts";

  [Required] public int PostId { get; set; }
  [Required(AllowEmptyStrings = false)] public string Title { get; set; }
  [Required(AllowEmptyStrings = false)] public string Body { get; set; }
}
