﻿using back_end_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_challenge.Repositories
{
    public interface IFollowerRepository
    {
        Task<bool> AddFollowerAsync(FollowerDto following);
        Task<IReadOnlyList<FollowerDto>> GetFollowerListAsync(string user);
    }
}
