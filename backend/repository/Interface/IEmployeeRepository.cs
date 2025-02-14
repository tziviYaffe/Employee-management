using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IEmployeeRepository<T>
    {
        Task<List<T>> GetAllActiveAsync();
        Task<List<T>> GetAllOsEmployeesAsync();
        Task<List<T>> GetAllManagersAsync();
        Task<T> AddAsync(T entity, string roleName,string managerName);
        Task UpdateAsync(int id, T entity, string roleName,string mangerName);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetManagerValid(string managerName);

    }
}
