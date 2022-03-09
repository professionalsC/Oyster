using System;

namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class DeleteBannerAdvertisementResponse:BaseResponse
{
    public DeleteBannerAdvertisementResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteBannerAdvertisementResponse()
    {
    }

    public string Status { get; set; } = "Deleted";
}
