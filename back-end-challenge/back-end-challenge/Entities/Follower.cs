using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Entities
{
    public partial class Follower
    {
        public int IdFollower { get; set; }
        public string UserMaster { get; set; }
        public string UserFollower { get; set; }

        public virtual NewUserDto UserMasterNavigation { get; set; }
    }
}
