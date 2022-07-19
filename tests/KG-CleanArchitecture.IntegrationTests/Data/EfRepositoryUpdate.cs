using KG_CleanArchitecture.Core.PhonebookAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KG_CleanArchitecture.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a phonebook entry
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var phonebook = new Phonebook();

    await repository.AddAsync(phonebook);

    // detach the item so we get a different instance
    _dbContext.Entry(phonebook).State = EntityState.Detached;

    // fetch the item and update its title
    var newPhonebook = (await repository.ListAsync())
        .FirstOrDefault(phonebook => phonebook.Name == initialName);
    if (newPhonebook == null)
    {
      Assert.NotNull(newPhonebook);
      return;
    }
    Assert.NotSame(phonebook, newPhonebook);
    var newName = Guid.NewGuid().ToString();
    newPhonebook.UpdateName(newName);

    // Update the item
    await repository.UpdateAsync(newPhonebook);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(phonebook => phonebook.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(phonebook.Name, updatedItem?.Name);
    Assert.Equal(newPhonebook.Id, updatedItem?.Id);
  }
}
