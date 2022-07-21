
using KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

namespace KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;

public class GetPhonebookByIdResponse
{
  public GetPhonebookByIdResponse(int id, string name, List<EntryRecord> entries)
  {
    Id = id;
    Name = name;
    Entries = entries;
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public List<EntryRecord> Entries { get; set; } = new();
}
