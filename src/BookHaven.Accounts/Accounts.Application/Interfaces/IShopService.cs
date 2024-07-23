using BookHaven.Accounts.Application.Schema.DTO;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IShopService
    {
        Task AddToBasketAsync(BasketItemDto basketItem);
        Task PurchaseBooksAsync();
    }
}