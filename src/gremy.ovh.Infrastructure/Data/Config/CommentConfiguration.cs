using gremy.ovh.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gremy.ovh.Infrastructure.Data.Config;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
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
  }
}
