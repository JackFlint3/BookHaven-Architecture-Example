using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Application.Schema.DTO;
using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Application.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Services
{
    public class ShopService : IShopService
    {
        public required IRequestingUserAccessor UserAccessor { get; set; }
        public required IUnitOfWorkFactory<IShopUnitOfWork> UnitOfWorkFactory { get; set; }

        public ShopService(IRequestingUserAccessor userAccessor, IUnitOfWorkFactory<IShopUnitOfWork> unitOfWorkFactory)
        {
            UserAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            UnitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        public async Task AddToBasketAsync(BasketItemDto basketItem)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            if (basketItem.Amount <= 0)
                throw new Exception("Amount to be added to basket has to be greater 0");

            var account = await UserAccessor.GetRequestingUserAsync() 
                ?? throw new Exception("User has to be logged in");

            var book = await unitOfWork.BookRepository.GetByISBNAsync(basketItem.Publication.ISBN) 
                ?? throw new Exception($"Could not find a Book with ISBN of '{basketItem.Publication.ISBN}'");

            var isbn = book.Publications.FirstOrDefault(p => p.ToString() == basketItem.Publication.ISBN)
                ?? throw new Exception("Unknown Error Occured: ISBN not found");

            account.AddBookToBasket(isbn, basketItem.Amount);

            await unitOfWork.AccountRepository.UpdateAsync(account);
            unitOfWork.Commit();
        }

        public async Task PurchaseBooksAsync()
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            var account = await UserAccessor.GetRequestingUserAsync();
            if (account is null)
                throw new Exception("User has to be logged in");

            if (!account.CanPurchase)
                throw new Exception("Cannot place an order without specifying an address");

            var order = account.PlaceOrder();
            await unitOfWork.OrderRepository.CreateAsync(order);
            await unitOfWork.AccountRepository.UpdateAsync(account);

            unitOfWork.Commit();
        }
    }
}
