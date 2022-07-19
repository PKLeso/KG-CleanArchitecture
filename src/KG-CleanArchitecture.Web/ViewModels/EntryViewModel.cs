using KG_CleanArchitecture.Core.PhonebookAggregate;

namespace KG_CleanArchitecture.Web.ViewModels;

public class EntryViewModel
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? PhoneNumber { get; set; }

  public static EntryViewModel FromEntry(Entry entry)
  {
    return new EntryViewModel()
    {
      Id = entry.Id,
      Name = entry.Name,
      PhoneNumber = entry.PhoneNumber
    };
  }
}
