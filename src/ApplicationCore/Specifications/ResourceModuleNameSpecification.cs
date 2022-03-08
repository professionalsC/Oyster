using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class ResourceModuleNameSpecification : Specification<ResourceModule>
{
    public ResourceModuleNameSpecification(string name)
    {
        Query
            .Where(b => b.Name == name);
    }

}
