using back_end_challenge.Entities;
using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> CreateUserAsync(UserDto userDto);
        Task<User> LoginAsync(UserDto userDto);

    }
}
