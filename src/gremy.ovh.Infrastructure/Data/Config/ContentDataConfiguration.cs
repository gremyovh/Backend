using gremy.ovh.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gremy.ovh.Infrastructure.Data.Config;
public class ContentDataConfiguration : IEntityTypeConfiguration<ContentData>
{
  public void Configure(EntityTypeBuilder<ContentData> builder)
  {
    builder.Property(p => p.FileName)
      .HasMaxLength(36)
      .IsRequired();
  }
}
