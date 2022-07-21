using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.EntriesEndpoints;

public class DeleteEntry : EndpointBaseAsync
    .WithRequest<DeleteEntryRequest>
    .WithoutResult
{
  private readonly IRepository<Entry> _repository;

  public DeleteEntry(IRepository<Entry> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteEntryRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Entry",
      Description = "Deletes a Entry",
      OperationId = "Entry.Delete",
      Tags = new[] { "EntryEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteEntryRequest request,
      CancellationToken cancellationToken)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.EntryId, cancellationToken);
    if (aggregateToDelete == null) return NotFound();

    await _repository.DeleteAsync(aggregateToDelete);

    return NoContent();
  }
}
