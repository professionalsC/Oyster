using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;

public class CatalogItemNameSpecification : Specification<CatalogItem>
{
    public CatalogItemNameSpecification(string catalogItemName)
    {
        Query.Where(item => catalogItemName == item.Name);
    }
}
