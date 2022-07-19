using Ardalis.GuardClauses;
using KG_CleanArchitecture.Core.PhonebookAggregate.Events;
using KG_CleanArchitecture.SharedKernel;
using KG_CleanArchitecture.SharedKernel.Interfaces;

namespace KG_CleanArchitecture.Core.PhonebookAggregate;

public class Phonebook : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  private List<Entry> _entries = new List<Entry>();
  public IEnumerable<Entry> Entries => _entries.AsReadOnly();


  public void AddItem(Entry newEntry)
  {
    Guard.Against.Null(newEntry, nameof(newEntry));
    _entries.Add(newEntry);

    var newItemAddedEvent = new NewEntryAddedEvent(this, newEntry);
    base.RegisterDomainEvent(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
