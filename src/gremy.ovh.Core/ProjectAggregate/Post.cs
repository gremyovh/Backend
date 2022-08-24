using gremy.ovh.SharedKernel;
using gremy.ovh.SharedKernel.Interfaces;

namespace gremy.ovh.Core.ProjectAggregate;
public class Post : EntityBase, IAggregateRoot
{
  public string Title { get; set; }
  public string Body { get; set; }
  public DateTime CreationDate { get; }
  public ICollection<Comment> Comments { get; set; }
  public ICollection<ContentData> Data { get; set; }

  public Post(string title, string body)
  {
    Title = title;
    Body = body;
    Comments = Array.Empty<Comment>();
    Data = Array.Empty<ContentData>();
  }
  public Post() : this(string.Empty, string.Empty)
  {
  }
}
