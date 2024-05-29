﻿using org_empleados.Application.Interfaces;
using org_empleados.Domain.DTOs.Roles;
using org_empleados.Domain.Models;
using org_empleados.Mappers;

namespace org_empleados.Application.Services
{
    public class RoleService(IRoleRepository repository) : IRoleService
    {
        private readonly IRoleRepository _roleRepository = repository;

        public async Task<bool> CreateRole(CreateRoleDTO roleDTO)
        {
            ArgumentNullException.ThrowIfNull(roleDTO);
            Role role = roleDTO.ToModelFromCreateDTO();
            return await _roleRepository.Create(role);
        }

        public async Task<Role> DeleteRole(int id)
        {
            Role? role = await _roleRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(role);
            return await _roleRepository.Delete(role);
        }

        public async Task<List<Role>> GetAll()
        {
            return await _roleRepository.ListAll();
        }

        public async Task<Role> GetById(int id)
        {
            Role? role = await _roleRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(role);
            return role;
        }

        public async Task<Role> UpdateRole(int id, UpdateRoleDTO roleDTO)
        {
            Role? actualRole = await _roleRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(actualRole);
            Role role = roleDTO.ToModelFromUpdateDTO();
            return await _roleRepository.Update(actualRole, role);
        }
    }
}
