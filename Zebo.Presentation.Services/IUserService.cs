using System.Collections.Generic;
using Zebo.Domain.Models.Tickets;
using Zebo.Domain.Models.Users;
using Zebo.Presentation.Services.Common;

namespace Zebo.Presentation.Services
{
    public interface IUserService : IPresentationService
    {
        string GetUserName(int userId);
        IEnumerable<Department> PermittedDepartments { get; }
        bool ContainsUser(int userId);
        bool IsDefaultUserConfigured { get; }
        User LoginUser(string pinValue);
        void LogoutUser(bool resetCache = true);
        bool IsUserPermittedFor(string permissionName);
        IEnumerable<UserRole> GetUserRoles();
    }
}
