using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Exceptions;
using Oyster.ApplicationCore.Interfaces;
using Oyster.ApplicationCore.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class Create : BaseAsyncEndpoint
    .WithRequest<CreateBannerAdvertisementRequest>
    .WithResponse<CreateBannerAdvertisementResponse>
{
    private readonly IRepository<BannerAdvertisement> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<BannerAdvertisement> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/banneradvertisement")]
    [SwaggerOperation(
        Summary = "Creates a new ResourceModule",
        Description = "Creates a new ResourceModule",
        OperationId = "resourcemodule.create",
        Tags = new[] { "ModuleEndPoints" })
    ]
    public override async Task<ActionResult<CreateBannerAdvertisementResponse>> HandleAsync(CreateBannerAdvertisementRequest request, CancellationToken cancellationToken = default)
    {
        var response = new CreateBannerAdvertisementResponse(request.CorrelationId());

        var bannerAdvertisementSpecification = new BannerAdvertisementTitleSpecification(request.Title);
        var existingResourceModule = await _itemRepository.CountAsync(bannerAdvertisementSpecification, cancellationToken);
        if (existingResourceModule > 0)
        {
            throw new DuplicateException($"A resourcemodule with name {request.Title} already exists");
        }

        var newItem = new BannerAdvertisement(request.Title, request.ImageUrl, request.Status);
        newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

        if (newItem.Id != 0)
        {

            newItem.UpdateImageUri(request.ImageUrl);
            await _itemRepository.UpdateAsync(newItem, cancellationToken);
        }

        var dto = new BannerAdvertisementDto
        {
            Id = newItem.Id,
            Title = newItem.Title,
            ImageUrl = _uriComposer.ComposePicUri(newItem.ImageUrl),
            Status = newItem.Status,
        };
        response.BannerAdvertisment = dto;
        return response;
    }
}
