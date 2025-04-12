using JWTDemo.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public interface IUserRepository
    {
        Task<UserDemo> GetUserAsync(string username, string password);
        Task<List<UserDemo>> GetAllUsersAsync();
        Task<UserDemo> GetUserInfoAsync(int userId);
    }
    public class UserSQLRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserSQLRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserDemo> GetUserAsync(string username, string password)
        {
            return await _context.TblUsers.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<List<UserDemo>> GetAllUsersAsync()
        {
            return await _context.TblUsers.ToListAsync();
        }

        public async Task<UserDemo> GetUserInfoAsync(int userId)
        {
            return await _context.TblUsers.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
