using System.Linq;
using AdFeedBack.data;
using AdFeedBack.dto.Models;
using AdFeedBack.dto.Dtos;
using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Dtos.Perfil;
using AdFeedBack.negocio.Interfaces;
using System.Collections.Generic;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using AdFeedBack.dto;
using AdFeedBack.dto.Results;
using AdFeedBack.dto.Dtos.UserRole;

namespace AdFeedBack.negocio.Services
{
    public class UserService : IUserService
    {
        private readonly MiDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IPerfilService _perfilService;
        private readonly IUserRoleService _userRoleService;

        public UserService(MiDbContext context, IEmailService emailService, IPerfilService perfilService, IUserRoleService userRoleService)
        {
            _context = context;
            _emailService = emailService;
            _perfilService = perfilService;
            _userRoleService = userRoleService;
        }
        
        public List<UserReadDto> GetAllUsers()
        {
            // Obtener todos los usuarios de la base de datos
            var users = _context.Users
                                .Include(user => user.Perfil)
                                .Include(user => user.UserRoles)
                                    .ThenInclude(ur => ur.Role)
                                .ToList();

            // Mapear a UserReadDto (esto es un ejemplo básico, considera usar AutoMapper para casos más complejos)
            var userDtos = users.Select(user => new UserReadDto
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
                // Otros campos que necesites
            }).ToList();

            return userDtos;
        }
        public UserReadDto GetById(int id)
        {
            // Obtener el usuario de la base de datos
            var user = _context.Users
                                .Include(u => u.Perfil)
                                .Include(user => user.UserRoles)
                                    .ThenInclude(ur => ur.Role)
                                .FirstOrDefault(u => u.UserId == id);

            // Aquí deberías mapear tu entidad User a un UserReadDto
            var userReadDto = new UserReadDto
            {
                UserId = user.UserId,
                Email = user.Email,
                Roles = user.UserRoles?.Select(ur => ur.Role.Name).ToList() ?? new List<string>(),
                Perfil = user.Perfil != null ? new PerfilReadDto
                {
                    FirstName = user.Perfil.FirstName,
                    LastName = user.Perfil.LastName,
                    Address = user.Perfil.Address
                } : new PerfilReadDto() // Retorna un objeto PerfilReadDto vacío si no hay perfil
            };

            return userReadDto; // Retorna el UserReadDto
        }
        public async Task<UserResult> Create(UserCreateDto userCreateDto)
        {
            if (_context.Users.Any(u => u.Email == userCreateDto.Email))
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Email", "Ya existe un usuario con este email.")
                };

                return new UserResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            // Crear el usuario
            var user = new User
            {
                Email = userCreateDto.Email,
                Password = userCreateDto.Password, // Asegúrate de encriptar esta contraseña
                ConfirmationPassword = userCreateDto.ConfirmationPassword
                // Otros campos del usuario si los hay
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            // Lógica para crear el perfil usando PerfilService
            var perfil = userCreateDto.Perfil;
            if (perfil != null)
            {
                perfil.UserId = user.UserId; // Asigna el UserId al Perfil
            }
            var perfilDto = _perfilService.Create(user.UserId, perfil);

            if (!perfilDto.IsSuccessful)
            {
                // Si hubo un error al crear el perfil, elimina el usuario creado anteriormente
                _context.Users.Remove(user);
                _context.SaveChanges();

                return new UserResult
                {
                    IsSuccessful = false,
                    Errors = perfilDto.Errors
                };
            }

            // Asignar el rol "User" al usuario
            var userRoleDto = _userRoleService.Create(new UserRoleCreateDto
            {
                UserId = user.UserId,
                RoleId = 2 // El Id del rol "User"
            });

            if(!userRoleDto.IsSuccessful)
            {
                // Si hubo un error al crear el rol, elimina el usuario creado anteriormente
                _context.Users.Remove(user);
                _context.SaveChanges();

                return new UserResult
                {
                    IsSuccessful = false,
                    Errors = userRoleDto.Errors
                };
            }

            // Enviar un correo de confirmación al usuario (si es necesario)
            user.ConfirmToken = Guid.NewGuid().ToString();
            user.ConfirmExpirationToken = DateTime.UtcNow.AddDays(1); // El token expira en 1 día
            _context.SaveChanges();

            var variables = new Dictionary<string, string>
            {
                { "UserName", user.Perfil.FirstName },
                { "ConfirmUrl", $"https://tuapi.com/confirmacion?token={user.ConfirmToken}" }
            };
            // Enviar el correo
            await _emailService.SendEmailAsync(user.Email, "Confirmación de Cuenta", variables);

            // Mapear a UserReadDto (considera usar AutoMapper para simplificar esto)
            var userReadDto = new UserReadDto
            {
                UserId = user.UserId,
                Email = user.Email,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList(),
                Perfil = user.Perfil != null ? new PerfilReadDto
                {
                    FirstName = user.Perfil.FirstName,
                    LastName = user.Perfil.LastName,
                    Address = user.Perfil.Address,
                    PhoneNo = user.Perfil.PhoneNo
                } : new PerfilReadDto()
            }; 

            return new UserResult
            {
                IsSuccessful = true,
                User = userReadDto
            };

        }
        public UserResult Update(int userId, UserUpdateDto userUpdateDto)
        {
            var user = _context.Users
                                .Include(u => u.Perfil)
                                .Include(user => user.UserRoles)
                                    .ThenInclude(ur => ur.Role)
                                .FirstOrDefault(u => u.UserId == userId);

            if (_context.Users.Any(u => u.Email == userUpdateDto.Email && u.UserId != userId))
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Email", "Ya existe un usuario con este email.")
                };

                return new UserResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            if (user != null)
            {
                user.Email = userUpdateDto.Email;
                // Actualiza otros campos del usuario

                var perfil = _perfilService.Update(user.Perfil.PerfilId, userUpdateDto.Perfil);

                if (!perfil.IsSuccessful)
                {
                    return new UserResult
                    {
                        IsSuccessful = false,
                        Errors = perfil.Errors
                    };
                }
                _context.SaveChanges();

                // Mapeo a UserReadDto
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

                return new UserResult
                {
                    IsSuccessful = true,
                    User = userReadDto
                };
            }
            return null;
        }

        public bool DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public UserResult Login(UserLoginDto userLoginDto)
        {
            var user = _context.Users
                                .Include(u => u.Perfil)
                                .Include(user => user.UserRoles)
                                    .ThenInclude(ur => ur.Role)
                                .FirstOrDefault(u => u.Email == userLoginDto.Email);

            if (user == null)
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Email", "No existe un usuario con este email.")
                };

                return new UserResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            if (user.Password != userLoginDto.Password)
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Password", "La contraseña es incorrecta.")
                };

                return new UserResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }

            // Mapear a UserReadDto (considera usar AutoMapper para simplificar esto)
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

            return new UserResult
            {
                IsSuccessful = true,
                User = userReadDto
            };
        }
    }
}
