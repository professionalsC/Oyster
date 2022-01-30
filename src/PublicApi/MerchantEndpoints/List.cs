using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.MerchantEndpoints;

public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<ListMerchantResponse>
{
    private readonly IRepository<Merchant> _merchantRepository;
    private readonly IMapper _mapper;

    public List(IRepository<Merchant> merchantRepository,
        IMapper mapper)
    {
        _merchantRepository = merchantRepository;
        _mapper = mapper;
    }

    [HttpGet("api/merchant")]
    [SwaggerOperation(
        Summary = "List Merchants",
        Description = "List Merchants",
        OperationId = "Merchant.List",
        Tags = new[] { "MerchantEndpoints" })
    ]
    public override Task<ActionResult<ListMerchantResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}
