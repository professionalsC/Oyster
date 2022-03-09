using System;

namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class CreateBannerAdvertisementResponse:BaseResponse
{   
    public CreateBannerAdvertisementResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateBannerAdvertisementResponse()
    {
    }

    public BannerAdvertisementDto BannerAdvertisment { get; set; }
}
