using KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

namespace KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;

public class UpdatePhonebookResponse
{
  public UpdatePhonebookResponse(PhonebookRecord phonebook)
  {
    Phonebook = phonebook;
  }
  public PhonebookRecord Phonebook { get; set; }
}
