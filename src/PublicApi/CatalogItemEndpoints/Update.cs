﻿using System.IO;
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

namespace Oyster.PublicApi.CatalogItemEndpoints;

[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateCatalogItemRequest>
    .WithResponse<UpdateCatalogItemResponse>
{
    private readonly IRepository<CatalogItem> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Update(IRepository<CatalogItem> itemRepository, IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPut("api/catalog-items")]
    [SwaggerOperation(
        Summary = "Updates a Catalog Item",
        Description = "Updates a Catalog Item",
        OperationId = "catalog-items.update",
        Tags = new[] { "CatalogItemEndpoints" })
    ]
    public override async Task<ActionResult<UpdateCatalogItemResponse>> HandleAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var response = new UpdateCatalogItemResponse(request.CorrelationId());

        var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

        existingItem.UpdateDetails(request.Name, request.Description, request.Price);
        existingItem.UpdateBrand(request.CatalogBrandId);
        existingItem.UpdateGenderType(request.CatalogGenderTypeId);
        existingItem.UpdateType(request.CatalogTypeId);

        await _itemRepository.UpdateAsync(existingItem, cancellationToken);

        var dto = new CatalogItemDto
        {
            Id = existingItem.Id,
            CatalogBrandId = existingItem.CatalogBrandId,
            CatalogTypeId = existingItem.CatalogTypeId,
            Description = existingItem.Description,
            Name = existingItem.Name,
            PictureUri = _uriComposer.ComposePicUri(existingItem.PictureUri),
            Price = existingItem.Price
        };
        response.CatalogItem = dto;
        return response;
    }
}
