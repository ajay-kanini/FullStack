using RegistrationAndLogin.Model.DTO;

namespace RegistrationAndLogin.Interfaces
{
    public interface IGenerateUserToken
    {
        public string GenerateUserToken(UserDTO userDTO);  
    }
}
