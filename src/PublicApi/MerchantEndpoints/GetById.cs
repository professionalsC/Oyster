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
    private readonly IRepository<Merchant> _merchantRepository;
    private readonly IUriComposer _uriComposer;

    public GetById(IRepository<Merchant> merchantRepository, IUriComposer uriComposer)
    {
        _merchantRepository = merchantRepository;
        _uriComposer = uriComposer;
    }

    [HttpGet("api/merchants/{MerchantId}")]
    [SwaggerOperation(
        Summary = "Get a Merchant by Id",
        Description = "Gets a Merchant by Id",
        OperationId = "merchants.GetById",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override Task<ActionResult<GetByIdMerchantResponse>> HandleAsync(GetByIdMerchantRequest request, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}
