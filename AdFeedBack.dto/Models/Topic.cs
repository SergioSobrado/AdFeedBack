﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        
        public string? Description { get; set; }
    }
}
