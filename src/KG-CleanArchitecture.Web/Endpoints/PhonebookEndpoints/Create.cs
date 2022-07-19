using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class Create : EndpointBaseAsync
    .WithRequest<CreatePhonebookRequest>
    .WithActionResult<CreatePhonebookResponse>
{
  private readonly IRepository<Phonebook> _repository;

  public Create(IRepository<Phonebook> repository)
  {
    _repository = repository;
  }

  [HttpPost("/Phonebook")]
  [SwaggerOperation(
      Summary = "Creates a new Phonebook",
      Description = "Creates a new Phonebook",
      OperationId = "Phonebook.Create",
      Tags = new[] { "PhonebookEndpoints" })
  ]
  public override async Task<ActionResult<CreatePhonebookResponse>> HandleAsync(CreatePhonebookRequest request,
      CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var newPhonebook = new Phonebook();

    var createdItem = await _repository.AddAsync(newPhonebook);

    var response = new CreatePhonebookResponse
    (
        id: createdItem.Id,
        name: createdItem.Name
    );

    return Ok(response);
  }
}
