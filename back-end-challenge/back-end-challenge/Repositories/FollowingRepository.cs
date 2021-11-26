using back_end_challenge.Entities;
using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly postgresContext db;

        public FollowingRepository(postgresContext postgresContext)
        {
            this.db = postgresContext;
        }

        public async Task<bool> AddFollowing(Following following)
        {
            var result = await db.Followings.AddAsync(following);
            await db.SaveChangesAsync();
            return (result!=null)? true: false;
        }

    }
}
