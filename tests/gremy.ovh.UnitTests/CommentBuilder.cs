using gremy.ovh.Core.ProjectAggregate;

namespace gremy.ovh.UnitTests;
public class CommentItemBuilder
{
  private Comment _comment = new();

  public CommentItemBuilder Id(int id)
  {
    _comment.Id = id;
    return this;
  }

  public CommentItemBuilder Title(string title)
  {
    _comment.Title = title;
    return this;
  }

  public CommentItemBuilder Body(string body)
  {
    this._comment.Body = body;
    return this;
  }

  public CommentItemBuilder WithDefaultValues()
  {
    _comment = new() { Id = 1, Title = "Test title", Body = "Test body" };
    return this;
  }

  public Comment Build() => _comment;
}
