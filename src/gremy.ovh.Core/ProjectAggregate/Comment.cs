using Ardalis.GuardClauses;
using gremy.ovh.SharedKernel;
using Newtonsoft.Json;

namespace gremy.ovh.Core.ProjectAggregate;
public class Comment : EntityBase
{
  [JsonProperty(PropertyName = "CommentId")]
  public override int Id { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public DateTime CreationDate { get; }
  public Post Post { get; set; }

  public void Update(
    string? title,
    string? body)
  {
    Title = Guard.Against.NullOrEmpty(title);
    Body = Guard.Against.NullOrEmpty(body);
  }

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
