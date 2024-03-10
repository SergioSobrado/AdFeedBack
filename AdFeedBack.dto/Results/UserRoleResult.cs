using AdFeedBack.dto.Dtos.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Results
{
    public class UserRoleResult
    {
        public bool IsSuccessful { get; set; }
        public ErrorResponse Errors { get; set; }
        public UserRoleReadDto UserRole { get; set; }
    }
}
