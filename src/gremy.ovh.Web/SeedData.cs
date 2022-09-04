using gremy.ovh.Core.ProjectAggregate;
using gremy.ovh.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gremy.ovh.Web;

public static class SeedData
{
  public static readonly Post TestPost1 = new("Test post", "Test post");
  public static readonly Post TestPost2 = new("Test post delete", "Test post delete") { Id = 9999 };
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any TODO items.
      if (dbContext.Posts.Any())
      {
        return;   // DB has been seeded
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

    dbContext.SaveChanges();

    dbContext.Posts.AddRange(TestPost1, TestPost2);

    dbContext.SaveChanges();
  }
}
