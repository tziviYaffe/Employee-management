using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IEmployeeService<T>
    {
        Task<List<T>> GetAllActiveAsync();
        Task<List<T>> GetAllOsEmployeesAsync();
        Task<List<T>> GetAllManagersAsync();
        Task<T> AddEmployeeAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
