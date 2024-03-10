using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Models
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        [RegularExpression(@"^\(\d{3}\) \d{4}-\d{3}$", ErrorMessage = "El formato del teléfono no es válido. El formato correcto es (xxx) xxxx-xxx.")]
        public string? PhoneNo { get; set; }

        // Clave foránea del Usuario
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
