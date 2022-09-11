using gremy.ovh.Core.ProjectAggregate;
using Xunit;

namespace gremy.ovh.UnitTests.Core.ProjectAggregate;
public class ContentDataConstructor
{
  private readonly string _testFileName = "filename.extension";
  private readonly int _testPostId = 1;
  private ContentData? _testContentData;

  private ContentData CreateContentData()
  {
    return new ContentData(_testFileName, _testPostId);
  }

  [Fact]
  public void InitializeFileName()
  {
    _testContentData = CreateContentData();

    Assert.Equal(_testFileName, _testContentData.FileName);
  }
}
