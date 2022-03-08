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

namespace Oyster.PublicApi.MerchantEndpoints;

public class List : BaseAsyncEndpoint
     .WithRequest<ListMerchantRequest>
    .WithResponse<ListMerchantResponse>
{
    private readonly IRepository<Merchant> _itemRepository;
    private readonly IMapper _mapper;
    private readonly IUriComposer _uriComposer;

    public List(IRepository<Merchant> itemRepository, IUriComposer uriComposer,
        IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
        _uriComposer = uriComposer;

    }

    [HttpGet("api/merchant")]
    [SwaggerOperation(
        Summary = "List Merchants",
        Description = "List Merchants",
        OperationId = "Merchant.List",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override async Task<ActionResult<ListMerchantResponse>> HandleAsync(ListMerchantRequest request, CancellationToken cancellationToken = default)
    {
        var response = new ListMerchantResponse(request.CorrelationId());
        var filterSpec = new MerchantFilterSpecification(request.SearchString);

        int totalItems = await _itemRepository.CountAsync(filterSpec, cancellationToken);

        var pagedSpec = new MerchantFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize);

        var items = await _itemRepository.ListAsync(pagedSpec, cancellationToken);

        response.Merchants.AddRange(items.Select(_mapper.Map<MerchantDto>));
        foreach (MerchantDto item in response.Merchants)
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
