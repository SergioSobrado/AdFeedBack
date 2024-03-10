using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdFeedBack.dto.Dtos.Perfil;

namespace AdFeedBack.dto.Dtos.User
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }
        public PerfilUpdateDto Perfil { get; set; }
    }
}
