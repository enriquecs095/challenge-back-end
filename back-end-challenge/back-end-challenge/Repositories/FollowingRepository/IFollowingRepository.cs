using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public interface IFollowingRepository
    {
        Task<bool> AddFollowingAsync(FollowingDto following);
        Task<IReadOnlyList<FollowingDto>> GetFollowingListAsync(string user);
    }
}
