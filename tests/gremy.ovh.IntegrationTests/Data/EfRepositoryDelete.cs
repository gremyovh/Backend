using gremy.ovh.Core.ProjectAggregate;
using Xunit;

namespace gremy.ovh.IntegrationTests.Data;
public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository();
    var post = new Post("Test post title", "Test post body");
    await repository.AddAsync(post);

    // delete the item
    await repository.DeleteAsync(post);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        project =>
          project.Title == post.Title
          && project.Body == post.Body);
  }
}
