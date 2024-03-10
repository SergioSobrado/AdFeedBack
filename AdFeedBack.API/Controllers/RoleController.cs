using AdFeedBack.dto.Dtos.Role;
using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Models;
using AdFeedBack.negocio.Interfaces;
using AdFeedBack.negocio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace AdFeedBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<RoleReadDto>> GetAll()
        {
            return _roleService.GetAllRoles();
        }
        
        [HttpGet("{id}", Name = "RoleGetById")]
        public ActionResult<RoleReadDto> GetById(int id)
        {
            var role = _roleService.GetById(id); // Asume que este método existe en RoleService
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public ActionResult<Role> Create(RoleCreateDto roleCreateDto)
        {
            var result = _roleService.Create(roleCreateDto);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtRoute(nameof(GetById), new { Id = result.Role.RoleId }, result.Role);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RoleUpdateDto roleUpdateDto)
        {
            var result = _roleService.Update(id, roleUpdateDto);
            if (!result.IsSuccessful)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtRoute(nameof(GetById), new { Id = result.Role.RoleId }, result.Role); // O la respuesta apropiada
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var wasDeleted = _roleService.Delete(id);

            if (wasDeleted)
            {
                return Ok("Rol eliminado");
            }
            else
            {
                return NotFound("Rol no encontrado");
            }
        }
    }
}
