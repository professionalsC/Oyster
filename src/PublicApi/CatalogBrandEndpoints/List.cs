using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Oyster.ApplicationCore.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class List : BaseAsyncEndpoint
    .WithRequest<ListCatalogBrandsRequest>
    .WithResponse<ListCatalogBrandsResponse>
{
    private readonly IRepository<CatalogBrand> _itemRepository;
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public List(IRepository<CatalogBrand> itemRepository,
    IUriComposer uriComposer,
    IMapper mapper)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    [HttpGet("api/catalog-brands")]
    [SwaggerOperation(
        Summary = "List Catalog Brands",
        Description = "List Catalog Brands",
        OperationId = "catalog-brands.List",
        Tags = new[] { "CatalogBrandEndpoints" })
    ]
    public override async Task<ActionResult<ListCatalogBrandsResponse>> HandleAsync([FromQuery] ListCatalogBrandsRequest request, CancellationToken cancellationToken)
    {
        var response = new ListCatalogBrandsResponse(request.CorrelationId());
        var filterSpec = new CatalogBrandFilterSpecification(request.SearchString);

        int totalItems = await _itemRepository.CountAsync(filterSpec, cancellationToken);

        var pagedSpec = new CatalogBrandFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize);

        var items = await _itemRepository.ListAsync(pagedSpec, cancellationToken);

        response.CatalogBrands.AddRange(items.Select(_mapper.Map<CatalogBrandDto>));
        foreach (CatalogBrandDto item in response.CatalogBrands)
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
