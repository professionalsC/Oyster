using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.MerchantEndpoints;

public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteMerchantRequest>
    .WithResponse<DeleteMerchantResponse>
{
    private readonly IRepository<Merchant> _itemRepository;

    public Delete(IRepository<Merchant> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpDelete("api/merchant/{MerchantId}")]
    [SwaggerOperation(
        Summary = "Deletes a merchant",
        Description = "Deletes a Merchant",
        OperationId = "Merchant.Delete",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override async Task<ActionResult<DeleteMerchantResponse>> HandleAsync(DeleteMerchantRequest request, CancellationToken cancellationToken = default)
    {
        var response = new DeleteMerchantResponse(request.CorrelationId());

        var itemToDelete = await _itemRepository.GetByIdAsync(request.MerchantId, cancellationToken);
        if (itemToDelete is null) return NotFound();

        await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

        return Ok(response);
    }
}
