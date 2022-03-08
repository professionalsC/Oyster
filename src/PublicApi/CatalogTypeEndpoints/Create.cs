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
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.CatalogTypeEndpoints;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Create : BaseAsyncEndpoint
    .WithRequest<CreateCatalogTypeRequest>
    .WithResponse<CreateCatalogTypeResponse>
{
    private readonly IRepository<CatalogType> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<CatalogType> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/catalog-types")]
    [SwaggerOperation(
        Summary = "Creates a new Catalog Type",
        Description = "Creates a new Catalog Type",
        OperationId = "catalog-Type.create",
        Tags = new[] { "CatalogTypeEndpoints" })
    ]
    public override async Task<ActionResult<CreateCatalogTypeResponse>> HandleAsync(CreateCatalogTypeRequest request, CancellationToken cancellationToken = default)
    {
        var response = new CreateCatalogTypeResponse(request.CorrelationId());

        var catalogTypeNameSpecification = new CatalogTypeNameSpecification(request.Type);
        var existingCataloogItem = await _itemRepository.CountAsync(catalogTypeNameSpecification, cancellationToken);
        if (existingCataloogItem > 0)
        {
            throw new DuplicateException($"A catalogType with name {request.Type} already exists");
        }

        var newItem = new CatalogType(request.Type, request.Description, request.PictureUri, request.BannerPictureUri,request.ParentCatalogTypeId,request.Status);
        newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

        if (newItem.Id != 0)
        {

            newItem.UpdatePictureUri(request.PictureUri);
            newItem.UpdateBannerPictureUri(request.BannerPictureUri);
            await _itemRepository.UpdateAsync(newItem, cancellationToken);
        }

        var dto = new CatalogTypeDto
        {
            Id = newItem.Id,
            Type = newItem.Type,
            PictureUri = _uriComposer.ComposePicUri(newItem.PictureUri),
            BannerPictureUri = _uriComposer.ComposePicUri(newItem.BannerPictureUri),
            Status = newItem.Status,
        };
        response.CatalogType = dto;
        return response;
    }
}
