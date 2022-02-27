using System;

namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class DeleteCatalogTypeResponse : BaseResponse
{
    public DeleteCatalogTypeResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteCatalogTypeResponse()
    {
    }

    public string Status { get; set; } = "Deleted";
}
