using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Models;
using AdFeedBack.negocio.Interfaces;
using AdFeedBack.negocio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace AdFeedBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService; // Servicio para generar tokens

        public RegistrationController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public ActionResult Register(UserCreateDto userCreateDto)
        {
            var result = _userService.Create(userCreateDto);

            if (!result.Result.IsSuccessful)
            {
                return BadRequest(result.Result.Errors); // Manejo de errores
            }

            return Ok("Sexo");
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var result = _userService.Login(userLoginDto);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Errors); // Manejo de errores
            }

            // Generar y devolver un token JWT
            var token = _tokenService.CreateToken(result.User);
            return Ok(new { Token = token });
        }
    }
}
