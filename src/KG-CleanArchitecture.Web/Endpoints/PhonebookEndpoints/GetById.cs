using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate.Specifications;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.PhonebookEndpoints;

public class GetById : EndpointBaseAsync
    .WithRequest<GetPhonebookByIdRequest>
    .WithActionResult<GetPhonebookByIdResponse>
{
  private readonly IRepository<Phonebook> _repository;

  public GetById(IRepository<Phonebook> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetPhonebookByIdRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a single Phonebook",
      Description = "Gets a single Phonebook by Id",
      OperationId = "Phonebook.GetById",
      Tags = new[] { "PhonebookEndpoints" })
  ]
  public override async Task<ActionResult<GetPhonebookByIdResponse>> HandleAsync([FromRoute] GetPhonebookByIdRequest request,
      CancellationToken cancellationToken)
  {
    var spec = new PhonebookByIdWithItemsSpec(request.PhonebookId);
    var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
    if (entity == null) return NotFound();

    var response = new GetPhonebookByIdResponse
    (
        id: entity.Id,
        name: entity.Name,
        entries: entity.Entries.Select(item => new EntryRecord(item.Id, item.Name, item.PhoneNumber)).ToList()
    );
    return Ok(response);
  }
}
