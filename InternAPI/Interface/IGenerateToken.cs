using InternAPI.Models.DTO;

namespace InternAPI.Interface
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);
    }
}
