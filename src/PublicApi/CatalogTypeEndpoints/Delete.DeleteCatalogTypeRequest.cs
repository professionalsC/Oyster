namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class DeleteCatalogTypeRequest : BaseRequest
{
    //[FromRoute]
    public int CatalogTypeId { get; set; }
}
