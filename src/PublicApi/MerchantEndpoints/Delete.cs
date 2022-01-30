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
    private readonly IRepository<Merchant> _merchantRepository;

    public Delete(IRepository<Merchant> merchantRepository)
    {
        _merchantRepository = merchantRepository;
    }

    [HttpDelete("api/merchant/{MerchantId}")]
    [SwaggerOperation(
        Summary = "Deletes a merchant",
        Description = "Deletes a Merchant",
        OperationId = "Merchant.Delete",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override Task<ActionResult<DeleteMerchantResponse>> HandleAsync(DeleteMerchantRequest request, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}
