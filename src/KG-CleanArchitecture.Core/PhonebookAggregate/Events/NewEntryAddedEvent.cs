using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel;

namespace KG_CleanArchitecture.Core.PhonebookAggregate.Events;

public class NewEntryAddedEvent : DomainEventBase
{
  public Entry NewEntry { get; set; }
  public Phonebook Phonebook { get; set; }

  public NewEntryAddedEvent(Phonebook phonebook,
      Entry newEntry)
  {
    Phonebook = phonebook;
    NewEntry = newEntry;
  }
}
