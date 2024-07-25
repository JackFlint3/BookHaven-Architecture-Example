using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Application.Schema.DTO;
using BookHaven.Orders.Application.Shema.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookHaven.UI.AspNetCore.API.Accounts
{
    [ApiController]
    [Route("api/1.0/[controller]/")]
    public class ShopController : ControllerBase
    {
        IShopService ShopService { get; set; }

        public ShopController(IShopService shopService)
        {
            ShopService = shopService;
        }

        [HttpPut("Basket/{ISBN}")]
        public Task PutInBasket([FromRoute(Name = "ISBN")]string id) 
        {
            return ShopService.AddToBasketAsync(new BasketItemDto() { Amount = 1, Publication = new BookPublicationDto { ISBN = id } });
        }

        [HttpPost("Basket/Purachse")]
        public Task Purchase()
        {
            return ShopService.PurchaseBooksAsync();
        }
    }
}
