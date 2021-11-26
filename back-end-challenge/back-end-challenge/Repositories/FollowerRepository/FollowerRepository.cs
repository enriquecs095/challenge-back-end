using back_end_challenge.Entities;
using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly postgresContext db;

        public FollowerRepository(postgresContext postgresContext)
        {
            this.db = postgresContext;
        }


        public async Task<bool> AddFollowerAsync(FollowerDto follower)
        {
            var result = await db.Followers.AddAsync(new Follower { 
            UserFollower=follower.UserFollower,
            UserMaster=follower.UserMaster,
            CreationDate=follower.CreationDate
            });
            await db.SaveChangesAsync();
            return (result != null) ? true : false;
        }

        public async Task<IReadOnlyList<FollowerDto>> GetFollowerListAsync(string user)
        {
            var followings = await (from followers in db.Followers
                                    join users in db.Users on followers.UserMaster equals users.IdUser
                                    where users.IdUser == user
                                    select new
                                    {
                                        userFollower= followers.UserFollower,
                                        creation_date=followers.CreationDate
                                    }).ToListAsync();
            var result = followings.Select(x => new FollowerDto
            {
               UserFollower=x.userFollower,
               CreationDate=x.creation_date
            }).ToList();
            return result;
        }
    }
}
