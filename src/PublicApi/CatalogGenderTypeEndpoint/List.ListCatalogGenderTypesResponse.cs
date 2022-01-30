using System;
using System.Collections.Generic;

namespace Oyster.PublicApi.CatalogGenderTypeEndpoint;

public class ListCatalogGenderTypesResponse : BaseResponse
{
    public ListCatalogGenderTypesResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListCatalogGenderTypesResponse()
    {
    }

    public List<CatalogGenderTypeDto> CatalogGenderTypes { get; set; } = new List<CatalogGenderTypeDto>();
}
