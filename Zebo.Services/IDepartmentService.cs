using System.Collections.Generic;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Services
{
    public interface IDepartmentService 
    {
        Department GetDepartment(int id);
        IEnumerable<Department> GetDepartments();
        void UpdatePriceTag(string departmentName,string priceTag);
        void ResetCache();
    }
}
