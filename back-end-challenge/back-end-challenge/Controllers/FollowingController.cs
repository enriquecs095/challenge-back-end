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
    public class FollowingController : Controller
    {

        private readonly IFollowingRepository followingRepository;

        public FollowingController(IFollowingRepository followingRepository)
        {
            this.followingRepository = followingRepository;

        }

        [HttpPost("AddFollowing")]
        public async Task<ActionResult<bool>> AddFollowing(FollowingDto following) {
            var result = await this.followingRepository.AddFollowingAsync(following);
            return (result) ? Ok(true) : Ok(false);
        }

        [HttpGet("GetFollowingList")]

        public async Task<ActionResult<IEnumerable<FollowingDto>>> GetFollowingList(string user) {
            var followingList = await this.followingRepository.GetFollowingListAsync(user);
            if (followingList == null) return Ok(null);
            var result = followingList.Select(x => new FollowingDto
            {
               UserFollowing=x.UserFollowing,
               UserMaster=x.UserMaster
            });
            return Ok(result);
        }

    }
}
