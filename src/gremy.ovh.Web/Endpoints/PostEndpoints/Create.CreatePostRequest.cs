using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class CreatePostRequest
{
  public const string Route = "/Posts";

  [Required] public string Title { get; set; }
  [Required] public string Body { get; set; }

  public CreatePostRequest()
  {
    Title = string.Empty;
    Body = string.Empty;
  }
}
