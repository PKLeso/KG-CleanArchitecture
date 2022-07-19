using System.ComponentModel.DataAnnotations;

namespace KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;

public class UpdatePhonebookRequest
{
  public const string Route = "/Phonebook";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
