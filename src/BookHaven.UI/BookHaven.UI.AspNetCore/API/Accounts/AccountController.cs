using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Application.Schema.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookHaven.UI.AspNetCore.API.Accounts
{
    [ApiController]
    [Route("api/1.0/[controller]/")]
    public class AccountController : ControllerBase
    {
        IAccountService AccountService { get; set; }

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost("/register")]
        public Task Register([FromBody] RegistrationDto registrationDto)
        {
            return AccountService.RegisterAsync(registrationDto);
        }

        [HttpPost("/login")]
        public Task Login([FromBody] AccountLoginDto loginDto)
        {
            return AccountService.LoginAsync(loginDto);
        }

        [HttpPatch("/account/phone/{number}")]
        public Task Set2FA([FromRoute(Name = "number")] string number)
        {
            return AccountService.Enable2FA(number);
        }

        [HttpPatch("/account/address")]
        public Task SetAddress([FromBody] AddressDto address)
        {
            return AccountService.EnablePurchases(address);
        }
    }
}
