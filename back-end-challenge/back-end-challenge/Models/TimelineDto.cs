using System;
using System.Collections.Generic;

#nullable disable

namespace back_end_challenge.Models
{
    public partial class TimelineDto
    {
        public int IdTimeline { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }

        public virtual UserDto UserNavigation { get; set; }
    }
}
