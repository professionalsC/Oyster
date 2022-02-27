namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class CreateCatalogTypeRequest : BaseRequest
{
    public string Type { get; private set; }
    public string PictureUri { get; private set; }
    public string BannerPictureUri { get; private set; }
    public string Description { get; set; }
    public int ParentCatalogTypeId { get; set; }
    public bool Status { get; set; }
}
