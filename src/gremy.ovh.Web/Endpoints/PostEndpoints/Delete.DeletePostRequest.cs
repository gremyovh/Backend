using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class DeletePostRequest
{
  public const string Route = "/Posts/{PostId:int}";
  public static string BuildRoute(int projectId) => Route.Replace("{PostId:int}", projectId.ToString());

  [Required] public int PostId { get; set; }
}
