using BookHaven.Core.Domain.Entities.BookAggregate;

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
