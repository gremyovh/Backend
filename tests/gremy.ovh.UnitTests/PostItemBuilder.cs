using gremy.ovh.Core.ProjectAggregate;

namespace gremy.ovh.UnitTests;
public class PostItemBuilder
{
  private Post _post = new();

  public PostItemBuilder Id(int id)
  {
    _post.Id = id;
    return this;
  }

  public PostItemBuilder Title(string title)
  {
    _post.Title = title;
    return this;
  }

  public PostItemBuilder Body(string body)
  {
    _post.Body = body;
    return this;
  }

  public PostItemBuilder WithDefaultValues()
  {
    _post = new() { Id = 1, Title = "Test title", Body = "Test body" };
    return this;
  }

  public Post Build() => _post;
}
