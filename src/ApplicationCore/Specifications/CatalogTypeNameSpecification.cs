using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;

public class CatalogTypeNameSpecification : Specification<CatalogType>
{
    public CatalogTypeNameSpecification(string type)
    {
        Query
            .Where(b => b.Type == type);
    }


}
