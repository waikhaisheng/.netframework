using Database.Users;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DatabaseServices
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211222
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private UserDbContext _userDbContext;
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="cs"></param>
        public UserService(string cs)
        {
            _userDbContext = new UserDbContext(cs);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user)
        {
            return _userDbContext.AddUser(user);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool RemoveUser(User user)
        {
            return _userDbContext.RemoveUser(user.Id);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User UserLogin(string email, string password)
        {
            return _userDbContext.Login(email, password);
        }
    }
}
