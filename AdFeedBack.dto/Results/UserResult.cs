using AdFeedBack.dto.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Results
{
    public class UserResult
    {
        public bool IsSuccessful { get; set; }
        public ErrorResponse Errors { get; set; }
        public UserReadDto User { get; set; }
    }
}
