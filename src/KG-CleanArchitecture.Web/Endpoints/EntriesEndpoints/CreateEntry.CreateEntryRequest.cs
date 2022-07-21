using System.ComponentModel.DataAnnotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class CreateEntryRequest
{
  public const string Route = "/Entry";

  [Required]
  public string Name { get; set; }

  [Required]
  public string PhoneNumber { get; set; }


  [Required]
  public int PhonebookId { get; set; }
}
