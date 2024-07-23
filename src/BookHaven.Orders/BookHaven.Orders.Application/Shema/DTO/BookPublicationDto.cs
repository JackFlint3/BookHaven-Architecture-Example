using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Application.Shema.DTO
{
    public record BookPublicationDto
    {
        public string ISBN { get; set; }
    }
}
