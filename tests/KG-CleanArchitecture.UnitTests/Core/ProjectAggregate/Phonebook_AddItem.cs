using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;
using Xunit;

namespace KG_CleanArchitecture.UnitTests.Core.ProjectAggregate;

public class Phonebook_AddItem
{
  private Phonebook _testPhonebook = new Phonebook();

  [Fact]
  public void AddsItemToItems()
  {
    var _testEntry = new Entry
    {
      Name = "name",
      PhoneNumber = "0724785412"
    };

    _testPhonebook.AddItem(_testEntry);

    Assert.Contains(_testEntry, _testPhonebook.Entries);
  }

  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
#nullable disable
    Action action = () => _testPhonebook.AddItem(null);
#nullable enable

    var ex = Assert.Throws<ArgumentNullException>(action);
    Assert.Equal("newItem", ex.ParamName);
  }
}
