#nullable disable

using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class UpdatePostRequest
{
  public const string Route = "/Posts";

  [Required] public int PostId { get; set; }
  [Required] public string Title { get; set; }
  [Required] public string Body { get; set; }
}
