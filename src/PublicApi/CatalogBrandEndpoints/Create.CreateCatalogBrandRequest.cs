namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class CreateCatalogBrandRequest:BaseRequest
{
    public string Brand { get; set; }
    public string PictureUri { get; set; }
    public string PictureBase64 { get; set; }
    public string PictureName { get; set; }
}
