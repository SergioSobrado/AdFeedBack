using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Dtos.Perfil
{
    public class PerfilCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^\(\d{3}\) \d{4}-\d{3}$", ErrorMessage = "El formato del teléfono no es válido. El formato correcto es (xxx) xxxx-xxx.")]
        public string PhoneNo { get; set; }
        public int UserId { get; set; }
    }
}
