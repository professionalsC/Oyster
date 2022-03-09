using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class BannerAdvertisementTitleSpecification : Specification<BannerAdvertisement>
{
    public BannerAdvertisementTitleSpecification(string title)
    {
        Query
            .Where(b => b.Title == title);
    }


}

