using Ardalis.ApiEndpoints;
using KG_CleanArchitecture.Core.PhonebookAggregate;
using KG_CleanArchitecture.Core.ProjectAggregate.Specifications;
using KG_CleanArchitecture.SharedKernel.Interfaces;
using KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KG_CleanArchitecture.Web.Endpoints.EntriesEndpoints;

public class GetEntryById : EndpointBaseAsync
    .WithRequest<GetEntryByIdRequest>
    .WithActionResult<GetEntryByIdResponse>
{
  private readonly IRepository<Entry> _repository;

  public GetEntryById(IRepository<Entry> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetEntryByIdRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a single Entry",
      Description = "Gets a single Entry by Id",
      OperationId = "Entry.GetById",
      Tags = new[] { "EntryEndpoints" })
  ]
  public override async Task<ActionResult<GetEntryByIdResponse>> HandleAsync([FromRoute] GetEntryByIdRequest request,
      CancellationToken cancellationToken)
  {
    var spec = new EntryByIdWithItemsSpec(request.EntryId);
    var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
    if (entity == null) return NotFound();

    var response = new GetEntryByIdResponse
    (
        id: entity.Id,
        name: entity.Name,
        phoneNumber: entity.PhoneNumber
    );
    return Ok(response);
  }
}
