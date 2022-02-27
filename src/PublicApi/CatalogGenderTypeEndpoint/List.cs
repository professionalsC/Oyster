using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.CatalogGenderTypeEndpoint;

public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<ListCatalogGenderTypesResponse>
{
    private readonly IRepository<CatalogGenderType> _catalogGenderTypeRepository;
    private readonly IMapper _mapper;

    public List(IRepository<CatalogGenderType> catalogGenderTypeRepository,
        IMapper mapper)
    {
        _catalogGenderTypeRepository = catalogGenderTypeRepository;
        _mapper = mapper;
    }

    [HttpGet("api/catalog-gender-types")]
    [SwaggerOperation(
        Summary = "List Catalog Gender Types",
        Description = "List Catalog Gender Types",
        OperationId = "catalog-gender-types.List",
        Tags = new[] { "CatalogGenderTypeEndpoints" })
    ]
    public override async Task<ActionResult<ListCatalogGenderTypesResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var response = new ListCatalogGenderTypesResponse();

        var items = await _catalogGenderTypeRepository.ListAsync(cancellationToken);
        try
        {
            response.CatalogGenderTypes.AddRange(items.Select(_mapper.Map<CatalogGenderTypeDto>));

        }
        catch (System.Exception )
        {

            throw;
        }

        return Ok(response);
    }
}
