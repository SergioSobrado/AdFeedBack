using AdFeedBack.dto.Dtos.Role;
using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Dtos.UserRole;
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
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        
        [HttpGet("{userId}/{roleId}", Name = "GetById")]
        public ActionResult<RoleReadDto> GetById(int userId, int roleId)
        {
            var user = _userRoleService.GetById(userId,roleId ); // Asume que este método existe en RoleService
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserRole> Create(UserRoleCreateDto userRoleCreateDto)
        {
            var result = _userRoleService.Create(userRoleCreateDto);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtRoute(nameof(GetById), new { Id = result.UserRole.UserRoleId }, result.UserRole);
        }

        [HttpDelete("{userId}/{roleId}")]
        public IActionResult Delete(int userId, int roleId)
        {
            var wasDeleted = _userRoleService.Delete(userId,roleId);

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
