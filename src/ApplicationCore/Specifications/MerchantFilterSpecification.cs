using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class MerchantFilterSpecification : Specification<Merchant>
{
    public MerchantFilterSpecification(string name)
    {
        Query.Where(b => b.Name == name);
    }

}
