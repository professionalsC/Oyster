namespace Oyster.PublicApi.MerchantEndpoints;

public class MerchantDto
{
    public int Id { get; set; }
    public string Name { get;  set; }
    public string PictureUri { get;  set; }
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
