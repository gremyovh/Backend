using gremy.ovh.SharedKernel;

namespace gremy.ovh.Core.ProjectAggregate;
public class ContentData : EntityBase
{
  public string FileName { get; set; }
  public Post Post { get; set; }

  public ContentData(string fileName)
  {
    FileName = fileName;
    Post = new Post();
  }
  public ContentData() : this(string.Empty)
  {
  }
}
