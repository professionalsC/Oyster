namespace Oyster.PublicApi.BannerAdvertismentEndPoints;

public class ListBannerAdvertisementRequest:BaseRequest
{
    public string SortOrder { get; set; }
    public string SearchString { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

}
