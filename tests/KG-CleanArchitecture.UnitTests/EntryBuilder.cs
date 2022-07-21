using KG_CleanArchitecture.Core.PhonebookAggregate;

namespace KG_CleanArchitecture.UnitTests;

// Learn more about test builders:
// https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
public class EntryBuilder
{
  private Entry _entry = new Entry("Test Name", "Test phone number", 1);

  public EntryBuilder Id(int id)
  {
    _entry.Id = id;
    return this;
  }


  public EntryBuilder WithDefaultValues()
  {
    _entry = new Entry("Test Name", "Test PhoneNumber", 1);

    return this;
  }

  public Entry Build() => _entry;
}
