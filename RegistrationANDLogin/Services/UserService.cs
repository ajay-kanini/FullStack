using RegistrationAndLogin.Interfaces;
using RegistrationAndLogin.Model;
using RegistrationAndLogin.Model.DTO;
using System.Security.Cryptography;
using System.Text;

namespace RegistrationAndLogin.Services
{
    public class UserService
    {
        private IBaseRepo<string, Users> _baseRepo;
        private IGenerateUserToken _generateUserToken;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseRepo"></param>
        /// <param name="generateUserToken"></param>
        public UserService(IBaseRepo<string, Users> baseRepo, IGenerateUserToken generateUserToken)
        {
            _baseRepo = baseRepo;
            _generateUserToken = generateUserToken;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = _baseRepo.Get(userDTO.UserName);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.HashKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.UserName = userData.UserName;
                user.Role = userData.Role;
                user.Token = _generateUserToken.GenerateUserToken(user);
            }
            return user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO Register(UserRegisterDTO userDTO)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            userDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.PasswordClear));
            userDTO.HashKey = hmac.Key;
            var resultUser = _baseRepo.Add(userDTO);
            if (resultUser != null)
            {
                user = new UserDTO();
                user.UserName = resultUser.UserName;
                user.Role = resultUser.Role;
                user.Token = _generateUserToken.GenerateUserToken(user);
            }
            return user;
        }
    }
}