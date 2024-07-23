using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Schema.DTO
{
    public record EmailDto
    {
        public required string Email { get; set; }
        public required string Content { get; set; }
    }
}
