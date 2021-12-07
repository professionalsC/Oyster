using System.Threading.Tasks;

namespace Oyster.ApplicationCore.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
