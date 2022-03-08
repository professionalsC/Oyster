using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class ResourceModuleSpecification : Specification<ResourceModule>
{
    public ResourceModuleSpecification(params int[] ids)
    {
        Query.Where(c => ids.Contains(c.Id));
    }
}
