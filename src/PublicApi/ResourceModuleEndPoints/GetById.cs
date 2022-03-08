using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdResourceModuleReques>
    .WithResponse<GetByIdResourceModuleResponse>
{
    private readonly IRepository<ResourceModule> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public GetById(IRepository<ResourceModule> itemRepository, IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpGet("api/resourcemodules/{ResourceModuleId}")]
    [SwaggerOperation(
        Summary = "Get a ResourceModule by Id",
        Description = "Gets a ResourceModule by Id",
        OperationId = "resourcemodules.GetById",
        Tags = new[] { "ResourceModuleEndPoints" })
    ]
    public override async Task<ActionResult<GetByIdResourceModuleResponse>> HandleAsync(GetByIdResourceModuleReques request, CancellationToken cancellationToken = default)
    {
        var response = new GetByIdResourceModuleResponse(request.CorrelationId());

        var item = await _itemRepository.GetByIdAsync(request.ResourceModuleId, cancellationToken);
        if (item is null) return NotFound();

        response.ResourceModule = new ResourceModuleDto
        {
            Id = item.Id,
            Name = item.Name,
            Icon = _uriComposer.ComposePicUri(item.Icon),
            Aliase=item.Aliase
        };
        return Ok(response);
    }
}
