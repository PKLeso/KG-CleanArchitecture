using Ardalis.GuardClauses;
using KG_CleanArchitecture.Core.PhonebookAggregate.Events;
using KG_CleanArchitecture.SharedKernel;
using KG_CleanArchitecture.SharedKernel.Interfaces;

namespace KG_CleanArchitecture.Core.PhonebookAggregate;

public class Entry : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public string PhoneNumber { get; set; }
  public int PhonebookId { get; set; }

  public Entry(string name, string phoneNumber, int phonebookId)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    PhonebookId = phonebookId;
  }

  public void UpdateName(string newName, string newPhoneNumber, int newPhonebookId)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    PhoneNumber = Guard.Against.NullOrEmpty(newPhoneNumber, nameof(newPhoneNumber));
    PhonebookId = Guard.Against.NegativeOrZero(newPhonebookId, nameof(newPhonebookId));
  }
}
