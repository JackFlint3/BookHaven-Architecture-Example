using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Application.Schema.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Infrastructure.Emails
{
    internal class DummyEmailService : IEmailService
    {
        // this is a stand-in service for what could be an email service
        public Task SendEmailAsync(EmailDto email)
        {
            return Task.CompletedTask;
        }
    }
}
