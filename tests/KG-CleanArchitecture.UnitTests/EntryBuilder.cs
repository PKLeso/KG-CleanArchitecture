using KG_CleanArchitecture.Core.PhonebookAggregate;

namespace KG_CleanArchitecture.UnitTests;

// Learn more about test builders:
// https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
public class EntryBuilder
{
  private Entry _entry = new Entry();

  public EntryBuilder Id(int id)
  {
    _entry.Id = id;
    return this;
  }

  public EntryBuilder Name(string name)
  {
    _entry.Name = name;
    return this;
  }

  public EntryBuilder PhoneNumber(string phonenumber)
  {
    _entry.PhoneNumber = phonenumber;
    return this;
  }

  public EntryBuilder WithDefaultValues()
  {
    _entry = new Entry() { Id = 1, Name = "Test Name", PhoneNumber = "Test PhoneNumber" };

    return this;
  }

  public Entry Build() => _entry;
}
