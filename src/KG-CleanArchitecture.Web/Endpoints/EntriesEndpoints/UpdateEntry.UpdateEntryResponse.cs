
using KG_CleanArchitecture.Web.Endpoints.EntriesEndpoints;

namespace KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;

public class UpdateEntryResponse
{
  public UpdateEntryResponse(EntryRecords entry)
  {
    Entry = entry;
  }
  public EntryRecords Entry { get; set; }
}
