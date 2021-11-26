﻿using back_end_challenge.Models;
using back_end_challenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimelineController : Controller
    {
        private readonly ITimelineRepository timelineRepository;
        public TimelineController(ITimelineRepository timelineRepository)
        {
            this.timelineRepository = timelineRepository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddCommenttoTimeline(TimelineDto timeline) {
            var result = await timelineRepository.AddCommenttoTimelineAsync(timeline);
            return (result) ? Ok(true) : Ok(false);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimelineDto>>> GetTimeline(string user) {

            var result = await timelineRepository.GetTimeLineAsync(user);
            if (result == null) return Ok(null);
            return Ok(result.Select(x => new TimelineDto
            {
                User=x.User,
                Comment=x.Comment,
                CreationDate=x.CreationDate,
                IdTimeline=x.IdTimeline
            }));
        }

    }
}
