using Ardalis.GuardClauses;
using gremy.ovh.SharedKernel;
using gremy.ovh.SharedKernel.Interfaces;
using Newtonsoft.Json;

namespace gremy.ovh.Core.ProjectAggregate;
public class Post : EntityBase, IAggregateRoot
{
  [JsonProperty(PropertyName = "PostId")]
  public override int Id { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public DateTime CreationDate { get; }
  public ICollection<Comment> Comments { get; set; }
  public ICollection<ContentData> Data { get; set; }

  public void Update(
    string? title,
    string? body)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Body = Guard.Against.NullOrEmpty(body, nameof(body));
  }

  public Post(string title, string body)
  {
    Title = title;
    Body = body;
    Comments = new List<Comment>();
    Data = new List<ContentData>();
  }
  public Post()
    : this(string.Empty, string.Empty)
  {
  }
}
