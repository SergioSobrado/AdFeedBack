using AdFeedBack.data;
using AdFeedBack.dto;
using AdFeedBack.dto.Dtos.Role;
using AdFeedBack.dto.Models;
using AdFeedBack.dto.Results;
using AdFeedBack.negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Services
{
    public class RoleService : IRoleService
    {
        private readonly MiDbContext _context;

        public RoleService(MiDbContext context)
        {
            _context = context;
        }

        public List<RoleReadDto> GetAllRoles()
        {
            // Obtener todos los roles de la base de datos
            var roles = _context.Roles.ToList();

            // Mapear a RoleReadDto (esto es un ejemplo básico, considera usar AutoMapper para casos más complejos)
            var roleDtos = roles.Select(role => new RoleReadDto
            {
                RoleId = role.RoleId,
                Name = role.Name,
                // Otros campos que necesites
            }).ToList();

            return roleDtos;
        }

        public RoleReadDto GetById(int id)
        {
            // Obtener el rol de la base de datos
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == id);

            // Aquí deberías mapear tu entidad Role a un RoleReadDto
            var roleDto = new RoleReadDto
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Description = role.Description
                // Otros campos que necesites
            };

            return roleDto;
        }

        public RoleResult Create(RoleCreateDto roleCreateDto)
        {
            // Aquí deberías mapear tu RoleCreateDto a una entidad Role
            var role = new Role
            {
                Name = roleCreateDto.Name,
                Description = roleCreateDto.Description
                // Otros campos que necesites
            };

            // Agregar rol a la base de datos
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Aquí deberías mapear tu entidad Role a un RoleReadDto
            var roleDto = new RoleReadDto
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Description = role.Description
                // Otros campos que necesites
            };

            return new RoleResult
            {
                IsSuccessful = true,
                Role = roleDto
            };
        }

        public RoleResult Update(int id, RoleUpdateDto roleUpdateDto)
        {
            // Obtener el rol de la base de datos
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == id);

            if (role == null)
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("RoleId", "No existe un rol con este id.")
                };

                return new RoleResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            if (_context.Roles.Any(r => r.Name == roleUpdateDto.Name && r.RoleId != id))
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Name", "Ya existe un rol con este nombre.")
                };

                return new RoleResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            // Aquí deberías mapear tu RoleUpdateDto a una entidad Role
            role.Name = roleUpdateDto.Name;
            role.Description = roleUpdateDto.Description;
            // Otros campos que necesites

            // Actualizar rol en la base de datos
            _context.Roles.Update(role);
            _context.SaveChanges();

            // Aquí deberías mapear tu entidad Role a un RoleReadDto
            var roleDto = new RoleReadDto
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Description = role.Description
                // Otros campos que necesites
            };

            return new RoleResult
            {
                IsSuccessful = true,
                Role = roleDto
            };
        }

        public bool Delete(int id)
        {
            var user = _context.Roles.Find(id);
            if (user != null)
            {
                _context.Roles.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
