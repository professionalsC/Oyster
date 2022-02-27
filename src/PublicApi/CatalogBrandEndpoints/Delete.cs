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

namespace Oyster.PublicApi.CatalogBrandEndpoints;
[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteCatalogBrandRequest>
    .WithResponse<DeleteCatalogBrandResponse>
{
    private readonly IRepository<CatalogBrand> _itemRepository;

    public Delete(IRepository<CatalogBrand> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpDelete("api/catalog-brands/{CatalogBrandId}")]
    [SwaggerOperation(
        Summary = "Deletes a Catalog Brand",
        Description = "Deletes a Catalog Brand",
        OperationId = "catalog-brands.Delete",
        Tags = new[] { "CatalogBrandEndpoints" })
    ]
    public override async Task<ActionResult<DeleteCatalogBrandResponse>> HandleAsync(DeleteCatalogBrandRequest request, CancellationToken cancellationToken = default)
    {
        var response = new DeleteCatalogBrandResponse(request.CorrelationId());

        var itemToDelete = await _itemRepository.GetByIdAsync(request.CatalogBrandId, cancellationToken);
        if (itemToDelete is null) return NotFound();

        await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

        return Ok(response);
    }
}
