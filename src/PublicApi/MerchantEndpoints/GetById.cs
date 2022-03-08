using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.MerchantEndpoints;

public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdMerchantRequest>
    .WithResponse<GetByIdMerchantResponse>
{
    private readonly IRepository<Merchant> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public GetById(IRepository<Merchant> itemRepository, IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpGet("api/merchants/{MerchantId}")]
    [SwaggerOperation(
        Summary = "Get a Merchant by Id",
        Description = "Gets a Merchant by Id",
        OperationId = "merchants.GetById",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdMerchantResponse>> HandleAsync(GetByIdMerchantRequest request, CancellationToken cancellationToken = default)
    {
        var response = new GetByIdMerchantResponse(request.CorrelationId());

        var item = await _itemRepository.GetByIdAsync(request.MerchantId, cancellationToken);
        if (item is null) return NotFound();

        response.Merchant = new MerchantDto
        {
            Id = item.Id,
            Name = item.Name,
            PictureUri = _uriComposer.ComposePicUri(item.PictureUri),
            CountryId = item.CountryId,
            ProvinceId = item.ProvinceId,
            DistrictId = item.DistrictId,
            City   = item.City,
            StreetAddress = item.StreetAddress,
            ContactNumber = item.ContactNumber,
            Email = item.Email, 
            Website = item.Website,
            Status=item.Status,
        };
        return Ok(response);
    }
}
