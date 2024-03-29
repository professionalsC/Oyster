﻿using System.Threading;
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

namespace Oyster.PublicApi.CatalogItemEndpoints;

[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Create : BaseAsyncEndpoint
    .WithRequest<CreateCatalogItemRequest>
    .WithResponse<CreateCatalogItemResponse>
{
    private readonly IRepository<CatalogItem> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<CatalogItem> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/catalog-items")]
    [SwaggerOperation(
        Summary = "Creates a new Catalog Item",
        Description = "Creates a new Catalog Item",
        OperationId = "catalog-items.create",
        Tags = new[] { "CatalogItemEndpoints" })
    ]
    public override async Task<ActionResult<CreateCatalogItemResponse>> HandleAsync(CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateCatalogItemResponse(request.CorrelationId());

        var catalogItemNameSpecification = new CatalogItemNameSpecification(request.Name);
        var existingCataloogItem = await _itemRepository.CountAsync(catalogItemNameSpecification, cancellationToken);
        if (existingCataloogItem > 0)
        {
            throw new DuplicateException($"A catalogItem with name {request.Name} already exists");
        }

        var newItem = new CatalogItem(request.CatalogTypeId, request.CatalogGenderTypeId, request.CatalogBrandId, request.Description, request.Name, request.Price, request.PictureUri);
        newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

        if (newItem.Id != 0)
        {
            //We disabled the upload functionality and added a default/placeholder image to this sample due to a potential security risk 
            //  pointed out by the community. More info in this issue: https://github.com/dotnet-architecture/oyster/issues/537 
            //  In production, we recommend uploading to a blob storage and deliver the image via CDN after a verification process.

            newItem.UpdatePictureUri(request.PictureUri);
            await _itemRepository.UpdateAsync(newItem, cancellationToken);
        }

        var dto = new CatalogItemDto
        {
            Id = newItem.Id,
            CatalogBrandId = newItem.CatalogBrandId,
            CatalogGenderTypeId = newItem.CatalogGenderTypeId,
            CatalogTypeId = newItem.CatalogTypeId,
            Description = newItem.Description,
            Name = newItem.Name,
            PictureUri = _uriComposer.ComposePicUri(newItem.PictureUri),
            Price = newItem.Price
        };
        response.CatalogItem = dto;
        return response;
    }


}
