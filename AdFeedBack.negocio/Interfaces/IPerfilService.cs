using AdFeedBack.dto.Dtos.Perfil;
using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Interfaces
{
    public interface IPerfilService
    {
        PerfilResult Create(int userId, PerfilCreateDto perfilCreateDto);
        PerfilResult Update(int perfilId, PerfilUpdateDto perfilUpdateDto);
    }
}
