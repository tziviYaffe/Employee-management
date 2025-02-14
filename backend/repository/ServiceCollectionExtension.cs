using Microsoft.Extensions.DependencyInjection;

using Repositories.Interface;

using Repository.Entities;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
              services.AddScoped<IEmployeeRepository<Employee>,EmployeeRepository>();
              services.AddScoped< IRoleRepository<Role>, RoleRepository>();

        }
    }
}
