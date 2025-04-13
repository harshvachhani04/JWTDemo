using JWTDemo.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JWTDemo.Data
{
    public interface IUserRepository
    {
        Task<UserDemo> GetUserAsync(string username, string password);
        Task<List<UserDemo>> GetAllUsersAsync();
        Task<UserDemo> GetUserInfoAsync(int userId = -1, string username = "");
        Task<int> RegisterNewUserAsyc(UserDemo userDemo);
        Task<bool> DeleteUserAsync(UserDemo user);
        Task<bool> UpdateUserAsync(UserDemo userDemo);
        Task<bool> IsUserExistAsync(string username);
    }
    public class UserSQLRepository : IUserRepository
    {
        private readonly ILogger<IUserRepository> _logger;
        private readonly AppDbContext _context;

        public UserSQLRepository(ILogger<UserSQLRepository> logger, AppDbContext context)
        {
            _logger = logger;
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

        public async Task<UserDemo> GetUserInfoAsync(int userId = -1, string username = "")
        {
            if(userId > 0)
            {
                return await _context.TblUsers.FirstOrDefaultAsync(u => u.UserId == userId);
            }
            else if (username != null)
            {
                return await _context.TblUsers.FirstOrDefaultAsync(u => u.Username == username);
            }
            return null;
        }

        public async Task<int> RegisterNewUserAsyc(UserDemo userDemo)
        {
            try
            {
                await _context.TblUsers.AddAsync(userDemo);
                await _context.SaveChangesAsync();
                return userDemo.UserId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {ex}");
                return -1;
            }
        }

        public async Task<bool> DeleteUserAsync(UserDemo user)
        {
            try
            {
                _context.TblUsers.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {ex}");
                return false;
            }
        }
        public async Task<bool> UpdateUserAsync(UserDemo user)
        {
            try
            {
                UserDemo currentUserInfo = _context.TblUsers.FirstOrDefault(u => u.Username == user.Username);
                currentUserInfo.Username = user.Username;
                currentUserInfo.Password = user.Password;
                currentUserInfo.Role = user.Role;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateUserAsync {ex}");
                return false;
            }
        }
        public async Task<bool> IsUserExistAsync(string username)
        {
            try
            {
                var user = await _context.TblUsers.FirstOrDefaultAsync(u => u.Username == username);
                if (user != null)
                    return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in IsUserExist {ex}");
            }
            return false;
        }
    }
}
