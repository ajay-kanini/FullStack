using InternAPI.Context;
using InternAPI.Interface;
using InternAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternAPI.Services
{
    public class InternRepo : IRepo<int, Intern>
    {
        private readonly UserContext _context;
        private readonly ILogger<InternRepo> _logger;

        public InternRepo(UserContext context, ILogger<InternRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Intern> Add(Intern item)
        {
            try
            {
                _context.Interns.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Intern> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Interns.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<Intern> Get(int key)
        {
            var user = await _context.Interns.FirstOrDefaultAsync(u => u.Id == key);
            return user;
        }

        public async Task<ICollection<Intern>> GetAll()
        {
            var users = await _context.Interns.ToListAsync();
            if (users.Count > 0)
                return users;
            return null;
        }

        public async Task<Intern> Update(Intern item)
        {
            var user = await Get(item.Id);
            if (user != null)
            {
                user.Age = item.Age;
                user.Name = item.Name;
                user.Phone = item.Phone;
                user.Email = item.Email;    
                user.Gender = item.Gender;
                user.DateOfBirth = item.DateOfBirth;    
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
