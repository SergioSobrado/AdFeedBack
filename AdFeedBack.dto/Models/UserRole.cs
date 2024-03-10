﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        // Clave foránea del Rol
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
