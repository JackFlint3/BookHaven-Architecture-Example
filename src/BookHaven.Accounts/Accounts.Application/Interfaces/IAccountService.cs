using BookHaven.Accounts.Application.Schema.DTO;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegistrationDto registration);
        Task LoginAsync(AccountLoginDto accountLogin);
        Task Enable2FA(string phonenumber);
        Task EnablePurchases(AddressDto address);
    }
}
