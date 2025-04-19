using JWTDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTDemo.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        public ILogger<CartController> _logger { get; }
        public ICartRepository _cartRepository { get; }
        public CartController(ILogger<CartController> logger, ICartRepository cartRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
        }
        [Authorize]
        [Route("AddCartItem")]
        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody]CartItemDTO cartItem)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var isSucess = await _cartRepository.AddCart(userId, cartItem);
            if (isSucess)
                return Ok(isSucess);
            return NotFound();
        }
        [Authorize]
        [Route("GetCartItems")]
        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cartItems = await _cartRepository.GetCartItems(userId);
            return Ok(cartItems);
        }
    }
}
