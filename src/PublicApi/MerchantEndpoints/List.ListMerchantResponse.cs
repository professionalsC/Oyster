using System;
using System.Collections.Generic;

namespace Oyster.PublicApi.MerchantEndpoints;

public class ListMerchantResponse : BaseResponse
{
    public ListMerchantResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListMerchantResponse()
    {
    }

    public List<MerchantDto> Merchants { get; set; } = new List<MerchantDto>();
    public int PageCount { get; set; }

}
