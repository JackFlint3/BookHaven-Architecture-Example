using BookHaven.Core.Domain.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Domain.Entities
{
    public class DownloadDelivery : Delivery
    {
        public override bool Accepts(ISBN iSBN)
        {
            if (iSBN is EPUB || iSBN is PDF)
                return true;

            return false;
        }
    }
}
