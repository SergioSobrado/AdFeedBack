using AdFeedBack.dto.Dtos.Role;
using AdFeedBack.dto.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Dtos.UserRole
{
    public class UserRoleReadDto
    {
        public int UserRoleId { get; set; }
        public UserReadDto User { get; set; }
        public RoleReadDto Role { get; set; }
    }
}
