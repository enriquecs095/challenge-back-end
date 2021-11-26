using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Models
{
    public partial class Following
    {
        public int IdFollowing { get; set; }
        public string UserMaster { get; set; }
        public string UserFollowing { get; set; }

        public virtual NewUserDto UserMasterNavigation { get; set; }
    }
}
