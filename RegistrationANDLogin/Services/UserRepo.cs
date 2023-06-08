using Microsoft.EntityFrameworkCore;
using RegistrationAndLogin.Context;
using RegistrationAndLogin.Interfaces;
using RegistrationAndLogin.Model;
using System.Diagnostics;

namespace RegistrationAndLogin.Services
{
    public class UserRepo : IBaseRepo<string, Users>
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Users Add(Users item)
        {
            try
            {
                _databaseContext.User.Add(item);
                _databaseContext.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Users Get(string key)
        {
            var user = _databaseContext.User.FirstOrDefault(u => u.UserName == key);
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<Users> GetAll()
        {
            return _databaseContext.User.ToList();  
        }
    }
}