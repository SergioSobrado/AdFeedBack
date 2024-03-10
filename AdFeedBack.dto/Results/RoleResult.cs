using AdFeedBack.dto.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Results
{
    public class RoleResult
    {
        public bool IsSuccessful { get; set; }
        public ErrorResponse Errors { get; set; }
        public RoleReadDto Role { get; set; }
    }
}
