using back_end_challenge.Models;
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
    public class FollowerController : Controller
    {

        private readonly IFollowerRepository followerRepository;

        public FollowerController(IFollowerRepository followerRepository)
        {
            this.followerRepository = followerRepository;

        }

        [HttpPost("AddFollower")]
        public async Task<ActionResult<bool>> AddFollower(FollowerDto follower) {
            var result = await this.followerRepository.AddFollowerAsync(follower);
            return (result) ? Ok(true) : Ok(false);
        }


        [HttpGet("GetFollowersList")]

        public async Task<ActionResult<IEnumerable<FollowerDto>>> GetFollowersList(string user) {
            var followersList = await this.followerRepository.GetFollowerListAsync(user);
            if (followersList == null) return Ok(null);
            var result = followersList.Select(x => new FollowerDto
            {
             UserFollower=x.UserFollower,
             UserMaster=x.UserMaster
            });
            return Ok(result);
        }

    }
}
