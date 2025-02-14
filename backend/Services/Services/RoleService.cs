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

namespace Services.Services
{
    public class RoleService : IRoleService<RoleDTO>
    {
        private readonly IRoleRepository<Role> _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository<Role> repository, IMapper mapper)
        {
            _roleRepository = repository;
            _mapper = mapper;
        }

        public async Task<int?> GetIdByNameAsync(string name)
        {
            return await _roleRepository.GetIdByNameAsync(name);
        }

        public async Task<List<RoleDTO>> GetRolesAsync()
        {
            return _mapper.Map<List<RoleDTO>>(await _roleRepository.GetRolesAsync());
        }

        //public async Task<RoleDTO> AddAsync(RoleDTO entity)
        //{
        //    var c = await _RoleRepository.AddAsync(_mapper.Map<Role>(entity));
        //    return _mapper.Map<RoleDTO>(c);
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    _RoleRepository.DeleteAsync(id);
        //}

        //public async Task<List<RoleDTO>> GetAllAsync()
        //{
        //    return _mapper.Map<List<RoleDTO>>(await _RoleRepository.GetAllAsync());
        //}

        //public async Task<RoleDTO> GetByIdAsync(int id)
        //{
        //    return _mapper.Map<RoleDTO>(await _RoleRepository.GetByIdAsync(id));
        //}

        //public async Task UpdateAsync(int id, RoleDTO entity)
        //{
        //    _RoleRepository.UpdateAsync(id, _mapper.Map<Role>(entity));
        //}
    }
}
