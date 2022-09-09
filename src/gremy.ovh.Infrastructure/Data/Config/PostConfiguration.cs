using gremy.ovh.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gremy.ovh.Infrastructure.Data.Config;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
  public void Configure(EntityTypeBuilder<Post> builder)
  {
    builder.Property(p => p.Title)
      .HasMaxLength(50)
      .IsRequired();
    builder.Property(p => p.Body)
      .HasMaxLength(255)
      .IsRequired();
    builder.Property(p => p.CreationDate)
      .ValueGeneratedOnAdd()
      .IsRequired();
    builder.HasMany(p => p.Comments)
      .WithOne(p => p.Post)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasMany(p => p.Data)
      .WithOne(p => p.Post)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
