using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class CatalogBrandFilterSpecification : Specification<CatalogBrand>
{
    public CatalogBrandFilterSpecification(string brand)
    {
        Query
            .Where(b => b.Brand == brand);
    }
}
