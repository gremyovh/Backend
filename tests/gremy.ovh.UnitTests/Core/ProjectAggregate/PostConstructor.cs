using gremy.ovh.Core.ProjectAggregate;
using Xunit;

namespace gremy.ovh.UnitTests.Core.ProjectAggregate;
public class PostConstructor
{
  private string _testTitle = "Test title";
  private string _testBody = "Test body";
  private Post? _testPost;

  private Post CreateProject()
  {
    return new Post(_testTitle, _testBody);
  }

  [Fact]
  public void InitializesTitle()
  {
    _testPost = CreateProject();

    Assert.Equal(_testTitle, _testPost.Title);
  }

  [Fact]
  public void InitializesBody()
  {
    _testPost = CreateProject();

    Assert.Equal(_testBody, _testPost.Body);
  }
}
