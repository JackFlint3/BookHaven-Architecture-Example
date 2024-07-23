using BookHaven.Accounts.Application.Schema.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto email);
    }
}
