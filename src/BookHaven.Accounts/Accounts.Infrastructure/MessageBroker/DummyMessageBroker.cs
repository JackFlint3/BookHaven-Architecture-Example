using BookHaven.Accounts.Application.Interfaces;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Infrastructure.MessageBroker
{
    internal class DummyMessageBroker : IMessageBroker
    {
        public Task<bool> AuthenticateNumberAsync(string number) => Task.FromResult(int.TryParse(number, out _));
        public Task<bool> VerifyNumberAsync(string number) => Task.FromResult(int.TryParse(number, out _));
    }
}
