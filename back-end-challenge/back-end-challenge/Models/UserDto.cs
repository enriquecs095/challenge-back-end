using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Models
{
    public partial class UserDto
    {
        public UserDto()
        {
            Followers = new HashSet<FollowerDto>();
            Followings = new HashSet<FollowingDto>();
            Timelines = new HashSet<TimelineDto>();
        }

        public string IdUser { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Activate { get; set; }
        public string Thought { get; set; }
        public string Password { get; set; }

        public virtual ICollection<FollowerDto> Followers { get; set; }
        public virtual ICollection<FollowingDto> Followings { get; set; }
        public virtual ICollection<TimelineDto> Timelines { get; set; }
    }
}
