﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class BannerAdvertisementSpecification : Specification<BannerAdvertisement>
{
    public BannerAdvertisementSpecification(string title)
    {
        Query
            .Where(b => b.Title == title);
    }

}
