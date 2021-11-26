using back_end_challenge.Entities;
using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly postgresContext db;

         public UserRepository(postgresContext db)
        {
            this.db = db;
        }
        public async Task<UserDto> GetUserByIdAsync(string user)
        {
            var result=await db.Users.SingleOrDefaultAsync(x => x.IdUser == user);
            if (result == null) return null;
            return new UserDto
            {
                IdUser=result.IdUser,
                FirstName=result.FirstName,
                LastName=result.LastName,
                CreationDate=result.CreationDate
            };
        }


    }
}
