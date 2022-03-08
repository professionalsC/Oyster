using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Exceptions;
using Oyster.ApplicationCore.Interfaces;
using Oyster.ApplicationCore.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.MerchantEndpoints;

public class Create : BaseAsyncEndpoint
    .WithRequest<CreateMerchantRequest>
    .WithResponse<CreateMerchantResponse>
{
    private readonly IRepository<Merchant> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<Merchant> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/merchant")]
    [SwaggerOperation(
        Summary = "Creates a new Merchant",
        Description = "Creates a new Merchant",
        OperationId = "merchant.create",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override async Task<ActionResult<CreateMerchantResponse>> HandleAsync(CreateMerchantRequest request, CancellationToken cancellationToken = default)
    {
        var response = new CreateMerchantResponse(request.CorrelationId());

        var merchantNameSpecification = new MerchantNameSpecification(request.Name);
        var existingMerchant = await _itemRepository.CountAsync(merchantNameSpecification, cancellationToken);
        if (existingMerchant > 0)
        {
            throw new DuplicateException($"A catalogBrand with name {request.Name} already exists");
        }

        var newItem = new Merchant(request.Name, request.PictureUri, request.CountryId, request.ProvinceId, request.DistrictId, request.City, request.StreetAddress,
                                        request.Website,request.Email,request.ContactNumber,request.Status);
        await _itemRepository.AddAsync(newItem, cancellationToken);

        if (newItem.Id != 0)
        {
            //We disabled the upload functionality and added a default/placeholder image to this sample due to a potential security risk 
            //  pointed out by the community. More info in this issue: https://github.com/dotnet-architecture/oyster/issues/537 
            //  In production, we recommend uploading to a blob storage and deliver the image via CDN after a verification process.

            newItem.UpdatePictureUri(request.PictureUri);
            await _itemRepository.UpdateAsync(newItem, cancellationToken);
        }

        var dto = new MerchantDto
        {
            Id = newItem.Id,
            Name = newItem.Name,
            PictureUri = _uriComposer.ComposePicUri(newItem.PictureUri),
            CountryId = newItem.CountryId,
            ProvinceId = newItem.ProvinceId,
            DistrictId = newItem.DistrictId,
            City = newItem.City,
            StreetAddress = newItem.StreetAddress,
            Website = newItem.Website,
            Email = newItem.Email,
            ContactNumber = newItem.ContactNumber,
            Status = newItem.Status,
        };
        response.Merchant = dto;
        return response;
    }
}
