using KG_CleanArchitecture.Core.PhonebookAggregate;
using Xunit;

namespace KG_CleanArchitecture.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsPhonebookAndSetsId()
  {
    var testPhonebookName = "testPhonebookName";
    var repository = GetRepository();
    var phonebook = new Phonebook("Test name");

    await repository.AddAsync(phonebook);

    var newPhonebook = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testPhonebookName, newPhonebook?.Name);
    Assert.True(newPhonebook?.Id > 0);
  }
}
