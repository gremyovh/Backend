using Ardalis.GuardClauses;
using gremy.ovh.SharedKernel;
using gremy.ovh.SharedKernel.Interfaces;
using Newtonsoft.Json;

namespace gremy.ovh.Core.ProjectAggregate;
public class Comment : EntityBase, IAggregateRoot
{
  [JsonProperty(PropertyName = "CommentId")]
  public override int Id { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public DateTime CreationDate { get; }
  public Post Post { get; set; }
  public int PostId { get; set; }

  public void Update(
    string? title,
    string? body,
    int postId)
  {
    Title = Guard.Against.NullOrEmpty(title);
    Body = Guard.Against.NullOrEmpty(body);
    PostId = Guard.Against.NegativeOrZero(postId);
  }

  public Comment(string title, string body, int postId)
  {
    Title = title;
    Body = body;
    PostId = postId;
    Post = new Post();
  }
  public Comment() : this(string.Empty, string.Empty, -1)
  {
  }
}
