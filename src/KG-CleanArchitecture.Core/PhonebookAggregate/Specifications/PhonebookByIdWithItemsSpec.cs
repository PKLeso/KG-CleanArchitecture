using Ardalis.Specification;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;

namespace KG_CleanArchitecture.Core.ProjectAggregate.Specifications;

public class PhonebookByIdWithItemsSpec : Specification<Phonebook>, ISingleResultSpecification
{
  public PhonebookByIdWithItemsSpec(int phonebookId)
  {
    Query
        .Where(p => p.Id == phonebookId)
        .Include(p => p.Entries);
  }
}
