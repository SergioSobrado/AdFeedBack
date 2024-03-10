using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Models;
using AdFeedBack.negocio.Interfaces;
using AdFeedBack.negocio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace AdFeedBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<UserReadDto>> GetAll()
        {
            return _userService.GetAllUsers();
        }
        
        [HttpGet("{id}", Name = "UserGetById")]
        public ActionResult<UserReadDto> GetById(int id)
        {
            var user = _userService.GetById(id); // Asume que este método existe en UserService
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create(UserCreateDto userCreateDto)
        {
            var result = _userService.Create(userCreateDto);

            if (!result.Result.IsSuccessful)
            {
                return BadRequest(result.Result.Errors);
            }
            return CreatedAtRoute(nameof(GetById), new { Id = result.Result.User.UserId }, result.Result.User);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserUpdateDto userUpdateDto)
        {
            var result = _userService.Update(id, userUpdateDto);
            if (!result.IsSuccessful)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtRoute(nameof(GetById), new { Id = result.User.UserId }, result.User); // O la respuesta apropiada
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var wasDeleted = _userService.DeleteUser(id);

            if (wasDeleted)
            {
                return Ok("Usuario eliminado");
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }
    }
}
