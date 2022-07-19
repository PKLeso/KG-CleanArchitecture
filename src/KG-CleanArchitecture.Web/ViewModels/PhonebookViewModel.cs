using System.Collections.Generic;

namespace KG_CleanArchitecture.Web.ViewModels;

public class PhonebookViewModel
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public List<EntryViewModel> Entries = new();
}
