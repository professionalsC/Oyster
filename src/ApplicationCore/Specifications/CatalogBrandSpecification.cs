using System;
using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;

internal class CatalogBrandSpecification : Specification<CatalogBrand>
{
    public CatalogBrandSpecification(params int[] ids)
    {
        Query.Where(c => ids.Contains(c.Id));
    }
}
