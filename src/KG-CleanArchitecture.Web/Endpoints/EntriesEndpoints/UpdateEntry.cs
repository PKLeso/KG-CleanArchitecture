using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.EntriesEndpoints;

public class UpdateEntry : EndpointBaseAsync
    .WithRequest<UpdateEntryRequest>
    .WithActionResult<UpdateEntryResponse>
{
  private readonly IRepository<Entry> _repository;

  public UpdateEntry(IRepository<Entry> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdateEntryRequest.Route)]
  [SwaggerOperation(
      Summary = "Updates a Entry",
      Description = "Updates a Entry",
      OperationId = "Entry.Update",
      Tags = new[] { "EntryEndpoints" })
  ]
  public override async Task<ActionResult<UpdateEntryResponse>> HandleAsync(UpdateEntryRequest request,
      CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      return BadRequest();
    }
    var existingProject = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (existingProject == null)
    {
      return NotFound();
    }
    existingProject.UpdateName(request.Name, request.PhoneNumber, request.PhonebookId);

    await _repository.UpdateAsync(existingProject, cancellationToken);

    var response = new UpdateEntryResponse(
        entry: new EntryRecords(existingProject.Id, existingProject.Name, existingProject.PhoneNumber, existingProject.PhonebookId)
    );
    return Ok(response);
  }
}
