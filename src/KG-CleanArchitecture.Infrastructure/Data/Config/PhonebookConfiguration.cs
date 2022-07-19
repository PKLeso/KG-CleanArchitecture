using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KG_CleanArchitecture.Infrastructure.Data.Config;

public class PhonebookConfiguration : IEntityTypeConfiguration<Phonebook>
{
  public void Configure(EntityTypeBuilder<Phonebook> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();


    var navigation = builder.Metadata.FindNavigation(nameof(Phonebook.Entries));
    navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}
