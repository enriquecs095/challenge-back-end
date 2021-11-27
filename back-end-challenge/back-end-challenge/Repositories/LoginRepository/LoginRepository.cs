using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end_challenge.Entities;

namespace back_end_challenge.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly postgresContext db;

        public LoginRepository(postgresContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateUserAsync(UserDto userDto)
        {
            var userExist = await db.Users.FirstOrDefaultAsync(x => x.IdUser == userDto.IdUser);
            if (userExist != null) { return false; }
            var result = await db.Users.AddAsync(new User
            {
                IdUser = userDto.IdUser,
                Email=userDto.Email,
                FirstName=userDto.FirstName,
                LastName=userDto.LastName,
                Password=userDto.Password,
                CreationDate=DateTime.Now,
                Thought=" ",
                Activate=0,
            });
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<User> LoginAsync(UserDto userDto)
        {
            var result = await db.Users.FirstOrDefaultAsync(x => x.IdUser == userDto.IdUser && x.Password == userDto.Password);
            if (result == null) return null;
            return new User { 
              IdUser= result.IdUser,
              CreationDate=result.CreationDate,
              FirstName=result.FirstName,
              LastName=result.LastName,
              Email=result.Email,
              Activate=result.Activate,
              Thought=result.Thought
            };
        }
    }
}
