using JWTDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace JWTDemo.Data
{
    public interface ICartRepository
    {
        Task<bool> AddCart(int userId, CartItemDTO cartItem);
        Task<List<CartDTO>> GetCartItems(int userId);
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
        public async Task<bool> AddCart(int userId, CartItemDTO cartItem)
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = userId,
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

        public async Task<List<CartDTO>> GetCartItems(int userId)
        {
            List<CartDTO> itemList = new List<CartDTO>();
            try
            {
                var cart = await _context.Carts.Where(c => c.UserId == userId).Include(c => c.Items).ThenInclude(o => o.Product).FirstOrDefaultAsync();
                if(cart != null)
                {
                    itemList = cart.Items.Select(i => new CartDTO
                    {
                        ProductId = i.ProductId,
                        ProductName = i.Product.ProductName,
                        Quantity = i.Quantity
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetCartItems {ex}");
            }
            return itemList;
        }
    }
}
