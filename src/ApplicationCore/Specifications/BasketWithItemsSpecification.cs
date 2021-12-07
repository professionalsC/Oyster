using Ardalis.Specification;
using Oyster.ApplicationCore.Entities.BasketAggregate;

namespace Oyster.ApplicationCore.Specifications;

public sealed class BasketWithItemsSpecification : Specification<Basket>, ISingleResultSpecification
{
    public BasketWithItemsSpecification(int basketId)
    {
        Query
            .Where(b => b.Id == basketId)
            .Include(b => b.Items);
    }

    public BasketWithItemsSpecification(string buyerId)
    {
        Query
            .Where(b => b.BuyerId == buyerId)
            .Include(b => b.Items);
    }
}
