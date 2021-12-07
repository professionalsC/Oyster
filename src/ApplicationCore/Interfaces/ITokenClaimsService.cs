using System.Threading.Tasks;

namespace Oyster.ApplicationCore.Interfaces;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
}
