using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;

public class CatalogTypeFilterSpecification : Specification<CatalogType>
{
    public CatalogTypeFilterSpecification(string? searchType)
    {
        Query.Where(i =>  i.Type == searchType);
    }
}
