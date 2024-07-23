using BookHaven.Accounts.Domain.Entities;
using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Domain.Entities;
using BookHaven.Core.Domain.Intefaces;
using System;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IAccountRepository : ICQUDRepository<Account, Email>
    {
    }
}
