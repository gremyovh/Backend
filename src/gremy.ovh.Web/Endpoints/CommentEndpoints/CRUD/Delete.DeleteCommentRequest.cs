using System.ComponentModel.DataAnnotations;

namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public class DeleteCommentRequest
{
  public const string Route = "/Comments/{CommentId:int}";
  public static string BuildRoute(int commentId) => Route.Replace("{CommentId:int}", commentId.ToString());

  [Required] public int CommentId { get; set; }
}
