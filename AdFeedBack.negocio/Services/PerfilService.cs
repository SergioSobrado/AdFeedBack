using AdFeedBack.data;
using AdFeedBack.dto;
using AdFeedBack.dto.Dtos.Perfil;
using AdFeedBack.dto.Models;
using AdFeedBack.dto.Results;
using AdFeedBack.negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AdFeedBack.negocio.Services.UserService;

namespace AdFeedBack.negocio.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly MiDbContext _context;

        public PerfilService(MiDbContext context)
        {
            _context = context;
        }

        public PerfilResult Create(int userId, PerfilCreateDto perfilDto)
        {
            if (_context.Perfiles.Any(u => u.PhoneNo == perfilDto.PhoneNo))
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Perfil", "Ya existe un perfil con este número de teléfono.")
                };

                return new PerfilResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }
            var perfil = new Perfil
            {
                UserId = userId,
                FirstName = perfilDto.FirstName,
                LastName = perfilDto.LastName,
                Address = perfilDto.Address,
                PhoneNo = perfilDto.PhoneNo,
            };

            _context.Perfiles.Add(perfil);
            _context.SaveChanges();

            var perfilReadDto = new PerfilReadDto
            {
                FirstName = perfil.FirstName,
                LastName = perfil.LastName,
                Address = perfil.Address,
                PhoneNo = perfil.PhoneNo
            };
            return new PerfilResult
            {
                IsSuccessful = true,
                Perfil = perfilReadDto
            };

        }

        public PerfilResult Update(int perfilId, PerfilUpdateDto perfilUpdateDto)
        {
            var perfil = _context.Perfiles.FirstOrDefault(u => u.PerfilId == perfilId);
            if (perfil == null)
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Perfil", "No existe un perfil con este id.")
                };

                return new PerfilResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }
            if (_context.Perfiles.Any(u => u.PhoneNo == perfilUpdateDto.PhoneNo && u.PerfilId != perfilId))
            {
                var validationErrors = new List<ValidationError>
                {
                    new ValidationError("Perfil", "Ya existe un perfil con este número de teléfono.")
                };

                return new PerfilResult
                {
                    IsSuccessful = false,
                    Errors = ValidationError.CreateErrorResponse(validationErrors)
                };
            }
            perfil.FirstName = perfilUpdateDto.FirstName;
            perfil.LastName = perfilUpdateDto.LastName;
            perfil.Address = perfilUpdateDto.Address;
            perfil.PhoneNo = perfilUpdateDto.PhoneNo;
            _context.SaveChanges();

            var perfilReadDto = new PerfilReadDto
            {
                FirstName = perfil.FirstName,
                LastName = perfil.LastName,
                Address = perfil.Address,
                PhoneNo = perfil.PhoneNo
            };

            return new PerfilResult
            {
                IsSuccessful = true,
                Perfil = perfilReadDto
            };
        }
        // Otros métodos, como eliminación de perfil
    }
}
