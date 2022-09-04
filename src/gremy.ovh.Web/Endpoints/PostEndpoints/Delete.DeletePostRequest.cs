using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class DeletePostRequest
{
  public const string Route = "/Posts/{PostId:int}";

  [Required] public int PostId { get; set; }
}
