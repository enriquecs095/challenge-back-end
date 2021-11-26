using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Entities
{
    public partial class Following
    {
        public int IdFollowing { get; set; }
        public string UserMaster { get; set; }
        public string UserFollowing { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual User UserMasterNavigation { get; set; }
    }
}
