using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class Update : EndpointBaseAsync
    .WithRequest<UpdatePhonebookRequest>
    .WithActionResult<UpdatePhonebookResponse>
{
  private readonly IRepository<Phonebook> _repository;

  public Update(IRepository<Phonebook> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdatePhonebookRequest.Route)]
  [SwaggerOperation(
      Summary = "Updates a Phonebook",
      Description = "Updates a Phonebook with an entry",
      OperationId = "Phonebook.Update",
      Tags = new[] { "PhonebookEndpoints" })
  ]
  public override async Task<ActionResult<UpdatePhonebookResponse>> HandleAsync(UpdatePhonebookRequest request,
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
    existingProject.UpdateName(request.Name);

    await _repository.UpdateAsync(existingProject, cancellationToken);

    var response = new UpdatePhonebookResponse(
        phonebook: new PhonebookRecord(existingProject.Id, existingProject.Name)
    );
    return Ok(response);
  }
}
