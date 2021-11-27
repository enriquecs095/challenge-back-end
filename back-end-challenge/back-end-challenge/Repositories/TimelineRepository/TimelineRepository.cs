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
            var timeline = await (from timelines in db.Timelines
                                    where timelines.User == user
                                    select new
                                    {
                                        Comment= timelines.Comment,
                                        CreationDate=timelines.CreationDate
                                    }).ToListAsync();
            var result = timeline.Select(x => new TimelineDto
            {
                Comment= x.Comment,
                CreationDate=x.CreationDate
            }).ToList();
            return result;
        }
    }
}
