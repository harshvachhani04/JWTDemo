using JWTDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public interface ICartRepository
    {
        Task<bool> AddCart(UserDemo user, CartItemDTO cartItem);
    }
    public class CartSQLRepository : ICartRepository
    {
        public ILogger<ICartRepository> _logger { get; }
        public AppDbContext _context { get; }
        public CartSQLRepository(ILogger<ICartRepository> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<bool> AddCart(UserDemo user, CartItemDTO cartItem)
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.UserId);
                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = user.UserId,
                        Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                        }
                    }
                    };
                    await _context.Carts.AddAsync(cart);
                }
                else
                {
                    var item = cart.Items.FirstOrDefault(c => c.ProductId == cartItem.ProductId);
                    if (item != null)
                    {
                        item.Quantity += cartItem.Quantity;
                        _context.CartItems.Update(item);
                    }
                    else
                    {
                        var newCartItems = new CartItem
                        {
                            CartId = cart.CartId,
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity
                        };
                        await _context.AddAsync(newCartItems);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in add cart {ex}");
                return false;
            }
            return true;
        }
    }
}
