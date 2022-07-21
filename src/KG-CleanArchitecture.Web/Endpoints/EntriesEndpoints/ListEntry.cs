using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.EntriesEndpoints;

public class ListEntry : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<EntryListResponse>
{
  private readonly IReadRepository<Entry> _repository;

  public ListEntry(IReadRepository<Entry> repository)
  {
    _repository = repository;
  }

  [HttpGet("api/Entries")]
  [SwaggerOperation(
      Summary = "Gets a list of all Entry",
      Description = "Gets a list of all Entry",
      OperationId = "Entry.List",
      Tags = new[] { "EntryEndpoints" })
  ]
  public override async Task<ActionResult<EntryListResponse>> HandleAsync(CancellationToken cancellationToken)
  {
    var response = new EntryListResponse();
    response.Entry = (await _repository.ListAsync())
        .Select(entry => new EntryRecords(entry.Id, entry.Name, entry.PhoneNumber, entry.PhonebookId))
        .ToList();

    return Ok(response);
  }
}
