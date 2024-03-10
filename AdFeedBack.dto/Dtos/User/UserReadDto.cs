using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdFeedBack.dto.Dtos.Perfil;

namespace AdFeedBack.dto.Dtos.User
{
    public class UserReadDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } // Asegúrate de que esta propiedad esté poblada
        public PerfilReadDto Perfil { get; set; }
    }
}
