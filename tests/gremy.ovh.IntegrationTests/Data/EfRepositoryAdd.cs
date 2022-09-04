using gremy.ovh.Core.ProjectAggregate;
using Xunit;

namespace gremy.ovh.IntegrationTests.Data;
public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsProjectAndSetsId()
  {
    var repository = GetRepository();
    var post = new Post("Test post title", "Test post body");

    await repository.AddAsync(post);

    var newPost = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(post.Title, newPost?.Title);
    Assert.Equal(post.Body, newPost?.Body);
    Assert.True(newPost?.Id > 0);
  }
}
