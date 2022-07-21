using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class DeletePhonebook : EndpointBaseAsync
    .WithRequest<DeletePhonebookRequest>
    .WithoutResult
{
  private readonly IRepository<Phonebook> _repository;

  public DeletePhonebook(IRepository<Phonebook> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeletePhonebookRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Phonebook",
      Description = "Deletes a Phonebook",
      OperationId = "Phonebook.Delete",
      Tags = new[] { "PhonebookEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeletePhonebookRequest request,
      CancellationToken cancellationToken)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.PhonebookId, cancellationToken);
    if (aggregateToDelete == null) return NotFound();

    await _repository.DeleteAsync(aggregateToDelete);

    return NoContent();
  }
}
