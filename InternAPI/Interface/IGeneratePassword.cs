using InternAPI.Models;

namespace InternAPI.Interface
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);
    }
}
