using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Models
{
    public partial class FollowerDto
    {
        public int IdFollower { get; set; }
        public string UserMaster { get; set; }
        public string UserFollower { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual UserDto UserMasterNavigation { get; set; }
    }
}
