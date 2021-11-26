using back_end_challenge.Entities;
using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;
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

 

        public async Task<bool> AddFollowingAsync(FollowingDto following)
        {
            var result = await db.Followings.AddAsync(new Following { 
            UserFollowing=following.UserFollowing,
            UserMaster=following.UserMaster
            });
            await db.SaveChangesAsync();
            return (result != null) ? true : false;
        }

        public async Task<IReadOnlyList<FollowingDto>> GetFollowingListAsync(string user)
        {
            var followings = await (from following in db.Followings
                                    join users in db.Users on following.UserMaster equals users.IdUser
                                    where users.IdUser == user
                                    select new
                                    {
                                        userFollowing=following.UserFollowing,
                                    }).ToListAsync();
            var result = followings.Select(x => new FollowingDto
            {
                UserFollowing=x.userFollowing
            }).ToList();
            return result;
        }
    }
}
