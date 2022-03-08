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

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class List : BaseAsyncEndpoint
    .WithRequest<ListResourceModuleRequest>
    .WithResponse<ListResourceModuleResponse>
{
    private readonly IRepository<ResourceModule> _itemRepository;
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public List(IRepository<ResourceModule> itemRepository,
    IUriComposer uriComposer,
    IMapper mapper)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    [HttpGet("api/catalog-brands")]
    [SwaggerOperation(
        Summary = "List ResourceModule",
        Description = "List Resource Module",
        OperationId = "resourcemodule.List",
        Tags = new[] { "ResourceModuleEndPoints" })
    ]
    public override async Task<ActionResult<ListResourceModuleResponse>> HandleAsync(ListResourceModuleRequest request, CancellationToken cancellationToken = default)
    {
        var response = new ListResourceModuleResponse(request.CorrelationId());
        var filterSpec = new ResourceModuleFilterSpecification(request.SearchString);

        int totalItems = await _itemRepository.CountAsync(filterSpec, cancellationToken);

        var pagedSpec = new ResourceModuleFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize);

        var items = await _itemRepository.ListAsync(pagedSpec, cancellationToken);

        response.ResourceModules.AddRange(items.Select(_mapper.Map<ResourceModuleDto>));        

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
