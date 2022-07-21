using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<PhonebookListResponse>
{
  private readonly IReadRepository<Phonebook> _repository;

  public List(IReadRepository<Phonebook> repository)
  {
    _repository = repository;
  }

  [HttpGet("/get-phonebook-list")]
  [SwaggerOperation(
      Summary = "Gets a list of all Phonebook",
      Description = "Gets a list of all Phonebook",
      OperationId = "Phonebook.List",
      Tags = new[] { "PhonebookEndpoints" })
  ]
  public override async Task<ActionResult<PhonebookListResponse>> HandleAsync(CancellationToken cancellationToken)
  {
    var response = new PhonebookListResponse();
    response.Phonebook = (await _repository.ListAsync())
        .Select(project => new PhonebookRecord(project.Id, project.Name))
        .ToList();

    return Ok(response);
  }
}
