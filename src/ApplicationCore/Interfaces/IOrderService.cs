using System.Threading.Tasks;
using Oyster.ApplicationCore.Entities.OrderAggregate;

namespace Oyster.ApplicationCore.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
}
