using System;
using System.Collections.Generic;
using Oyster.ApplicationCore.Extensions;

namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class ListCatalogTypesResponse : BaseResponse
{
    public ListCatalogTypesResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListCatalogTypesResponse()
    {
    }

    public List<CatalogTypeDto> CatalogTypes { get; set; } = new List<CatalogTypeDto>();
    public int PageCount { get; set; }
}
