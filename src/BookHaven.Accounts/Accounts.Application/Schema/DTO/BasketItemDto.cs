using BookHaven.Orders.Application.Shema.DTO;

namespace BookHaven.Accounts.Application.Schema.DTO
{
    public record BasketItemDto
    {
        public BookPublicationDto Publication { get; set; }
        public int Amount { get; set; }
    }
}
