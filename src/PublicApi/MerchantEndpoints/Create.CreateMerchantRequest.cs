namespace Oyster.PublicApi.MerchantEndpoints;

public class CreateMerchantRequest:BaseRequest
{
    public string Name { get; private set; }
    public string PictureUri { get; private set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }
    public int DistrictId { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public bool Status { get; set; }
}
