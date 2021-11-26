
using back_end_challenge.Models;
using back_end_challenge.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetUserByUsername")]

        public async Task<ActionResult<UserDto>> GetUserByUsername(string user) {
            var result = await this.userRepository.GetUserByIdAsync(user);
            if (result == null) return Ok(false);
            return Ok(new UserDto
            {
                IdUser = result.IdUser,
                FirstName = result.FirstName,
                LastName = result.LastName,
                CreationDate = result.CreationDate
            });
        }
      
    }
}
