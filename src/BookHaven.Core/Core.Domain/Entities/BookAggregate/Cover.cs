using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Domain.Entities.BookAggregate
{
    public record Cover
    {
        public string Text { get; set; }
        public string Art { get; set; }
    }
}
