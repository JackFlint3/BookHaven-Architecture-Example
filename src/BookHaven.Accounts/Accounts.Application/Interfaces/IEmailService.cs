using BookHaven.Accounts.Application.Schema.DTO;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto email);
    }
}
