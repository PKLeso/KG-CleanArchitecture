using System.ComponentModel.DataAnnotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class CreatePhonebookRequest
{
  public const string Route = "/Phonebook";

  [Required]
  public string? Name { get; set; }
}
