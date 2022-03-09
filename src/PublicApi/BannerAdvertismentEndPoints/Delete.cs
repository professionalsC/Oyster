using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteBannerAdvertisementRequest>
    .WithResponse<DeleteBannerAdvertisementResponse>
{
    private readonly IRepository<BannerAdvertisement> _itemRepository;

    public Delete(IRepository<BannerAdvertisement> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpDelete("api/banneradvertisement/{ResourceModuleId}")]
    [SwaggerOperation(
        Summary = "Deletes a BannerAdvertisement",
        Description = "Deletes a BannerAdvertisement",
        OperationId = "banneradvertisement.Delete",
        Tags = new[] { "BannerAdvertismentEndPoints" })
    ]
    public override async Task<ActionResult<DeleteBannerAdvertisementResponse>> HandleAsync(DeleteBannerAdvertisementRequest request, CancellationToken cancellationToken = default)
    {
        var response = new DeleteBannerAdvertisementResponse(request.CorrelationId());

        var itemToDelete = await _itemRepository.GetByIdAsync(request.BannerAdvertismentId, cancellationToken);
        if (itemToDelete is null) return NotFound();

        await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

        return Ok(response);
    }
}
