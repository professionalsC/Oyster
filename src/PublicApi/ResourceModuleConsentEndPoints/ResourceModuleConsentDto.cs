namespace Oyster.PublicApi.ResourceModuleConsentEndPoints;

public class ResourceModuleConsentDto
{
    public int Id { get; set; }
    public string Role { get; set; }
    public int ResourceModuleId { get; set; }
    public bool IsViewConsent { get; set; }
    public bool IsUpdateConsent { get; set; }
    public bool IsDeleteConsent { get; set; }
}
