using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IMessageBroker
    {
        Task<bool> VerifyNumberAsync(string number);
        Task<bool> AuthenticateNumberAsync(string number);
    }
}
