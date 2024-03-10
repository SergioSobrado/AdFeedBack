using AdFeedBack.dto.Dtos.UserRole;
using AdFeedBack.dto.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Interfaces
{
    public interface IUserRoleService
    {
        UserRoleReadDto GetById(int userId, int roleId);
        UserRoleResult Create(UserRoleCreateDto userRoleCreateDto);
        bool Delete(int userId, int roleId);    
    }
}
