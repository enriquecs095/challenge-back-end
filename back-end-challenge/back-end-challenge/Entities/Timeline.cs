using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Entities
{
    public partial class Timeline
    {
        public int IdTimeline { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
