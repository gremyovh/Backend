using Ardalis.Specification;

namespace gremy.ovh.Core.ProjectAggregate.Specifications.PostSpec;
public class PostByIdSpec : Specification<Post>, ISingleResultSpecification
{
  public PostByIdSpec(int postId)
  {
    Query
      .Where(post => post.Id == postId);
  }
}
