using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTDemo.Model
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    [Table("CartItem")]
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
