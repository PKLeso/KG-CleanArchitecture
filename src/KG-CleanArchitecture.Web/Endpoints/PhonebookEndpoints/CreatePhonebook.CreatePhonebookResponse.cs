namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class CreatePhonebookResponse
{
  public CreatePhonebookResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }
  public int Id { get; set; }
  public string Name { get; set; }
}
