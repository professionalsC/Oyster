using System;

namespace Oyster.PublicApi.MerchantEndpoints;

public class GetByIdMerchantResponse : BaseResponse
{
    public GetByIdMerchantResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdMerchantResponse()
    {
    }

    public MerchantDto Merchant { get; set; }
}
