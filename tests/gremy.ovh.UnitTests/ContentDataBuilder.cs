using gremy.ovh.Core.ProjectAggregate;

namespace gremy.ovh.UnitTests;
public class ContentDataItemBuilder
{
  private ContentData _contentData = new();

  public ContentDataItemBuilder Id(int id)
  {
    _contentData.Id = id;
    return this;
  }

  public ContentDataItemBuilder FileName(string fileName)
  {
    _contentData.FileName = fileName;
    return this;
  }

  public ContentDataItemBuilder WithDefaultValues()
  {
    _contentData = new() { Id = 1, FileName = "filename.extension" };
    return this;
  }

  public ContentData Build() => _contentData;
}
