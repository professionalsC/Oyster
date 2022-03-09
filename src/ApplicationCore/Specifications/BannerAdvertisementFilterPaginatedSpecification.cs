using System.Linq;
using Ardalis.Specification;
using Oyster.ApplicationCore.Entities;

namespace Oyster.ApplicationCore.Specifications;
public class BannerAdvertisementFilterPaginatedSpecification : Specification<BannerAdvertisement>
{
    public BannerAdvertisementFilterPaginatedSpecification(int skip, int take)
        : base()
    {
        if (take == 0)
        {
            take = int.MaxValue;
        }
        Query.Skip(skip).Take(take);
    }
}
