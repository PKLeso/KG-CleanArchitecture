namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class DeletePhonebookRequest
{
  public const string Route = "/Phonebook/{PhonebookId:int}";
  public static string BuildRoute(int phonebookId) => Route.Replace("{PhonebookId:int}", phonebookId.ToString());

  public int PhonebookId { get; set; }
}
