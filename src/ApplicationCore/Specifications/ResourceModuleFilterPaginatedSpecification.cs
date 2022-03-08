﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class ResourceModuleFilterPaginatedSpecification : Specification<ResourceModule>
{
    public ResourceModuleFilterPaginatedSpecification(int skip, int take)
        : base()
    {
        if (take == 0)
        {
            take = int.MaxValue;
        }
        Query.Skip(skip).Take(take);
    }
}
