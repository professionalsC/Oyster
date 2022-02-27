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

namespace Oyster.PublicApi.CatalogTypeEndpoints;
[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteCatalogTypeRequest>
    .WithResponse<DeleteCatalogTypeResponse>
{
    private readonly IRepository<CatalogType> _itemRepository;

    public Delete(IRepository<CatalogType> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpDelete("api/catalog-type/{CatalogTypeId}")]
    [SwaggerOperation(
        Summary = "Deletes a Catalog Type",
        Description = "Deletes a Catalog Type",
        OperationId = "catalog-types.Delete",
        Tags = new[] { "CatalogTypeEndpoints" })
    ]
    public override async Task<ActionResult<DeleteCatalogTypeResponse>> HandleAsync(DeleteCatalogTypeRequest request, CancellationToken cancellationToken = default)
    {
        var response = new DeleteCatalogTypeResponse(request.CorrelationId());

        var itemToDelete = await _itemRepository.GetByIdAsync(request.CatalogTypeId, cancellationToken);
        if (itemToDelete is null) return NotFound();

        await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

        return Ok(response);
    }
}
