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

public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateCatalogBrandRequest>
    .WithResponse<UpdateCatalogBrandResponse>
{
    private readonly IRepository<CatalogBrand> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Update(IRepository<CatalogBrand> itemRepository, IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPut("api/catalog-brands")]
    [SwaggerOperation(
        Summary = "Updates a Catalog Brand",
        Description = "Updates a Catalog Brand",
        OperationId = "catalog-brands.update",
        Tags = new[] { "CatalogItemEndpoints" })
    ]
    public override async Task<ActionResult<UpdateCatalogBrandResponse>> HandleAsync(UpdateCatalogBrandRequest request, CancellationToken cancellationToken = default)
    {
        var response = new UpdateCatalogBrandResponse(request.CorrelationId());

        var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

        existingItem.UpdateBrand(request.Brand,request.Status);        

        await _itemRepository.UpdateAsync(existingItem, cancellationToken);

        var dto = new CatalogBrandDto
        {
            Id = existingItem.Id,
            Brand = existingItem.Brand,
            PictureUri = _uriComposer.ComposePicUri(existingItem.PictureUri),
            BannerPictureUri = _uriComposer.ComposePicUri(existingItem.BannerPictureUri),
            Status = existingItem.Status

        };
        response.CatalogBrand = dto;
        return response;
    }
}
