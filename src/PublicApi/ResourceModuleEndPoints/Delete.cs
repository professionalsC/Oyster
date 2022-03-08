using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Constants;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.ResourceModuleEndPoints;
[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteResourceModuleRequest>
    .WithResponse<DeleteResourceModuleResponse>
{
    private readonly IRepository<ResourceModule> _itemRepository;

    public Delete(IRepository<ResourceModule> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpDelete("api/resourcemodule/{ResourceModuleId}")]
    [SwaggerOperation(
        Summary = "Deletes a ResourceModule",
        Description = "Deletes a ResourceModule",
        OperationId = "resourcemodules.Delete",
        Tags = new[] { "ResourceModuleEndPoints" })
    ]
    public override async Task<ActionResult<DeleteResourceModuleResponse>> HandleAsync(DeleteResourceModuleRequest request, CancellationToken cancellationToken = default)
    {
        var response = new DeleteResourceModuleResponse(request.CorrelationId());

        var itemToDelete = await _itemRepository.GetByIdAsync(request.ResourceModuleId, cancellationToken);
        if (itemToDelete is null) return NotFound();

        await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

        return Ok(response);
    }
}
