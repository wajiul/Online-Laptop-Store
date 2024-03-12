using LaptopStoreAPI.Persistence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private const string cartName = "cart";

        [HttpGet]
        public ActionResult Get()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>(cartName);
            return Ok(cart ?? new ShoppingCart());
        }
        [HttpPost("add")]
        public IActionResult AddToCart([FromBody] Product product)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>(cartName) ?? new ShoppingCart();
            cart.AddProduct(product);
            HttpContext.Session.SetObjectAsJson(cartName, cart);
            return Ok();
        }

        [HttpPost("increase/{productId}")]
        public IActionResult IncreaseProductCount(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>(cartName);
            if (cart == null)
                return NotFound("Shopping cart not found");
            var product = cart.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound("Product is not found on cart");

            product.Quantity++;
            HttpContext.Session.SetObjectAsJson(cartName, cart);
            return Ok();
        }


        [HttpPost("decrease/{productId}")]
        public IActionResult DecreaseProductCount(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>(cartName);
            if (cart == null)
                return NotFound("Shopping cart not found");

            cart.InceraseProduct(productId);

            HttpContext.Session.SetObjectAsJson(cartName, cart);
            return Ok();
        }

    }

    public static class SessionExtensions
    {
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
