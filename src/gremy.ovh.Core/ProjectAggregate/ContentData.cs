using Ardalis.GuardClauses;
using gremy.ovh.SharedKernel;
using gremy.ovh.SharedKernel.Interfaces;
using Newtonsoft.Json;

namespace gremy.ovh.Core.ProjectAggregate;
public class ContentData : EntityBase, IAggregateRoot
{
  [JsonProperty(PropertyName = "ContentDataId")]
  public override int Id { get; set; }
  public string FileName { get; set; }
  public Post Post { get; set; }
  public int PostId { get; set; }

  public void Update(
    string? fileName)
  {
    FileName = Guard.Against.NullOrEmpty(fileName);
  }

  public ContentData(string fileName, int postId)
  {
    FileName = fileName;
    PostId = postId;
    Post = new Post();
  }
  public ContentData() : this(string.Empty, -1)
  {
  }
}
