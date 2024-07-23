using BookHaven.Core.Domain.Entities.BookAggregate;

namespace BookHaven.Orders.Domain.Entities
{
    public class BasketItem
    {
        public int Amount { get; set; }
        public ISBN Publication { get; set; }
    }
}
