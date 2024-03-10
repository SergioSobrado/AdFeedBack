using AdFeedBack.dto.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserReadDto user);
    }
}
