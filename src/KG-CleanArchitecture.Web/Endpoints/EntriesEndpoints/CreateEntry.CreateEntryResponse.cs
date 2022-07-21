namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class CreateEntryResponse
{
  public CreateEntryResponse(int id, string name, string phoneNumber)
  {
    Id = id;
    Name = name;
    PhoneNumber = phoneNumber;
  }
  public int Id { get; set; }
  public string Name { get; set; }
  public string PhoneNumber { get; set; }
}
