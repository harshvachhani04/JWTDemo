namespace JWTDemo.Data
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ResultDTO
    {
        public int Result { get; set; }
        public Enums.Status Status { get; set; }
    }
    public class CartItemDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
