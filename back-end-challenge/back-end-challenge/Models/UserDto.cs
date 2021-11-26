using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Models
{
    public partial class NewUserDto
    {
        public NewUserDto()
        {
            Followers = new HashSet<Follower>();
            Followings = new HashSet<Following>();
            Timelines = new HashSet<Timeline>();
        }

        public string IdUser { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Activate { get; set; }
        public string Thought { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<Following> Followings { get; set; }
        public virtual ICollection<Timeline> Timelines { get; set; }
    }
}
