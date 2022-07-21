namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class DeleteEntryRequest
{
  public const string Route = "/Entry/{EntryId:int}";
  public static string BuildRoute(int entryId) => Route.Replace("{EntryId:int}", entryId.ToString());

  public int EntryId { get; set; }
}
