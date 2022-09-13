using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gremy.ovh.Web;

public static class SeedData
{
  public static readonly Post TestPost1 = new("Test post", "Test post");
  public static readonly Post TestPost2 = new("Test post delete", "Test post delete");
  public static readonly Comment TestComment1 = new("Test comment", "Test comment", TestPost1.Id);
  public static readonly Comment TestComment2 = new("Test comment delete", "Test comment delete", TestPost2.Id);
  public static readonly ContentData TestContentData1 = new("TestFileName.extension", TestPost2.Id);
  public static readonly ContentData TestContentData2 = new("TestFileNameDelete.extension", TestPost2.Id);
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Posts.Any()
        && dbContext.Comments.Any()
        && dbContext.ContentData.Any())
      {
        return;
      }

      PopulateTestData(dbContext);
    }
  }

  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Posts)
    {
      dbContext.Remove(item);
    }

    foreach (var item in dbContext.Comments)
    {
      dbContext.Remove(item);
    }

    foreach (var item in dbContext.ContentData)
    {
      dbContext.Remove(item);
    }

    dbContext.SaveChanges();

    TestPost1.Comments.Add(TestComment1);
    TestPost1.Data.Add(TestContentData1);
    TestPost2.Comments.Add(TestComment2);
    TestPost2.Data.Add(TestContentData2);

    dbContext.Posts.AddRange(TestPost1, TestPost2);

    dbContext.SaveChanges();
  }
}
