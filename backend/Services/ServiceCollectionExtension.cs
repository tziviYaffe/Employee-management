using Common.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Services.Interface;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Repositories;
using Repository.Entities;
namespace Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService<EmployeeDTO>, EmployeeService>();
            services.AddScoped<IRoleService<RoleDTO>, RoleService>();
            services.AddAutoMapper(typeof(Mapper));
            services.AddRepositories();
        }
    }
}
