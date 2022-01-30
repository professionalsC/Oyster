using System;

namespace Oyster.PublicApi.MerchantEndpoints;

public class CreateMerchantResponse:BaseResponse
{
    public CreateMerchantResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateMerchantResponse()
    {
    }

    public MerchantDto CatalogItem { get; set; }
}
