using System;
using System.Collections.Generic;

namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class ListBannerAdvertisementResponse:BaseResponse
{
    public ListBannerAdvertisementResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListBannerAdvertisementResponse()
    {
    }

    public List<BannerAdvertisementDto> BannerAdvertisements { get; set; } = new List<BannerAdvertisementDto>();
    public int PageCount { get; set; }
}
