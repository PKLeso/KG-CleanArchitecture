using System.ComponentModel.DataAnnotations;

namespace KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;

public class UpdateEntryRequest
{
  public const string Route = "api/Entries/{id}";
  [Required]
  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string PhoneNumber { get; set; }
  [Required]
  public int PhonebookId { get; set; }
}
