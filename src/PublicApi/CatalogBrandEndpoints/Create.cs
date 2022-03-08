using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Constants;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Exceptions;
using Oyster.ApplicationCore.Interfaces;
using Oyster.ApplicationCore.Specifications;
using Oyster.PublicApi.CatalogItemEndpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Create : BaseAsyncEndpoint
    .WithRequest<CreateCatalogBrandRequest>
    .WithResponse<CreateCatalogBrandResponse>
{
    private readonly IRepository<CatalogBrand> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<CatalogBrand> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/catalog-brands")]
    [SwaggerOperation(
        Summary = "Creates a new Catalog Brand",
        Description = "Creates a new Catalog Brand",
        OperationId = "catalog-Brand.create",
        Tags = new[] { "CatalogBrandEndpoints" })
    ]
    public override async Task<ActionResult<CreateCatalogBrandResponse>> HandleAsync(CreateCatalogBrandRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateCatalogBrandResponse(request.CorrelationId());

        var catalogBrandNameSpecification = new CatalogBrandNameSpecification(request.Brand);
        var existingCataloogItem = await _itemRepository.CountAsync(catalogBrandNameSpecification, cancellationToken);
        if (existingCataloogItem > 0)
        {
            throw new DuplicateException($"A catalogBrand with name {request.Brand} already exists");
        }

        var newItem = new CatalogBrand(request.Brand,request.PictureUri,request.BannerPictureUri,request.Status);
          await _itemRepository.AddAsync(newItem, cancellationToken);

        if (newItem.Id != 0)
        {
            //We disabled the upload functionality and added a default/placeholder image to this sample due to a potential security risk 
            //  pointed out by the community. More info in this issue: https://github.com/dotnet-architecture/oyster/issues/537 
            //  In production, we recommend uploading to a blob storage and deliver the image via CDN after a verification process.

            newItem.UpdatePictureUri(request.PictureUri);
            newItem.UpdateBannerPictureUri(request.BannerPictureUri);
            await _itemRepository.UpdateAsync(newItem, cancellationToken);
        }

        var dto = new CatalogBrandDto
        {
            Id = newItem.Id,
            Brand = newItem.Brand,
            PictureUri = _uriComposer.ComposePicUri(newItem.PictureUri),
            BannerPictureUri = _uriComposer.ComposePicUri(newItem.BannerPictureUri),
            Status = newItem.Status,
        };
        response.CatalogBrand = dto;
        return response;
    }


}
