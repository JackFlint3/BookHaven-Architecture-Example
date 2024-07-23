using BookHaven.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }

    }
}
