using InternAPI.Context;
using InternAPI.Interface;
using InternAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace InternAPI.Services
{
    public class UserRepo : IRepo<int, User>
    {
        private readonly UserContext _context;
        private readonly ILogger<UserRepo> _logger;

        public UserRepo(UserContext context, ILogger<UserRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User?> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<User?> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User?> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == key);
            return user;
        }

        public async Task<ICollection<User>?> GetAll()
        {
            var interns = await _context.Users.ToListAsync();
            if (interns.Count > 0)
                return interns;
            return null;
        }

        public async Task<User?> Update(User item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                user.Role = item.Role;
                user.PasswordHash = item.PasswordHash;
                user.PasswordKey = item.PasswordKey;
                if (user.Status == "Not Approved")
                {   
                   user.Status = "Approved";                 
                }
                await _context.SaveChangesAsync();
                return user;

            }
            return null;
        }
    }
}
