using InternAPI.Interface;
using InternAPI.Models;
using InternAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace InternAPI.Services
{
    public class GeneratePasswordService : IGeneratePassword
    {
        private readonly IRepo<int, User> _userRepo;

        public GeneratePasswordService(IRepo<int, User> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<string?> GeneratePassword(Intern intern)
        {
            string password = String.Empty;
            password = intern.Name.Substring(0, 4);
            password += intern.DateOfBirth.Day;
            password += intern.DateOfBirth.Month;
            return password;
        }

       
    }
}
