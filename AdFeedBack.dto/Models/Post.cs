using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.dto.Models
{
    internal class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
