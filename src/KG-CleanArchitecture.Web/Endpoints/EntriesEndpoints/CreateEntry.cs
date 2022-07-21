using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.EntriesEndpoints;

public class CreateEntry : EndpointBaseAsync
    .WithRequest<CreateEntryRequest>
    .WithActionResult<CreateEntryResponse>
{
  private readonly IRepository<Entry> _repository;

  public CreateEntry(IRepository<Entry> repository)
  {
    _repository = repository;
  }

  [HttpPost("api/Entries")]
  [SwaggerOperation(
      Summary = "Creates a new Entry",
      Description = "Creates a new Entry",
      OperationId = "Entry.Create",
      Tags = new[] { "EntryEndpoints" })
  ]
  public override async Task<ActionResult<CreateEntryResponse>> HandleAsync(CreateEntryRequest request,
      CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var newEntry = new Entry(request.Name, request.PhoneNumber, request.PhonebookId);

    var createdItem = await _repository.AddAsync(newEntry);

    var response = new CreateEntryResponse
    (
        id: createdItem.Id,
        name: createdItem.Name,
        phoneNumber: createdItem.PhoneNumber
    );

    return Ok(response);
  }
}
