using InternAPI.Models;
using InternAPI.Models.DTO;

namespace InternAPI.Interface
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(UserDTO user);

        public Task<UserDTO> Register(InternDTO intern);

        public Task<UserDTO> ChangeStatus(UserDTO user);
    }
}
