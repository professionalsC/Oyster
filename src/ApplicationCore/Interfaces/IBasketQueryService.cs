using System.Threading.Tasks;

namespace Oyster.ApplicationCore.Interfaces;

public interface IBasketQueryService
{
    Task<int> CountTotalBasketItems(string username);
}
