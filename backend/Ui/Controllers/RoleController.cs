using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService<RoleDTO> _RoleService;
        public RoleController(IRoleService<RoleDTO> services)
        {
            _RoleService = services;
        }
        // GET: api/<RoleController>
        [HttpGet("")]
        public async Task<List<RoleDTO>> Get()
        {
            return await _RoleService.GetRolesAsync(); //החזרת רשימת התפקידים
        }




    }
}
