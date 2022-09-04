using gremy.ovh.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace gremy.ovh.IntegrationTests.Data;
public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository();
    var post = new Post("Test post title", "Test post body");

    await repository.AddAsync(post);

    // detach the item so we get a different instance
    _dbContext.Entry(post).State = EntityState.Detached;

    // fetch the item and update its title
    var newPost = (await repository.ListAsync())
        .FirstOrDefault(project =>
          project.Title == post.Title
          && project.Body == post.Body);
    if (newPost == null)
    {
      Assert.NotNull(newPost);
      return;
    }
    Assert.NotSame(post, newPost);
    newPost.Title = "Test post title renamed";

    // Update the item
    await repository.UpdateAsync(newPost);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(project =>
        project.Title == newPost.Title
        && project.Body == newPost.Body);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(post.Title, updatedItem?.Title);
    Assert.Equal(post.Body, updatedItem?.Body);
    Assert.Equal(newPost.Id, updatedItem?.Id);
  }
}
