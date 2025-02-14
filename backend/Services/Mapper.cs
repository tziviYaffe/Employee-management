using AutoMapper;
using Common.DTOs;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Employee, EmployeeDTO>()
           .ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }


}
