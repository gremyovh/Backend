using gremy.ovh.Core.ProjectAggregate;
using Xunit;

namespace gremy.ovh.UnitTests.Core.ProjectAggregate;
public class PostConstructor
{
  private  readonly string _testTitle = "Test title";
  private readonly string _testBody = "Test body";
  private Post? _testPost;

  private Post CreatePost()
  {
    return new Post(_testTitle, _testBody);
  }

  [Fact]
  public void InitializesTitle()
  {
    _testPost = CreatePost();

    Assert.Equal(_testTitle, _testPost.Title);
  }

  [Fact]
  public void InitializesBody()
  {
    _testPost = CreatePost();

    Assert.Equal(_testBody, _testPost.Body);
  }
}
