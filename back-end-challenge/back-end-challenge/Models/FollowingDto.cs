using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Models
{
    public partial class FollowingDto
    {
        public int IdFollowing { get; set; }
        public string UserMaster { get; set; }
        public string UserFollowing { get; set; }

        public virtual UserDto UserMasterNavigation { get; set; }
    }
}
