using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Services.Interface;
using Services.Services;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService<EmployeeDTO> _EmployeeService;
        public EmployeeController(IEmployeeService<EmployeeDTO> services)
        {
            _EmployeeService = services;
        }
        // GET: api/Employee
        [HttpGet("")]
        public async Task<List<EmployeeDTO>> Get()
        {
            return await _EmployeeService.GetAllActiveAsync(); // החזרת כל העובדים
        }

        // GET: api/Employee/os
        [HttpGet("os")]
        public async Task<List<EmployeeDTO>> GetOsEmployees()
        {
            return await _EmployeeService.GetAllOsEmployeesAsync(); // החזרת עובדים מסוג OS
        }

        // GET: api/Employee/managers
        [HttpGet("managers")]
        public async Task<List<EmployeeDTO>> GetManagers()
        {
            return await _EmployeeService.GetAllManagersAsync(); // החזרת מנהלים
        }
        // POST: EmployeeController/Create
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee([FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Invalid employee data.");
            }
            try
            {
                var addedEmployee = await _EmployeeService.AddEmployeeAsync(employeeDto);
                return CreatedAtAction(nameof(Get), new { id = addedEmployee.Id }, addedEmployee);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            try
            {
                await _EmployeeService.DeleteAsync(id);
                return NoContent(); // מחזיר 204 אם המחיקה הצליחה
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // מחזיר 400 במקרה של שגיאה
            }
        }
        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (id <= 0 || employeeDto == null)
            {
                return BadRequest("Invalid employee data.");
            }
            try
            {
                await _EmployeeService.UpdateAsync(id, employeeDto);
                return NoContent(); // מחזיר 204 אם העדכון הצליח
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Employee not found.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
