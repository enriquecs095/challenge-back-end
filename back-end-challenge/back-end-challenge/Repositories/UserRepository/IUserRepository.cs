using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByIdAsync(string user);
        
    }
}
