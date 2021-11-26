using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public interface ITimelineRepository
    {
        Task<IReadOnlyList<TimelineDto>> GetTimeLineAsync(string user);
        Task<bool> AddCommenttoTimelineAsync(TimelineDto timeline);  
    }
}
