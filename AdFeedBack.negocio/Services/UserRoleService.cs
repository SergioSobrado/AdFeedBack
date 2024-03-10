using AdFeedBack.data;
using AdFeedBack.dto;
using AdFeedBack.dto.Dtos.Perfil;
using AdFeedBack.dto.Dtos.Role;
using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Dtos.UserRole;
using AdFeedBack.dto.Models;
using AdFeedBack.dto.Results;
using AdFeedBack.negocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly MiDbContext _context;

        public UserRoleService(MiDbContext context)
        {
            _context = context;
        }

        public UserRoleReadDto GetById(int userId, int roleId)
        {
            // the id is User_id + Role_id
            var userRole = _context.UserRoles
                                    .Include(ur => ur.User)
                                    .Include(ur => ur.Role)
                                    .FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);


            var userRoleReadDto = new UserRoleReadDto
            {
                User = new UserReadDto
                {
                    UserId = userRole.User.UserId,
                    Email = userRole.User.Email,
                    Perfil = userRole.User.Perfil != null ? new PerfilReadDto
                    {
                        FirstName = userRole.User.Perfil.FirstName,
                        LastName = userRole.User.Perfil.LastName,
                        Address = userRole.User.Perfil.Address,
                        PhoneNo = userRole.User.Perfil.PhoneNo
                    } : new PerfilReadDto()
                },
                Role = new RoleReadDto
                {
                    RoleId = userRole.Role.RoleId,
                    Name = userRole.Role.Name
                }
            };

            return userRoleReadDto; // Retorna el UserReadDto
        }

        public UserRoleResult Create(UserRoleCreateDto userRoleCreateDto)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == userRoleCreateDto.RoleId);
            var user = _context.Users.Include(u => u.Perfil)
                                     .Include(user => user.UserRoles)
                                        .ThenInclude(ur => ur.Role)
                                     .FirstOrDefault(u => u.UserId == userRoleCreateDto.UserId);
            if (user == null)
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("User", "No se encontro el usuario")
                };

                return new UserRoleResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            };

            if (role == null)
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Role", "No se encontro el rol")
                };

                return new UserRoleResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            };
            
            if (user.UserRoles.Any(ur => ur.RoleId == role.RoleId))
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Role", "El usuario ya tiene asignado este rol")
                };

                return new UserRoleResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            // Agregar el rol al usuario
            var userRole = new UserRole { User = user, Role = role };

            _context.UserRoles.Add(userRole);
            _context.SaveChanges();

            var userReadDto = new UserReadDto
            {
                UserId = user.UserId,
                Email = user.Email,
                Roles = user.UserRoles?.Select(ur => ur.Role.Name).ToList() ?? new List<string>(),
                Perfil = user.Perfil != null ? new PerfilReadDto
                {
                    FirstName = user.Perfil.FirstName,
                    LastName = user.Perfil.LastName,
                    Address = user.Perfil.Address,
                    PhoneNo = user.Perfil.PhoneNo
                } : new PerfilReadDto()
            };

            var roleReadDto = new RoleReadDto
            {
                RoleId = role.RoleId,
                Name = role.Name
            };

            var userRoleReadDto = new UserRoleReadDto
            {
                User = userReadDto,
                Role = roleReadDto
            };

            return new UserRoleResult
            {
                IsSuccessful = true,
                UserRole = userRoleReadDto
            };
        }

        public bool Delete(int userId, int roleId)
        {
            var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole == null)
            {
                return false;
            }

            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();

            return true;
        }
    }
}
