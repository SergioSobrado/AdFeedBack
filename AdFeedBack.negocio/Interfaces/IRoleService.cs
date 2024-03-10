using AdFeedBack.dto.Dtos.Role;
using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Interfaces
{
    public interface IRoleService
    {
        List<RoleReadDto> GetAllRoles();
        RoleReadDto GetById(int id);
        RoleResult Create(RoleCreateDto roleCreateDto);
        RoleResult  Update(int roleId, RoleUpdateDto roleUpdateDto);
        bool Delete(int id);
    }
}
