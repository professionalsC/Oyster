using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;

public class CatalogBrandNameSpecification :  Specification<CatalogBrand>
{
    public CatalogBrandNameSpecification(string brand)
    {
        Query
            .Where(b => b.Brand == brand);
    }

    
}
