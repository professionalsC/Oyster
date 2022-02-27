﻿namespace Oyster.PublicApi.CatalogTypeEndpoints;

public class ListCatalogTypesRequest : BaseRequest
{
    public string SortOrder { get; set; }
    public string SearchString { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
