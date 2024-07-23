using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Application.Schema.DTO;
using BookHaven.Accounts.Domain.Entities;
using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Services
{
    public class AccountService : IAccountService
    {
        public required IRequestingUserAccessor RequestingUserAccessor { get; set; }
        public required IMessageBroker MessageBroker { get; set; }
        public required IUnitOfWorkFactory<IAccountUnitOfWork> UnitOfWorkFactory { get; set; }

        public AccountService(IRequestingUserAccessor requestingUserAccessor, IMessageBroker messageBroker, IUnitOfWorkFactory<IAccountUnitOfWork> unitOfWorkFactory)
        {
            RequestingUserAccessor = requestingUserAccessor ?? throw new ArgumentNullException(nameof(requestingUserAccessor));
            MessageBroker = messageBroker ?? throw new ArgumentNullException(nameof(messageBroker));
            UnitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        public async Task Enable2FA(string phonenumber)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            var account = await RequestingUserAccessor.GetRequestingUserAsync();
            await Enable2FAForAccount(phonenumber, account);
            await unitOfWork.AccountRepository.UpdateAsync(account);

            await unitOfWork.CommitAsync();
        }

        async Task Enable2FAForAccount(string phonenumber, Account account)
        {
            if (!await MessageBroker.VerifyNumberAsync(phonenumber))
                throw new Exception($"Failed to verify {nameof(phonenumber)}:'{phonenumber}'");

            account.Phone = new Phonenumber() with { Value = phonenumber };
        }

        public async Task EnablePurchases(AddressDto address)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            var account = await RequestingUserAccessor.GetRequestingUserAsync();
            await EnablePurachsesForAccountAsync(address, account);
            await unitOfWork.AccountRepository.UpdateAsync(account);

            await unitOfWork.CommitAsync();
        }

        Task EnablePurachsesForAccountAsync(AddressDto address, Account account)
        {
            // Address validation would start here

            account.Address = new Address()
            {
                City = address.City,
                HouseAddress = address.HouseAddress,
                StreetName = address.StreetName
            };

            return Task.CompletedTask;
        }

        public async Task LoginAsync(AccountLoginDto accountLogin)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            var probingAccount = unitOfWork.AccountRepository.FindAsEnumerable(a => a.Key.Equals(accountLogin.EMail)).FirstOrDefault();
            if (probingAccount == null || !probingAccount.MatchesPassword(accountLogin.Password))
                throw new Exception("Invalid Email or Password provided");

            if (probingAccount.Is2FAEnabled)
                if (!await MessageBroker.AuthenticateNumberAsync(probingAccount.Phone.Value))
                    throw new Exception("Access to account could not be verified");

            await RequestingUserAccessor.SetRequestingUserAsync(probingAccount);
        }

        public async Task RegisterAsync(RegistrationDto registration)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            if (registration.EMail is null)
                throw new Exception("Email cannot be null");

            var existingAccount = unitOfWork.AccountRepository.FindAsEnumerable(a => a.Key.Equals(registration.EMail)).FirstOrDefault();
            if (existingAccount is not null)
                throw new Exception($"Account with email '{registration.EMail}' already exists.");

            if (registration.Password is null)
                throw new Exception("Password cannot be null");

            Account newAccount = new(Email.FromString(registration.EMail), registration.Password);

            if (registration.Address is not null)
                await EnablePurachsesForAccountAsync(registration.Address, newAccount);

            if (registration.Phonenumber is not null)
                await Enable2FAForAccount(registration.Phonenumber, newAccount);

            await unitOfWork.AccountRepository.UpdateAsync(newAccount);

            await unitOfWork.CommitAsync();
        }
    }
}
