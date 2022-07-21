using Ardalis.Specification;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;

namespace KG_CleanArchitecture.Core.ProjectAggregate.Specifications;

public class EntryByIdWithItemsSpec : Specification<Entry>, ISingleResultSpecification
{
  public EntryByIdWithItemsSpec(int entryId)
  {
    Query
        .Where(p => p.Id == entryId);
  }
}
