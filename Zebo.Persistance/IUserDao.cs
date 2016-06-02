using System.Collections.Generic;
using Zebo.Domain.Models.Users;

namespace Zebo.Persistance
{
    public interface IUserDao
    {
        bool GetIsUserExists(string pinCode);
        User GetUserByPinCode(string pinCode);
        IEnumerable<UserRole> GetUserRoles();
    }
}
