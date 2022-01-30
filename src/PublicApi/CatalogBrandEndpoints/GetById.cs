using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdCatalogBrandRequest>
    .WithResponse<GetByIdCatalogBrandResponse>
{
    private readonly IRepository<CatalogBrand> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public GetById(IRepository<CatalogBrand> itemRepository, IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpGet("api/catalog-brands/{CatalogBrandId}")]
    [SwaggerOperation(
        Summary = "Get a Catalog Brand by Id",
        Description = "Gets a Catalog Brand by Id",
        OperationId = "catalog-brands.GetById",
        Tags = new[] { "CatalogBrandEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdCatalogBrandResponse>> HandleAsync(GetByIdCatalogBrandRequest request, CancellationToken cancellationToken = default)
    {
        var response = new GetByIdCatalogBrandResponse(request.CorrelationId());

        var item = await _itemRepository.GetByIdAsync(request.CatalogBrandId, cancellationToken);
        if (item is null) return NotFound();

        response.CatalogBrand = new CatalogBrandDto
        {
            Id = item.Id,           
            Brand = item.Brand,
            PictureUri = _uriComposer.ComposePicUri(item.PictureUri)
        };
        return Ok(response);
    }
}
