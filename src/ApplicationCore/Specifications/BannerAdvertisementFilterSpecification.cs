using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class BannerAdvertisementFilterSpecification : Specification<BannerAdvertisement>
{
    public BannerAdvertisementFilterSpecification(string title)
    {
        Query
            .Where(b => b.Title == title);
    }
}
