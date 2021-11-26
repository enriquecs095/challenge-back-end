using back_end_challenge.Entities;
using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public class TimelineRepository : ITimelineRepository
    {
        private readonly postgresContext db;

        public TimelineRepository(postgresContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddCommenttoTimelineAsync(TimelineDto timeline)
        {
            var result = await db.Timelines.AddAsync(new Timeline { 
                User=timeline.User,
                Comment=timeline.Comment,
                CreationDate=DateTime.Now,
            });
            await db.SaveChangesAsync();
            return (result!=null)? true: false;
        }

        public async Task<IReadOnlyList<TimelineDto>> GetTimeLineAsync(string user)
        {
            var timeline = await (from users in db.Users
                                join followings in db.Followings on users.IdUser equals followings.UserMaster
                                join timelines in db.Timelines on users.IdUser equals timelines.User
                                where timelines.User == user && timelines.User==followings.UserFollowing
                                select new
                                {
                                    id=timelines.IdTimeline,
                                    comments=timelines.Comment,
                                    creation=timelines.CreationDate,
                                    user=timelines.User
                                }).ToListAsync();
            var result = timeline.Select(x => new TimelineDto
            {
                IdTimeline=x.id,
                Comment=x.comments,
                User=x.user,
                CreationDate=x.creation
            }).ToList();
            return result;
        }
    }
}
