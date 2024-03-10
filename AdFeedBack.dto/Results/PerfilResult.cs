using AdFeedBack.dto.Dtos.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Results
{
    public class PerfilResult
    {
        public bool IsSuccessful { get; set; }
        public ErrorResponse Errors { get; set; }
        public PerfilReadDto Perfil { get; set; }
    }
}
