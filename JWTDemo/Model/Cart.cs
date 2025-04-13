using System.ComponentModel.DataAnnotations;

namespace JWTDemo.Model
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime CreatedAt { get; set; }
    }
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
