using KG_CleanArchitecture.SharedKernel;

namespace KG_CleanArchitecture.Core.PhonebookAggregate;

public class Entry : EntityBase
{
  public string Name { get; set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
  
}
