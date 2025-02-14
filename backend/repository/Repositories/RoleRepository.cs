using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository.Repositories
{
    public class RoleRepository :IRoleRepository<Role>
    {
        private readonly Icontext _context;
        public RoleRepository(Icontext context)
        {
            this._context = context;
        }
        
        public async Task<int?> GetIdByNameAsync(string name)
        {
            return await _context.Role
                .Where(r => r.Name == name)
                .Select(r => (int?)r.Id) 
                .FirstOrDefaultAsync();
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _context.Role
                 .Where(r => r.Name == name)
                 .FirstOrDefaultAsync();
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Role.ToListAsync();   
        }
    }
}
