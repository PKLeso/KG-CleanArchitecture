using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KG_CleanArchitecture.Infrastructure.Data.Config;

public class EntryConfiguration : IEntityTypeConfiguration<Entry>
{
  public void Configure(EntityTypeBuilder<Entry> builder)
  {
    builder.Property(t => t.Name)
        .IsRequired();


    builder.Property(p => p.PhoneNumber)
        .IsRequired();
  }
}
