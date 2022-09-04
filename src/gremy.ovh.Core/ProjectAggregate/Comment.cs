using gremy.ovh.SharedKernel;
using Newtonsoft.Json;

namespace gremy.ovh.Core.ProjectAggregate;
public class Comment : EntityBase
{
  [JsonProperty(PropertyName = "CommentId")]
  public override int Id { get; set; }
  public DateTime CreationDate { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public Post Post { get; set; }

  public Comment(string title, string body)
  {
    Title = title;
    Body = body;
    Post = new Post();
  }
  public Comment() : this(string.Empty, string.Empty)
  {
  }
}
