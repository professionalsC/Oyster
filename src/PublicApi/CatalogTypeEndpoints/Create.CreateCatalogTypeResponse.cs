using System;

namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class CreateCatalogTypeResponse : BaseResponse
{
    public CreateCatalogTypeResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateCatalogTypeResponse()
    {
    }

    public CatalogTypeDto CatalogType { get; set; }
}
