namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class DeleteCatalogBrandRequest : BaseRequest
{
    //[FromRoute]
    public int CatalogBrandId { get; set; }
}
