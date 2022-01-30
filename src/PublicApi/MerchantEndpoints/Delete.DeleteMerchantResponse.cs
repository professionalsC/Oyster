using System;

namespace Oyster.PublicApi.MerchantEndpoints;

public class DeleteMerchantResponse:BaseResponse
{
    public DeleteMerchantResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteMerchantResponse()
    {
    }

    public string Status { get; set; } = "Deleted";
}
