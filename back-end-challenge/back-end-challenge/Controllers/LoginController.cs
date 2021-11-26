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

    public class LoginController : Controller
    {
        private readonly ILoginRepository loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(UserDto newUser) {
            var result = await this.loginRepository.CreateUserAsync(newUser);
            if (!result) return Ok(false);
           return Ok(true);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(UserDto user) {
            var result = await this.loginRepository.LoginAsync(user);
            if (result==null) return Ok(false);
            return Ok(new UserDto
            {
                IdUser = result.IdUser,
                CreationDate = result.CreationDate,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                Activate = result.Activate,
                Thought = result.Thought
            });
        }

    }
}
