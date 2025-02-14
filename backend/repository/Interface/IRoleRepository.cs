using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRoleRepository<T>
    {
        Task<int?> GetIdByNameAsync(string name);
        Task<T> GetRoleByNameAsync(string name);
        Task<List<T>> GetRolesAsync();
    }
}
