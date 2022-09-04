#nullable disable

using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class CreatePostRequest
{
  public const string Route = "/Posts";

  [Required(AllowEmptyStrings = false)] public string Title { get; set; }
  [Required(AllowEmptyStrings = false)] public string Body { get; set; }
}
