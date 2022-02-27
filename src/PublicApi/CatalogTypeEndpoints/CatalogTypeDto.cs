namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class CatalogTypeDto
{
    public int Id { get; set; }
    public string Type { get;  set; }
    public string PictureUri { get;  set; }
    public string BannerPictureUri { get;  set; }
    public string Description { get; set; }
    public int ParentCatalogTypeId { get; set; }
    public bool Status { get; set; }

}
