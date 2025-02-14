using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {

        private readonly Icontext _context;
        private readonly IRoleRepository<Role> _roleRepository;
        public EmployeeRepository(Icontext context, IRoleRepository<Role> roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
            //  אתחול התלות
        }

        public async Task<Employee> AddAsync(Employee e, string roleName, string managerName)
        {
            e.Role = null;
            e.Manager = null;
             if(e.IdNumber.Length!=9)
                throw new Exception("TZ have to be with 9 digits");
            // חיפוש האם קיים עובד עם אותו מספר זהות
            var existingEmployee = await _context.Employee
                .FirstOrDefaultAsync(emp => emp.IdNumber == e.IdNumber);
            if (existingEmployee != null)
            {
                throw new Exception("Employee already exists.");
            }
            //תפקיד עובד
            Role role = await _roleRepository.GetRoleByNameAsync(roleName);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            //אם לא שלח מנהל
            if (string.IsNullOrWhiteSpace(managerName) || managerName == "string")
            {
                e.Manager = null;
            }
            else
            {
                Employee employee = await this.GetManagerValid(managerName);
                if (employee == null)
                {
                    throw new Exception("Manager not found");
                }
                else
                {
                    e.Manager = employee;
                }
            }
            //  עדכון התפקיד
            e.Role = role;

            //  שמירת הנתונים
            await _context.Employee.AddAsync(e);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return e;

        }



        public async Task DeleteAsync(int id)
        {
            var q = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (q == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }
            q.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task<List<Employee>> GetAllActiveAsync()
        {
            return await _context.Employee
                .Where(e => !e.IsDeleted)
                .Include(e => e.Manager) // טוען את המנהל של העובד
                .Include(e => e.Role) // טוען את התפקיד של העובד ישירות מהטבלה Role
                .ToListAsync();
        }


        public async Task<List<Employee>> GetAllManagersAsync()
        {
            return await _context.Employee
                .Where(e => !e.IsDeleted && (e.Role.Name == "Manager" || e.Role.Name == "Senior Management"))
                .Include(e => e.Manager) // טעינת המנהל של העובד
                .Include(e => e.Role) // טעינת התפקיד של העובד
                .ToListAsync();
        }


        public async Task<List<Employee>> GetAllOsEmployeesAsync()
        {
            return await _context.Employee
                .Where(e => !e.IsDeleted && e.Role.Name == "OS Employee")
                .Include(e => e.Manager) // טעינת המנהל של העובד
                .Include(e => e.Role) // טעינת התפקיד של העובד
                .ToListAsync();
        }


        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employee
                .Include(e => e.Manager) // אם צריך מידע על המנהל
                .Include(e => e.Role) // אם צריך מידע על התפקיד
                .FirstOrDefaultAsync(e => e.Id == id);
        }


        public async Task<Employee> GetManagerValid(string managerName)
        {
            return await _context.Employee
         .Include(e => e.Role) // טוען את תפקיד העובד
         .FirstOrDefaultAsync(e => e.Name == managerName &&
                        (e.Role.Name == "Manager" || e.Role.Name == "Senior Management") &&
                        e.IsDeleted == false);

        }

        public async Task UpdateAsync(int id, Employee e, string roleName, string managerName)
        {
            var q = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            //אם העובד לא קיים
            if (q == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }
            //אם מנסה לעדכן ת.ז
            if (q.IdNumber!=e.IdNumber)
            {
                throw new InvalidOperationException("Cannot update employee ID number.");
            }
            //אם  שלח מנהל
            if (string.IsNullOrWhiteSpace(managerName)==false && managerName != "string")
            {
                // האם אכן הוא מנהל
                Employee employee = await this.GetManagerValid(managerName);
                //אם הוא עדכן מנהל אבל לא את עצמו
                if (employee != null)
                {
                    e.Manager = employee;
                }
                else
                    throw new InvalidOperationException("An employee cannot be their own manager.");
            }
            //אם מעדכן תפקיד 
            if (string.IsNullOrWhiteSpace(roleName)==false && roleName != "string")
            {
                Role role = await _roleRepository.GetRoleByNameAsync(roleName);
                if (role == null)
                {
                    throw new Exception("Role not found");
                }
                else
                {
                    q.Role = role;
                }
            }
            if (string.IsNullOrWhiteSpace(e.Name)==false && e.Name != "string")
                q.Name = e.Name;
                await _context.SaveChangesAsync();
            }


        }
    }

