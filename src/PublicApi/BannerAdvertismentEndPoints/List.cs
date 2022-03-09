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

namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class List : BaseAsyncEndpoint
    .WithRequest<ListBannerAdvertisementRequest>
    .WithResponse<ListBannerAdvertisementResponse>
{
    private readonly IRepository<BannerAdvertisement> _itemRepository;
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public List(IRepository<BannerAdvertisement> itemRepository,
    IUriComposer uriComposer,
    IMapper mapper)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    [HttpGet("api/banneradvertisement")]
    [SwaggerOperation(
        Summary = "List BannerAdvertisement",
        Description = "List Banner Advertisement",
        OperationId = "banneradvertisement.List",
        Tags = new[] { "BannerAdvertismentEndPoints" })
    ]
    public override async Task<ActionResult<ListBannerAdvertisementResponse>> HandleAsync(ListBannerAdvertisementRequest request, CancellationToken cancellationToken = default)
    {
        var response = new ListBannerAdvertisementResponse(request.CorrelationId());
        var filterSpec = new BannerAdvertisementFilterSpecification(request.SearchString);

        int totalItems = await _itemRepository.CountAsync(filterSpec, cancellationToken);

        var pagedSpec = new BannerAdvertisementFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize);

        var items = await _itemRepository.ListAsync(pagedSpec, cancellationToken);

        response.BannerAdvertisements.AddRange(items.Select(_mapper.Map<BannerAdvertisementDto>));
        foreach (BannerAdvertisementDto item in response.BannerAdvertisements)
        {
            item.ImageUrl = _uriComposer.ComposePicUri(item.ImageUrl);
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
