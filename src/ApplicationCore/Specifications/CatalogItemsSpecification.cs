using System;
using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;

public class CatalogItemsSpecification : Specification<CatalogItem>
{
    public CatalogItemsSpecification(params int[] ids)
    {
        Query.Where(c => ids.Contains(c.Id));
    }
}
