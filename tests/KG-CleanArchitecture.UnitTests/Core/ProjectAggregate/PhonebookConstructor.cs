using KG_CleanArchitecture.Core.PhonebookAggregate;
using Xunit;

namespace KG_CleanArchitecture.UnitTests.Core.ProjectAggregate;

public class PhonebookConstructor
{
  private string _testName = "test name";
  private Phonebook? _testPhonebook;

  private Phonebook CreatePhonebook()
  {
    return new Phonebook();
  }

  [Fact]
  public void InitializesName()
  {
    _testPhonebook = CreatePhonebook();

    Assert.Equal(_testName, _testPhonebook.Name);
  }

  [Fact]
  public void InitializesTaskListToEmptyList()
  {
    _testPhonebook = CreatePhonebook();

    Assert.NotNull(_testPhonebook.Entries);
  }
}
