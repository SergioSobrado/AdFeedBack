using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Relación con UserRole
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
