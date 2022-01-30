using System;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class DeleteCatalogBrandResponse : BaseResponse
{
    public DeleteCatalogBrandResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteCatalogBrandResponse()
    {
    }

    public string Status { get; set; } = "Deleted";
}
