using AutoMapper;
using Common.DTOs;
using Repositories.Interface;
using Repository.Entities;
using Repository.Interface;
using Repository.Repositories;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Services.Services
{
    public class EmployeeService: IEmployeeService<EmployeeDTO>
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository<Employee> repository,
                      
                            IMapper mapper)
        {
            _employeeRepository = repository;
            _mapper = mapper;
        }

public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO entity)
{
    try
    {
        var employee = _mapper.Map<Employee>(entity);

        var addedEmployee = await _employeeRepository.AddAsync(employee, entity.RoleName, entity.ManagerName);
        var employeeDTO = _mapper.Map<EmployeeDTO>(addedEmployee);


        return employeeDTO;
    }
    catch (Exception ex)
    {
        Debug.WriteLine($"❌ ERROR in Service: {ex.InnerException?.Message ?? ex.Message}");
        throw new ApplicationException($"Failed to add employee: {ex.InnerException?.Message ?? ex.Message}", ex);
    }
}
        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<List<EmployeeDTO>> GetAllActiveAsync()
        {
            var employees = await _employeeRepository.GetAllActiveAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<List<EmployeeDTO>> GetAllManagersAsync()
        {
            var managers = await _employeeRepository.GetAllManagersAsync();
            return _mapper.Map<List<EmployeeDTO>>(managers);
        }

        public async Task<List<EmployeeDTO>> GetAllOsEmployeesAsync()
        {
            var osEmployees = await _employeeRepository.GetAllOsEmployeesAsync();
            return _mapper.Map<List<EmployeeDTO>>(osEmployees);
        }

        public async Task UpdateAsync(int id, EmployeeDTO entity)
        {
            var employee = _mapper.Map<Employee>(entity);
            await _employeeRepository.UpdateAsync(id, employee,entity.RoleName,entity.ManagerName);
        }


    }
}
