using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Extensions;
using Oyster.ApplicationCore.Interfaces;
using Oyster.ApplicationCore.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class List : BaseAsyncEndpoint
    .WithRequest<ListCatalogTypesRequest>
    .WithResponse<ListCatalogTypesResponse>
{
    private readonly IRepository<CatalogType> _itemRepository;
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public List(IRepository<CatalogType> catalogTypeRepository,
        IUriComposer uriComposer,
        IMapper mapper)
    {
        _itemRepository = catalogTypeRepository;
        _uriComposer = uriComposer;
        _mapper = mapper;
    }
    [HttpGet("api/catalog-types")]
    [SwaggerOperation(
      Summary = "List Catalog Types",
      Description = "List Catalog Types",
      OperationId = "catalog-types.List",
      Tags = new[] { "CatalogTypeEndpoints" })
  ]
   
    public override async Task<ActionResult<ListCatalogTypesResponse>> HandleAsync([FromQuery] ListCatalogTypesRequest request,CancellationToken cancellationToken)
    {
        var response = new ListCatalogTypesResponse(request.CorrelationId());
        var filterSpec = new CatalogTypeFilterSpecification(request.SearchString);

        int totalItems = await _itemRepository.CountAsync(filterSpec, cancellationToken);

        var pagedSpec = new CatalogTypeFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize);

        var items = await _itemRepository.ListAsync(pagedSpec, cancellationToken);

        response.CatalogTypes.AddRange(items.Select(_mapper.Map<CatalogTypeDto>));
        foreach (CatalogTypeDto item in response.CatalogTypes)
        {
            item.PictureUri = _uriComposer.ComposePicUri(item.PictureUri);
        }

        if (request.PageSize > 0)
        {
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
        }
        else
        {
            response.PageCount = totalItems > 0 ? 1 : 0;
        }

        return Ok(response);
    }

}
