using InternAPI.Models;
using InternAPI.Models.DTO;

namespace InternAPI.Interface
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);        
    }
}
