namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class CreateBannerAdvertisementRequest:BaseRequest
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}
