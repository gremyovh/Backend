using gremy.ovh.Core.ProjectAggregate;
using Xunit;

namespace gremy.ovh.UnitTests.Core.ProjectAggregate;
public class CommentConstructor
{
  private readonly string _testTitle = "Test title";
  private readonly string _testBody = "Test body";
  private Comment? _testComment;

  private Comment CreateComment()
  {
    return new Comment(_testTitle, _testBody);
  }

  [Fact]
  public void InitializeTitle()
  {
    _testComment = CreateComment();

    Assert.Equal(_testTitle, _testComment.Title);
  }

  [Fact]
  public void InitializeBody()
  {
    _testComment = CreateComment();

    Assert.Equal(_testBody, _testComment.Body);
  }
}
