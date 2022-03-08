using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateResourceModuleRequest>
    .WithResponse<UpdateResourceModuleResponse>
{
    private readonly IRepository<ResourceModule> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Update(IRepository<ResourceModule> itemRepository, IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPut("api/resourcemodules")]
    [SwaggerOperation(
        Summary = "Updates a ResourceModule",
        Description = "Updates a ResourceModule",
        OperationId = "resourcemodules.update",
        Tags = new[] { "ResourceModuleEndPoints" })
    ]
    public override async Task<ActionResult<UpdateResourceModuleResponse>> HandleAsync(UpdateResourceModuleRequest request, CancellationToken cancellationToken = default)
    {
        var response = new UpdateResourceModuleResponse(request.CorrelationId());

        var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

        existingItem.UpdateResourceModule(request.Name, request.Icon, request.Aliase);

        await _itemRepository.UpdateAsync(existingItem, cancellationToken);

        var dto = new ResourceModuleDto
        {
            Id = existingItem.Id,
            Name = existingItem.Name,
            Icon = _uriComposer.ComposePicUri(existingItem.Icon),
            Aliase = existingItem.Aliase

        };
        response.ResourceModule = dto;
        return response;
    }
}
