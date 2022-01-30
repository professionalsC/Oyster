using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.MerchantEndpoints;

public class Create : BaseAsyncEndpoint
    .WithRequest<CreateMerchantRequest>
    .WithResponse<CreateMerchantResponse>
{
    private readonly IRepository<Merchant> _merchantRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<Merchant> merchantRepository,
        IUriComposer uriComposer)
    {
        _merchantRepository = merchantRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/merchant")]
    [SwaggerOperation(
        Summary = "Creates a new Merchant",
        Description = "Creates a new Merchant",
        OperationId = "merchant.create",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override Task<ActionResult<CreateMerchantResponse>> HandleAsync(CreateMerchantRequest request, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}
