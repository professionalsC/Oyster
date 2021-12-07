using Microsoft.AspNetCore.Mvc;

namespace Oyster.PublicApi.CatalogItemEndpoints;

public class DeleteCatalogItemRequest : BaseRequest
{
    //[FromRoute]
    public int CatalogItemId { get; set; }
}
