using System.ComponentModel.DataAnnotations;

namespace JWTDemo.Model
{
    public class UserDemo
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
