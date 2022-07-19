
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KG_CleanArchitecture.Web;

public static class SeedData
{
  public static readonly Phonebook TestProject1 = new Phonebook();
  public static readonly Entry Entry1 = new Entry
  {
    Name = "Peter",
    PhoneNumber = "0721478523",
    Id = 1
  };
  public static readonly Entry Entry2 = new Entry
  {
    Name = "Jacky",
    PhoneNumber = "0718478520",
    Id = 2
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any TODO items.
      if (dbContext.Entries.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);


    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Phonebooks)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.Entries)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestProject1.AddItem(Entry1);
    TestProject1.AddItem(Entry2);
    dbContext.Phonebooks.Add(TestProject1);

    dbContext.SaveChanges();
  }
}
